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

namespace Button
{
    public partial class FormXung : Form
    {
        private readonly ActUtlType plc;
        int homeX = 0;
        int homeZ = 0;
        int pulXman = 0;
        int pulZman = 0;
        int pulX = 0;
        int pulZ = 0;
        int tonZ = 0;
        int tonY = 0;
        int toffY = 0;
        public FormXung(ActUtlType plc)
        {
            InitializeComponent();
            this.plc = plc;
        }
        private int ParseIntFromTextBox(TextBox textbox, int defaultValue = 0)
        {
            return int.TryParse(textbox.Text.Trim(), out int value) ? value : defaultValue;
        }

        private void guiGiaTri(string thanhGhi, int giaTri )
        {
            try
            {
                plc.SetDevice(thanhGhi, giaTri);
                MessageBox.Show($"✅ Đã gửi {giaTri} đến {thanhGhi} ", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Gửi không thành công!!!!: " + ex.Message);
            }
        }

        private void GiaTriTuPLC(string thanhGhi, TextBox textbox, out int bienKetQua)
        {
            bienKetQua = 0;
            try
            {
                plc.GetDevice(thanhGhi, out int value);
                textbox.Text = value.ToString();
                bienKetQua = value;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Không thể đọc từ PLC ({thanhGhi}): {ex.Message}");
            }
        }


        private void FormXung_Load(object sender, EventArgs e)
        {
            GiaTriTuPLC("D144", textBox1, out homeX);
            GiaTriTuPLC("D146", textBox2, out homeZ);
            GiaTriTuPLC("D142", textBox3, out pulZman);
            GiaTriTuPLC("D140", textBox4, out pulXman);
            GiaTriTuPLC("D136", textBox5, out pulZ);
            GiaTriTuPLC("D128", textBox6, out pulX);
            GiaTriTuPLC("D150", textBox12, out tonY);
            GiaTriTuPLC("D152", textBox11, out toffY);
            GiaTriTuPLC("D154", textBox10, out tonZ);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            homeX = ParseIntFromTextBox(textBox1);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            homeZ = ParseIntFromTextBox(textBox2);
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            pulXman = ParseIntFromTextBox(textBox4);
        }
        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            pulZman = ParseIntFromTextBox(textBox3);
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            pulX = ParseIntFromTextBox(textBox6);
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            pulZ = ParseIntFromTextBox(textBox5);
        }
        //

        private void textBox12_TextChanged_1(object sender, EventArgs e)
        {
            tonY = ParseIntFromTextBox(textBox12);
        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            toffY = ParseIntFromTextBox(textBox11);
        }
        private void textBox10_TextChanged_1(object sender, EventArgs e)
        {
            tonZ = ParseIntFromTextBox(textBox10);
        }





        private void button1_Click(object sender, EventArgs e)
        {
            guiGiaTri("D144", homeX);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            guiGiaTri("D146", homeZ);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            guiGiaTri("D142", pulZman);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            guiGiaTri("D140", pulXman);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            guiGiaTri("D136", pulZ);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            guiGiaTri("D128", pulX);
        }




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            guiGiaTri("D150", tonY);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            guiGiaTri("D152", toffY);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            guiGiaTri("D154", tonZ);
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            guiGiaTri("D154", tonZ);
        }


    }
}
