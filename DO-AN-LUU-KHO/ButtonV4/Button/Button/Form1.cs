// File: Form1.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActUtlTypeLib;
using System.Threading;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using ZXing;
using System.IO;
using Microsoft.VisualBasic; 
using SysFormatException = System.FormatException;
using ZxingFormatException = ZXing.FormatException;
using System.Diagnostics;
using System.Net.NetworkInformation;





namespace Button
{
    public partial class comboBoxCameras : Form
    {

  
        public ActUtlType plc = new ActUtlType();// Đối tượng điều khiển PLC
        public bool isConnected = false;// Cờ kiểm tra trạng thái kết nối PLC



        public bool PLCIsConnected => isConnected;   // Thuộc tính kiểm tra kết nối
        private CancellationTokenSource monitorTokenSource; // Token giám sát trạng thái PLC
        private CancellationTokenSource qrTokenSource;  // Token xử lý camera/QR
        private Dictionary<string, int> lastStates = new Dictionary<string, int>();
        private bool isCameraRunning = false;// Cờ bật/tắt camera
        private string saveData; // Dữ liệu QR đang xử lý
        private bool isSaving = false;// Cờ đang lưu kho
        private bool isSaveData = false;// Cờ xác nhận đã có dữ liệu để lưu
        private Queue<string> qrQueue = new Queue<string>(); // Hàng đợi mã QR
        private int lastM25 = 0; 
        private string processingQR = null;// Mã QR đang xử lý
        private int selectedCameraIndex = 0; // Chỉ số camera đang chọn
        private string data;// Dữ liệu QR mới 
        bool daXuLyM25 = false; // Cờ xử lý M25
        private List<int> cameraDeviceIndexes = new List<int>();
        private VideoCapture capture = null;

        string csvFilePath = "mapping.csv";// File ánh xạ mã QR với loại hàng & vị trí


        // ============================
        // 🔃 KHỞI TẠO FORM
        // ============================
        public comboBoxCameras()
        {
            InitializeComponent();
            LoadCSV();// Tải dữ liệu từ file CSV vào DataGridView
            // Đăng ký sự kiện chuột cho các nút điều khiển trục
            this.dirZ.MouseDown += new MouseEventHandler(this.DirZ_MouseDown);
            this.dirZ.MouseUp += new MouseEventHandler(this.DirZ_MouseUp);

            this.Z.MouseDown += new MouseEventHandler(this.Z_MouseDown);
            this.Z.MouseUp += new MouseEventHandler(this.Z_MouseUp);

            this.X.MouseDown += new MouseEventHandler(this.X_MouseDown);
            this.X.MouseUp += new MouseEventHandler(this.X_MouseUp);

            this.dirX.MouseDown += new MouseEventHandler(this.DirX_MouseDown);
            this.dirX.MouseUp += new MouseEventHandler(this.DirX_MouseUp);
        }



        // ===========================
        // 🔌 KẾT NỐI VỚI PLC
        // ===========================
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int station = int.Parse(txtStation.Text);// Lấy số station từ ô nhập
                plc.ActLogicalStationNumber = station;// Gán station cho PLC
                int result = plc.Open();// Mở kết nối với PLC

                if (result == 0)
                {
                    isConnected = true;// Đánh dấu đã kết nối
                    connect.BackColor = Color.LimeGreen;// Đổi màu nút
                    MessageBox.Show($"✅ Đã kết nối PLC (Station {station}).");
                }
                else
                {
                    plc.Close(); // Nếu lỗi thì đóng PLC
                    isConnected = false;
                    MessageBox.Show($"❌ Kết nối thất bại. Mã lỗi: {result}");
                }
            }
            catch (SysFormatException ex)
            {
                MessageBox.Show("⚠️ Vui lòng nhập số Station hợp lệ (VD: 1, 2, 3...)");
            }
            catch (Exception ex)
            {
                isConnected = false;
                MessageBox.Show($"⚠️ Lỗi khi kết nối: {ex.Message}");
            }
        }

        // Nút ngắt kết nối plc
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                plc.Close();
                isConnected = false;
                disconnect.BackColor = Color.White;
                disconnect.BackColor = Color.Red;
                MessageBox.Show("🔌 Đã ngắt kết nối PLC.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"⚠️ Lỗi khi ngắt kết nối: {ex.Message}");
            }
        }



        //nhấn nhả
        private void PulseDevice(string device)
        {
            try
            {
                if (!isConnected) throw new Exception("Chưa kết nối PLC!");

                plc.SetDevice(device, 1);
                System.Threading.Thread.Sleep(100); // xung 100ms
                plc.SetDevice(device, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"⚠️ Lỗi ghi PLC ({device}): {ex.Message}");
            }
        }


        private void holdDevice(string device)
        {

            try
            {
                if (!isConnected) throw new Exception("Chưa kết nối PLC!");

                int val;
                plc.GetDevice(device, out val);


                int newVal = val == 0 ? 1 : 0; // Đảo 
                plc.SetDevice(device, newVal); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"⚠️ Lỗi ghi PLC ({device}): {ex.Message}");
            }


        }



        private void Start_Click(object sender, EventArgs e)
        {
            plc.GetDevice("X4", out int val);
            if(val == 1)
            {
                MessageBox.Show($"⚠️ Đang có hàng ở cuối băng tải, không được phép khởi động");
                return;
                
            }



            textBoxQR.Text = $"Dữ liệu mã QR:";
            isSaving = false;
            isSaveData = false;
            saveData = null;
            processingQR = null;
            qrQueue.Clear();
            lastM25 = 0;
            data = null;
            PulseDevice("X0"); // Gửi xung khởi động


            


        }
        private void Stop_click(object sender, EventArgs e)
        {
            PulseDevice("X1");
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            PulseDevice("M3");
            textBoxQR.Text = $"Dữ liệu mã QR:";
            data = null;

            // Reset các biến trạng thái
            isSaving = false;
            isSaveData = false;
            saveData = null;
            processingQR = null;
            qrQueue.Clear();
            lastM25 = 0;
        
        }

        private void Home_Click(object sender, EventArgs e)
        {
            PulseDevice("S17");
        }



        //**************** Cac nút chế độ tay ***********************
        private void m_bt1_Click(object sender, EventArgs e)
        {
            holdDevice("s10");
        }

        private void m_bt2_Click(object sender, EventArgs e)
        {
            holdDevice("s11");
        }

        private void m_vanxilanh_Click(object sender, EventArgs e)
        {
            holdDevice("S12");
        }
        private void PulseDevice123(string device)
        {
            plc.SetDevice(device, 1);
        }
        private void StopDevice(string device)
        {
            plc.SetDevice(device, 0);
        }
        private void DirZ_MouseDown(object sender, MouseEventArgs e)
        {
            PulseDevice123("S16");
        }

        private void DirZ_MouseUp(object sender, MouseEventArgs e)
        {
            StopDevice("S16");
        }

        private void Z_MouseDown(object sender, MouseEventArgs e)
        {
            PulseDevice123("S15");
        }

        private void Z_MouseUp(object sender, MouseEventArgs e)
        {
            StopDevice("S15");
        }

        private void X_MouseDown(object sender, MouseEventArgs e)
        {
            PulseDevice123("S13");
        }

        private void X_MouseUp(object sender, MouseEventArgs e)
        {
            StopDevice("S13");
        }

        private void DirX_MouseDown(object sender, MouseEventArgs e)
        {
            PulseDevice123("S14");
        }

        private void DirX_MouseUp(object sender, MouseEventArgs e)
        {
            StopDevice("S14");
        }

        private void standardControl2_Load(object sender, EventArgs e)
        {

        }

        private void standardControl4_Load(object sender, EventArgs e)
        {

        }


 
        // LƯU/XUẤT KHO

        private void button5_Click(object sender, EventArgs e)
        {


            try
            {
                if (!isConnected) throw new Exception("Chưa kết nối PLC!");

                plc.GetDevice("M35", out int val);// Kiểm tra đang xuất kho không
                if (val == 1)
                {
                    MessageBox.Show($"⚠️ Đang thực hiện xuất kho, vui lòng đợi!!!!");
                    return;
                }
                holdDevice("S1");// Kích hoạt chế độ lưu kho
                plc.SetDevice("S2", 0);// Tắt chế độ xuất kho (nếu đang bật)
                PulseDevice("X1");// Khởi động

            }
            catch (Exception ex)
            {
                MessageBox.Show($"⚠️ Lỗi ghi PLC ({"S1"}): {ex.Message}");
            }


            
            
        }

        // Nút xử lý xuất kho - mở form chọn loại hàng để xuất
        private void xuatkho_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isConnected) throw new Exception("Chưa kết nối PLC!");

                plc.GetDevice("M34", out int val); // Kiểm tra đang lưu kho không
                if (val == 1)
                {
                    MessageBox.Show($"⚠️ Đang thực hiện lưu kho, vui lòng đợi!!!!");
                    return;
                }

               // plc.GetDevice("M102", out int val2);
               // if (val2 == 0)
               // {
               //     MessageBox.Show($"⚠️ Chưa nhấn bắt đầu, xin vui lòng thử lại !!!!");
               //     return;
               // }
            }
            catch (Exception ex)
            {
               
            }
            holdDevice("S2");// Bật chế độ xuất kho
            plc.GetDevice("S2", out int val1);   // Nếu không thành công thì thoát
            if (val1 == 0)
            {
                return; // Nếu không thành công thì thoát
            }

            plc.SetDevice("S1", 0);// Tắt chế độ lưu kho (nếu đang bật)
            PulseDevice("X1"); // Khởi động






            //  giao diện
            var form = new System.Windows.Forms.Form
            {
                Text = "📦 Chọn hàng để xuất",
                Width = 600,
                Height = 350,
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.White
            };
            // Giao diện chọn hàng để xuất
            var table = new TableLayoutPanel
            {
                RowCount = 2,
                ColumnCount = 3,
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                Padding = new Padding(20),
                BackColor = Color.White,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            // Bảng hiển thị các vị trí hàng
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            for (int i = 0; i < 3; i++)
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            for (int i = 0; i < 2; i++)
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));

            form.Controls.Add(table);

            //  Gọi hàm vẽ nút
            FormXuatkho(table);

            form.ShowDialog();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            holdDevice("S0");

        }

        private void txtStation_TextChanged(object sender, EventArgs e)
        {

        }

        // *******************************tạo luồng giám sát

        private void UpdateUI(Dictionary<string, int> currentStates)
        {
            if (currentStates["Y6"] != lastStates["Y6"]) //Y6 thay đổi: nếu Y6 = 1 (máy đang chạy), nút Start đổi màu xanh.
                Start.BackColor = currentStates["Y6"] == 1 ? Color.Lime : Color.Empty;

            if (currentStates["Y6"] != lastStates["Y6"])
                Stop.BackColor = currentStates["Y6"] == 0 ? Color.Red : Color.Empty;

            if (currentStates["S0"] == 1)//Y6 = 0 (máy dừng), nút Stop đổi màu đỏ.
            {
                label4.BackColor = Color.Lime;
                label5.BackColor = Color.Empty;
            }
            else
            {
                label4.BackColor = Color.Empty;
                label5.BackColor = Color.Lime;
            }




          





            if (currentStates["S1"] == 1)
            {
                luukho.BackColor = Color.Lime;
                xuatkho.BackColor = Color.Empty;

            }
            else if (currentStates["S2"] == 1)
            {
                luukho.BackColor = Color.Empty;
                xuatkho.BackColor = Color.Lime;

            }
            else
            {
                luukho.BackColor = Color.Gray;
                xuatkho.BackColor = Color.Gray;

            }

            if (currentStates["Y4"] != lastStates["Y4"])
                m_bt1.BackColor = currentStates["Y4"] == 1 ? Color.Lime : Color.Empty;

            if (currentStates["Y5"] != lastStates["Y5"])
                m_bt2.BackColor = currentStates["Y5"] == 1 ? Color.Lime : Color.Empty;

            if (currentStates["Y11"] == 1)
            {
                label2.Text = "Trục Y: ON";
                m_vanxilanh.BackColor = Color.Lime;
            }
            else
            {
                label2.Text = "Trục Y: OFF";
                m_vanxilanh.BackColor = Color.Empty;
            }

            if (currentStates["D8140"] != lastStates["D8140"])
                label1.Text = $"Trục X: {currentStates["D8140"]}";

            if (currentStates["D8142"] != lastStates["D8142"])
                label3.Text = $"Trục Z: {currentStates["D8142"]}";

            // Trigger lưu lịch sử nhập kho // biến m25 có nhiệm vụ cho biết đa hoàn tất lluwu kho
     
            if (lastM25 == 0 && currentStates["M25"] == 1 && isSaving && !string.IsNullOrEmpty(processingQR))
            {
                string qr = processingQR;

                if (File.Exists("mapping.csv"))
                {
                    string matchingLine = File.ReadAllLines("mapping.csv")
                        .FirstOrDefault(l => l.StartsWith(qr + ","));

                    if (matchingLine != null)
                    {
                        string[] parts = matchingLine.Split(',');
                        if (parts.Length >= 3)
                        {
                            string loaihang = parts[1];
                            string vitri = parts[2];

                            string qlFile = "qlkho.csv";
                            bool daCo = File.Exists(qlFile) && File.ReadAllLines(qlFile)
                                .Any(l => l.Split(',').Length >= 3 && l.StartsWith(qr + ","));

                            if (!daCo)
                            {
                                File.AppendAllText(qlFile, matchingLine + Environment.NewLine);
                                textBoxThongTin.AppendText($"✅ Nhập kho thành công QR: {qr}{Environment.NewLine}");
                                GhiLichSu(qr, loaihang, vitri, "Nhập kho");
                                CapNhatTrangThaiViTri();
                            }
                        }
                    }
                }

                isSaving = false;
                isSaveData = false;
                saveData = null;
                processingQR = null;
                plc.GetDevice("M36", out int M36);
                plc.GetDevice("X3", out int X3);
                if (M36 == 0)
               {
                    if(X3 == 1)
                    {
                        textBoxQR.Text = "Dữ liệu mã QR:";
                    }
                    
               }else
                 {
                   qrQueue.Clear();
               }
                
               

                TryProcessNextQR();
            }

            lastM25 = currentStates.ContainsKey("M25") ? currentStates["M25"] : 0;







            // xử lý thông báo xuất kho thành công tại đây



            if ((currentStates["M14"] == 1 && currentStates["M34"] == 1) && currentStates["M12"] == 0)
            {
                string input = Interaction.InputBox("Nhập mã sản phẩm:", "Yêu cầu nhập", "Mặc định");
                if (!string.IsNullOrEmpty(input))
                {
                    MessageBox.Show($"Bạn đã nhập: {input}");
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập gì!");
                }

            }



            foreach (var key in currentStates.Keys)
                lastStates[key] = currentStates[key];
        }
        private void StartMonitoring()
        {
            monitorTokenSource = new CancellationTokenSource();
            Task.Run(() => MonitorPLCStates(monitorTokenSource.Token));
        }
        //Luồng giám sát các thiết bị PLC liên tục mỗi 100ms
        private void MonitorPLCStates(CancellationToken token)
        {
            var devices = new[] { "Y6", "Y7", "Y11", "M0", "M40", "S0", "S1", "S2", "D8140", "D8142", "D2", "Y4", "Y5", "D4", "M25", "M34", "M12", "M14", "M33" };// Danh sách các thiết bị cần theo dõi (địa chỉ PLC)
            foreach (var d in devices) lastStates[d] = -1;// Gán giá trị mặc định (-1) cho tất cả thiết bị

            while (!token.IsCancellationRequested)
            {
                try
                {
                    var currentStates = new Dictionary<string, int>();
                    // Đọc trạng thái hiện tại từ PLC cho mỗi thiết bị
                    foreach (var dev in devices)
                    {
                        plc.GetDevice(dev, out int val);
                        currentStates[dev] = val;
                    }
                    // Nếu có thay đổi trạng thái thì cập nhật UI
                    if (IsStateChanged(currentStates))
                    {
                        if (!IsDisposed && Visible)
                        {
                            BeginInvoke((MethodInvoker)(() =>
                            {
                                UpdateUI(currentStates);// Cập nhật giao diện
                            }));
                        }
                    }
                }
                catch (Exception ex)
                {
                    // log lỗi nếu cần
                }

                Thread.Sleep(100); // delay phù hợp để tránh spam CPU
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCameraDevices();
            StartMonitoring();
            dataGridViewHistory.Visible = false;
            CapNhatTrangThaiViTri();

        }
        // Phiên bản async của MonitorPLCStates (sử dụng await để giảm nghẽn UI)
        private async void MonitorPLCStatesAsync(CancellationToken token)
        {
            var devices = new[] { "Y6", "Y7", "Y11", "M0", "M40", "S0", "S1", "S2", "D8140", "D8142", "D2", "Y4", "Y5", "D4" };
            foreach (var d in devices) lastStates[d] = -1;

            while (!token.IsCancellationRequested)
            {
                try
                {
                    var currentStates = new Dictionary<string, int>();
                    // Đọc trạng thái các thiết bị trong 1 Task (tránh block UI)
                    await Task.Run(() =>
                    {
                        foreach (var dev in devices)
                        {
                            plc.GetDevice(dev, out int val);
                            currentStates[dev] = val;
                        }
                    });
                    // Nếu có sự thay đổi -> cập nhật giao diện
                    if (IsStateChanged(currentStates))
                    {
                        if (this.Visible && !this.IsDisposed)
                        {
                            Invoke((MethodInvoker)(() => UpdateUI(currentStates)));
                        }
                    }
                }
                catch { }

                await Task.Delay(100, token); // Tăng delay lên 100ms để giảm tải CPU/UI
            }
        }
        // Kiểm tra xem có thay đổi trạng thái thiết bị nào không
        private bool IsStateChanged(Dictionary<string, int> current)
        {
            return current.Any(kv => lastStates.TryGetValue(kv.Key, out int oldVal) && oldVal != kv.Value);
        }




        ////**********Camera********////
        private void LoadCameraDevices()
        {
            cameraDeviceIndexes.Clear();
            comboBoxCameraSource.Items.Clear();

            for (int i = 0; i < 5; i++)
            {
                using (var testCapture = new VideoCapture(i))
                {
                    if (testCapture.IsOpened())
                    {
                        comboBoxCameraSource.Items.Add($"Camera {i}");
                        cameraDeviceIndexes.Add(i);
                        testCapture.Release();
                    }
                }
            }

            if (comboBoxCameraSource.Items.Count > 0)
                comboBoxCameraSource.SelectedIndex = 0;
        }


        // Khi người dùng chọn camera khác từ combobox
        private void comboBoxCameraSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCameraSource.SelectedIndex >= 0)
            {
                selectedCameraIndex = cameraDeviceIndexes[comboBoxCameraSource.SelectedIndex];
                Console.WriteLine($"🔄 Đã chọn camera index: {selectedCameraIndex}");

                if (isCameraRunning)
                {
                    StopCameraQRScanner();
                    StartCameraQRScanner();
                }
            }
        }


        // Khởi động quét QR từ camera (gọi trong luồng mới)
        private void StartCameraQRScanner()
        {
            qrTokenSource = new CancellationTokenSource();
            capture?.Release();
            capture?.Dispose();

            capture = new VideoCapture(selectedCameraIndex);
            Console.WriteLine($"🟢 Đang mở camera index: {selectedCameraIndex}");

            if (!capture.IsOpened())
            {
                MessageBox.Show($"❌ Không thể mở camera tại index {selectedCameraIndex}");
                return;
            }

            Task.Run(() => RunQRScanner(qrTokenSource.Token));
        }

        // Dừng quét QR
        private void StopCameraQRScanner()
        {
            qrTokenSource?.Cancel();
            qrTokenSource = null;

            if (capture != null)
            {
                capture.Release();
                capture.Dispose();
                capture = null;
            }

            pictureBoxCam.Image = null;
        }


        // Luồng quét mã QR từ camera
        private void RunQRScanner(CancellationToken token)
        {
            var reader = new BarcodeReader();

            while (!token.IsCancellationRequested)
            {
                try
                {
                    using (var frame = new Mat())
                    {
                        capture.Read(frame);
                        if (frame.Empty())
                        {
                            Console.WriteLine("⚠️ Frame trống");
                            continue;
                        }

                        var bitmap = BitmapConverter.ToBitmap(frame);
                        var result = reader.Decode(bitmap);

                        BeginInvoke((MethodInvoker)(() =>
                        {
                            var oldImage = pictureBoxCam.Image;
                            pictureBoxCam.Image = (Bitmap)bitmap.Clone();
                            oldImage?.Dispose();

                            if (result != null && !string.IsNullOrEmpty(result.Text) && result.Text != data)
                            {
                                data = result.Text;
                                textBoxQR.Text = $"Dữ liệu mã QR:{result.Text}";
                            }
                        }));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Lỗi: " + ex.Message);
                }

                Thread.Sleep(50);
            }
        }


        // Khi form đóng, dừng camera và hủy giám sát PLC
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCameraQRScanner();
            monitorTokenSource?.Cancel();
            pictureBoxCam.Image?.Dispose();
        }
        // Bật/tắt camera bằng nút toggle
        private void btnToggleCamera_Click_1(object sender, EventArgs e)
        {
            if (!isCameraRunning)
            {
                selectedCameraIndex = cameraDeviceIndexes[comboBoxCameraSource.SelectedIndex];
                StartCameraQRScanner();

                if (capture != null && capture.IsOpened())
                {
                    btnToggleCamera.Text = "⛔ Tắt Camera";
                    btnToggleCamera.BackColor = Color.Red;
                    isCameraRunning = true;
                    btnLuuKhoTay.Visible = false;
                }
                else
                {
                    MessageBox.Show($"❌ Không thể mở camera tại index {selectedCameraIndex}");
                }
            }
            else
            {
                StopCameraQRScanner();
                btnToggleCamera.Text = "📷 Bật Camera";
                btnToggleCamera.BackColor = Color.LightGreen;
                isCameraRunning = false;
                btnLuuKhoTay.Visible = true;
            }
        }
        // gọi khi text thay đổi
        private void textBoxQR_TextChanged(object sender, EventArgs e)
        {
            string newQR = data;
            if (string.IsNullOrEmpty(newQR)) return;

            // Nếu đang xử lý, không được thêm QR khác vào
            if (isSaving)
            {
                textBoxThongTin.AppendText($"⚠️ Đang xử lý QR trước đó, vui lòng đợi...{Environment.NewLine}");
                plc.GetDevice("X3", out int X3);
                plc.GetDevice("X4", out int X4);

                if(X3 == 1 && X4 == 0)
                {
                    
                        PulseDevice("X1");
                        MessageBox.Show($"⚠️ Lỗi 2 mã liên tiếp!!!!!!!!!");
                    
                }


                return;
            }

            if (!qrQueue.Contains(newQR))
                qrQueue.Enqueue(newQR);

            TryProcessNextQR();
        }
        // cái lz má
        private void TryProcessNextQR()
        {
            if (isSaving || qrQueue.Count == 0) return;

            processingQR = qrQueue.Dequeue();

            if (File.Exists("qlkho.csv") && File.ReadAllLines("qlkho.csv")
                .Any(l => l.Split(',').Length >= 3 && l.StartsWith(processingQR + ",")))
            {
                
                    textBoxThongTin.AppendText($"⚠️ Mã QR: {processingQR} đã tồn tại trong kho! Bỏ qua.{Environment.NewLine}");

                //PulseDevice("X2");
                plc.SetDevice("M47", 1);
                MessageBox.Show($"⚠️ Mã QR: {processingQR} đã tồn tại trong kho! Bỏ qua.");




                processingQR = null;
                TryProcessNextQR();// Thử tiếp mã khác
                return;
            }
            if (!File.Exists("mapping.csv") || !File.ReadAllLines("mapping.csv")
            .Any(line => line.Split(',').Length == 3 && line.StartsWith(processingQR + ",")))
            {
                textBoxThongTin.AppendText($"❌ QR: {processingQR} chưa được khai báo trong mapping.csv! Bỏ qua.\n");
                plc.SetDevice("M47", 1); // cảnh báo mapping thiếu
                MessageBox.Show($"❌ QR: {processingQR} chưa được khai báo trong mapping.csv!");
                processingQR = null;
                TryProcessNextQR();
                return;
            }
            mov2plc(processingQR);
            isSaving = true;
            isSaveData = true;
            saveData = processingQR;
            plc.SetDevice("M47", 0);

            textBoxThongTin.AppendText($"🕐 Đang xử lý QR: {processingQR}{Environment.NewLine}");
        }


        // hàm lz
        private void mov2plc(string qr)
        {
            if (!isConnected || string.IsNullOrWhiteSpace(qr)) return;

            string vitriStr = TimViTriLuuKho(qr); // Tìm vị trí 
            string loaihang = TimViTriLoaiHang(qr); // Tìm loại hàng

            if (!int.TryParse(vitriStr, out int vitri)) return;

            if (vitri > 6)
            {
                MessageBox.Show($"⚠️ Vị trí {vitri} chưa được thiết lập");
                return;
            }
            // Kiểm tra vị trí đã có hàng chưa
            if (File.Exists("qlkho.csv") && File.ReadAllLines("qlkho.csv")
                .Any(l =>
                {
                    var parts = l.Split(',');
                    return parts.Length >= 3 && parts[2].Trim() == vitriStr;
                }))
            {
                MessageBox.Show($"⚠️ Vị trí {vitri} đã có hàng!");
                return;
            }

            plc.GetDevice("M35", out int dangXuatKho);
            if (dangXuatKho == 1)
            {
                MessageBox.Show("⚠️ Đang xuất kho, không thể lưu kho");
                return;
            }

            try
            {
                plc.SetDevice("D0", vitri);// Gửi vị trí xuống PLC
                textBoxThongTin.AppendText($"✅ QR: {qr} - {loaihang} chuẩn bị lưu tại vị trí {vitri}\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Lỗi khi gửi dữ liệu xuống PLC: " + ex.Message);
            }
        }



        //*************************************************************

        // Nút "Cài đặt QR" - lưu dữ liệu từ DataGridView xuống file mapping.csv
        private void btnCaiDatQR_Click_1(object sender, EventArgs e)
        {
            string filePath = "mapping.csv";


            HashSet<string> qrSet = new HashSet<string>();     // Kiểm tra trùng mã QR
            HashSet<string> loaiSet = new HashSet<string>();   // Kiểm tra trùng loại hàng
            HashSet<string> vitriSet = new HashSet<string>();  // Kiểm tra trùng vị trí

            List<string> linesToWrite = new List<string>();// Danh sách dòng sẽ ghi vào file

            foreach (DataGridViewRow row in dataGridView1.Rows)// Duyệt qua từng dòng trong bảng
            {
                if (!row.IsNewRow)
                {
                    string qr = row.Cells[0].Value?.ToString()?.Trim();
                    string loai = row.Cells[1].Value?.ToString()?.Trim();
                    string vitri = row.Cells[2].Value?.ToString()?.Trim();
                    // Bỏ qua dòng trống
                    if (string.IsNullOrWhiteSpace(qr) || string.IsNullOrWhiteSpace(loai) || string.IsNullOrWhiteSpace(vitri))
                        continue;



                    // Kiểm tra vị trí phải là số từ 1 đến 6
                    if (!int.TryParse(vitri, out int viTriSo) || viTriSo < 1 || viTriSo > 6)
                    {
                        MessageBox.Show($"⚠️ Vị trí không hợp lệ: {vitri}. Chỉ cho phép từ 1 đến 6.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra trùng
                    if (qrSet.Contains(qr) || loaiSet.Contains(loai) || vitriSet.Contains(vitri))
                    {
                        MessageBox.Show("⚠️ Dữ liệu trùng lặp phát hiện trong bảng!\nKhông thể lưu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Thêm vào tập hợp kiểm tra trùng
                    qrSet.Add(qr);
                    loaiSet.Add(loai);
                    vitriSet.Add(vitri);

                    linesToWrite.Add($"{qr},{loai},{vitri}");
                }
            }

            // Ghi file nếu không có trùng lặp
            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                foreach (string line in linesToWrite)
                {
                    writer.WriteLine(line);
                }
            }

            MessageBox.Show("✅ Đã lưu thành công vào file mapping.csv", "Thông báo");
        }

        // Nút "Cài đặt vị trí" - xóa sạch bảng
        private void btnCaiDatViTri_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
        // Hàm xóa tất cả dữ liệu bảng (giống với btnCaiDatViTri_Click_1)
        private void ResetFields()
        {
            dataGridView1.Rows.Clear();
        }
        // Tải dữ liệu từ mapping.csv vào bảng cấu hình
        private void LoadCSV()
        {
            string filePath = "mapping.csv";
            if (!File.Exists(filePath)) return;

            dataGridView1.Rows.Clear();

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 3)
                {
                    dataGridView1.Rows.Add(parts[0], parts[1], parts[2]);
                }
            }
        }



        // Trả về vị trí lưu kho tương ứng với mã QR
        public string TimViTriLuuKho(string qrCode)
        {
            if (!File.Exists("mapping.csv")) return null;

            var lines = File.ReadAllLines("mapping.csv");
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 3 && parts[0] == qrCode)
                {
                    return parts[2]; // Vị trí lưu kho
                }
            }

            return null;
        }
        public string TimViTriLoaiHang(string qrCode)// Trả về loại hàng tương ứng với mã QR
        {
            if (!File.Exists("mapping.csv")) return null;

            var lines = File.ReadAllLines("mapping.csv");
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 3 && parts[0] == qrCode)
                {
                    return parts[1];
                }
            }

            return null;
        }
        // Hàm xóa sản phẩm theo mã QR khỏi qlkho.csv sau khi xuất kho
        private void XoaKhoTrongQLKho(string qrCode)
        {
            string path = "qlkho.csv";
            if (!File.Exists(path)) return;
            // Chỉ giữ lại dòng không trùng QR
            var lines = File.ReadAllLines(path)
                            .Where(line => !line.StartsWith(qrCode + ","))
                            .ToList();
            File.WriteAllLines(path, lines);
        }





        // Ghi lịch sử nhập/xuất kho vào file history.csv và hiện lên DataGridView
        private void GhiLichSu(string qr, string loaihang, string vitri, string hanhdong)
        {
            string filePath = "history.csv";
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string line = $"{timestamp},{qr},{loaihang},{vitri},{hanhdong}";

            // Ghi vào file CSV
            try
            {
                File.AppendAllText(filePath, line + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ghi lịch sử: {ex.Message}");
            }

            // Hiển thị lên DataGridView
            if (dataGridViewHistory.InvokeRequired)
            {
                dataGridViewHistory.Invoke(new Action(() =>
                {
                    dataGridViewHistory.Rows.Add(timestamp, qr, loaihang, vitri, hanhdong);
                }));
            }
            else
            {
                dataGridViewHistory.Rows.Add(timestamp, qr, loaihang, vitri, hanhdong);
            }
        }



        // Nút xem/ẩn lịch sử (hiển thị dữ liệu từ history.csv)
        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridViewHistory.Visible = !dataGridViewHistory.Visible;// Bật/tắt hiển thị bảng lịch sử
            dataGridViewHistory.Rows.Clear();// Xóa dữ liệu cũ trong bảng
            string filePath = "history.csv";
            if (File.Exists(filePath))
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 5)
                    {
                        dataGridViewHistory.Rows.Add(parts);// Thêm dòng lịch sử vào bảng
                    }
                }
            }
        }

        private void FormXuatkho(TableLayoutPanel table)
        {
            table.Controls.Clear();// Xoá toàn bộ nút cũ trên bảng

            string filePath = "qlkho.csv";
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, ""); // Tạo file nếu chưa có
                MessageBox.Show(".");
                return; 
            }

            var lines = File.ReadAllLines(filePath);
            // Đọc dữ liệu từ file qlkho.csv thành danh sách mặt hàng
            var items = lines
                .Select(l => l.Split(','))
                .Where(p => p.Length == 3)
                .Select(p => new { QR = p[0], Loai = p[1], ViTri = p[2] })
                .ToList();

            if (items.Count == 0)
            {
                MessageBox.Show("⚠️ Kho rỗng, không có loại hàng nào để xuất.");
                return;
            }
            // Tạo ánh xạ vị trí -> loại hàng & mã QR
            Dictionary<int, string> viTriToLoai = new Dictionary<int, string>();
            Dictionary<int, string> viTriToQR = new Dictionary<int, string>();

            foreach (var item in items)
            {
                if (int.TryParse(item.ViTri, out int v))
                {
                    viTriToLoai[v] = item.Loai;
                    viTriToQR[v] = item.QR;
                }
            }

            int[] layout = { 4, 5, 6, 1, 2, 3 };// Vị trí hiển thị theo thứ tự tùy chỉnh
            foreach (int vitri in layout)
            {
                string loaiHang = viTriToLoai.ContainsKey(vitri) ? viTriToLoai[vitri] : "Trống";
                string qrCode = viTriToQR.ContainsKey(vitri) ? viTriToQR[vitri] : null;
                // Tạo nút cho từng vị trí
                var btn = new System.Windows.Forms.Button
                {
                    Text = $"📦 Vị trí {vitri}\n🛒 {loaiHang}",
                    BackColor = (qrCode != null) ? Color.FromArgb(255, 105, 97) : Color.LightGreen,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                    Tag = vitri,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(10),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.LightBlue;
                // Sự kiện khi bấm nút xuất hàng
                btn.Click += (s, ev) =>
                {
                    if (!viTriToQR.ContainsKey(vitri))
                    {
                        MessageBox.Show("⚠️ Vị trí này đang trống, không thể xuất kho.");
                        return;
                    }

                    string qr = viTriToQR[vitri];
                    string loai = viTriToLoai[vitri];

                    var confirm = MessageBox.Show(
                        $"Bạn chắc chắn muốn xuất kho:\n👉 {loai} (QR: {qr}) tại vị trí {vitri}?",
                        "Xác nhận xuất kho",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm != DialogResult.Yes) return;

                    try
                    {
                        if (!isConnected) throw new Exception("Chưa kết nối PLC!");
                        PulseDevice("X0");// Gửi xung bắt đầu
                        plc.SetDevice("D0", vitri);// Gửi vị trí xuống PLC
                        plc.SetDevice("S2", 1);// Bật chế độ xuất kho


                        MessageBox.Show($"🕐 Đã gửi lệnh xuất kho vị trí {vitri} ({loai})...");

                        // Chờ PLC xuất kho thành công (M35 về 0)
                        Task.Run(() =>
                        {
                            // int timeout = 10000;
                            // int elapsed = 0;
                            // elapsed < timeout
                            plc.GetDevice("M35", out int val);

                            if(val == 1)
                            {
                                // MessageBox.Show($"✅ {loai} Đang xuất kho!");

                                //textBoxThongTin.AppendText($"{loai} đang được xuất kho {Environment.NewLine}");
                                while (val == 1)
                                {
                                    plc.GetDevice("M35", out int val1);
                                    if (val1 == 0)
                                    {
                                        this.Invoke(new Action(() =>
                                        {


                                            MessageBox.Show($"✅ {loai} xuất kho thành công!");
                                            GhiLichSu(qr, loai, vitri.ToString(), "Xuất kho");
                                            XoaKhoTrongQLKho(qr);    // Xoá dòng trong qlkho.csv             
                                            CapNhatTrangThaiViTri();         // Cập nhật lại màu nút        
                                            LoadCSV();
                                           
                                            FormXuatkho(table);// Vẽ lại bảng
                                        }));
                                        return;
                                    }
                                }



                           
                                Thread.Sleep(100);
                                //elapsed += 100;
                            }
                            // Nếu không phản hồi
                            this.Invoke(new Action(() =>
                            {
                                MessageBox.Show(" PLC không phản hồi xuất kho hãy kiểm tra lại!! )");
                            }));
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("❌ Lỗi khi xuất kho: " + ex.Message);
                    }
                };

                table.Controls.Add(btn);// Thêm nút vào bảng
            }
        }

        private void dataGridViewHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var menu = new ContextMenuStrip();

            menu.Items.Add("🛠️ Cài đặt xung XZ", null, (s, ev) =>
            {
                var formXung = new FormXung(plc);
                formXung.ShowDialog();
            });
            menu.Show(Cursor.Position);
        }

        private void btnLuuKhoTay_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                MessageBox.Show("⚠️ Chưa kết nối PLC!");
                return;
            }

            // Đọc tín hiệu từ PLC
            plc.GetDevice("S0", out int s0);
            plc.GetDevice("S1", out int s1);
            plc.GetDevice("M100", out int m100);
            plc.GetDevice("M12", out int m12);

            if (s0 != 1 || s1 != 1 || m100 != 1 || m12 != 1)
            {
                MessageBox.Show("⚠️ Không đủ điều kiện để lưu kho tay!\nYêu cầu: S0 = 1, S1 = 1, M100 = 1, M12 = 1");
                return;
            }

            // Nhập tên sản phẩm
            string tenSanPham = Interaction.InputBox("🏷️ Nhập tên sản phẩm:", "Nhập liệu thủ công", "").Trim();
            if (string.IsNullOrWhiteSpace(tenSanPham))
            {
                MessageBox.Show("❌ Bạn chưa nhập tên sản phẩm!");
                return;
            }

            string mappingFile = "mapping.csv";
            if (!File.Exists(mappingFile))
            {
                MessageBox.Show("❌ Không tìm thấy file mapping.csv!");
                return;
            }

            // Tìm mã QR tương ứng với tên sản phẩm
            string qrCode = null;
            string viTriStr = null;

            foreach (var line in File.ReadAllLines(mappingFile))
            {
                var parts = line.Split(',');
                if (parts.Length >= 3 && parts[1].Trim().Equals(tenSanPham, StringComparison.OrdinalIgnoreCase))
                {
                    qrCode = parts[0].Trim();
                    viTriStr = parts[2].Trim();
                    break;
                }
            }

            if (string.IsNullOrEmpty(qrCode) || string.IsNullOrEmpty(viTriStr))
            {
                MessageBox.Show("❌ Không tìm thấy mã QR hoặc vị trí tương ứng trong mapping.csv!");
                return;
            }

            if (!int.TryParse(viTriStr, out int viTri) || viTri > 6 || viTri < 1)
            {
                MessageBox.Show($"❌ Vị trí không hợp lệ: {viTriStr}");
                return;
            }

            // Kiểm tra nếu vị trí đã có hàng trong qlkho.csv
            string qlKhoFile = "qlkho.csv";
            if (File.Exists(qlKhoFile))
            {
                var daTonTai = File.ReadAllLines(qlKhoFile).Any(l =>
                {
                    var p = l.Split(',');
                    return p.Length >= 3 && p[2].Trim() == viTriStr;
                });

                if (daTonTai)
                {
                    MessageBox.Show($"⚠️ Vị trí {viTri} đã có hàng! Không thể lưu.");
                    return;
                }
            }

            // Gửi xuống PLC
            try
            {
                plc.SetDevice("D0", viTri);
                processingQR = qrCode;
                isSaving = true;
                lastM25 = 0;
                textBoxThongTin.AppendText($"✅ Đã gửi vị trí {viTri} cho sản phẩm \"{tenSanPham}\" (QR: {qrCode})\n");
                MessageBox.Show("📤 Đang đợi tín hiệu M25 từ PLC...");
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi gửi dữ liệu xuống PLC: " + ex.Message);
            }
        }


        private void CapNhatTrangThaiViTri()
        {
            string filePath = "qlkho.csv";
            HashSet<int> viTriDaDung = new HashSet<int>();// Khởi tạo một HashSet để lưu trữ các vị trí kho đã được sử dụng

            if (File.Exists(filePath))// Kiểm tra xem file CSV có tồn tại không
            {
                // Đọc tất cả các dòng từ file CSV
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)// Duyệt qua từng dòng trong file CSV
                {
                    // Tách dòng thành các phần (phân cách bởi dấu phẩy)
                    var parts = line.Split(',');
                    if (parts.Length == 3 && int.TryParse(parts[2], out int viTri)) // Kiểm tra nếu dòng có đủ 3 phần và phần thứ 3 là một số nguyên hợp lệ
                    {
                        // Thêm vị trí kho vào HashSet nếu là số nguyên hợp lệ
                        viTriDaDung.Add(viTri);
                    }
                }
            }
            // Duyệt qua các vị trí kho từ 1 đến 6
            for (int i = 1; i <= 6; i++)
            {
                var btn = Controls.Find($"btnViTri{i}", true).FirstOrDefault() as System.Windows.Forms.Button;
                if (btn != null)
                {
                    // Kiểm tra xem vị trí kho đã được sử dụng hay chưa
                    bool isOccupied = viTriDaDung.Contains(i);

                    btn.Text = isOccupied// Nếu vị trí đã sử dụng, hiển thị biểu tượng khóa và kho đã đầy
                        ? $"📦 Kho {i}\n🔒"
                        : $"📦 Kho {i}\n🟢 ";// Nếu vị trí chưa sử dụng, hiển thị biểu tượng vòng tròn xanh và kho còn trống

                    btn.BackColor = isOccupied
                        ? Color.FromArgb(231, 76, 60)      
                        : Color.FromArgb(39, 174, 96);      

                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.UseVisualStyleBackColor = false;
                    btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                }
            }

        }


        private void textBoxThongTin_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXoaThongBao_Click(object sender, EventArgs e)
        {
            textBoxThongTin.Clear();
        }

        private void dirX_Click(object sender, EventArgs e)
        {

        }

        private void btnViTri6_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxCameraSource_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

       
    }

}


