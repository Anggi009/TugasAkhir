using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Linq.Expressions;

namespace TugasAkhir
{
    public partial class Form1 : Form
    {

        public bool isNumber(char ch, string text) //INI BUAT BIAR TEXTBOXNYA CUMAN BISA DIMASUKIN ANGKA
        {
            bool res = true;
            char decimalChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            //check if it´s a decimal separator and if doesn´t already have one in the text string
            if (ch == decimalChar && text.IndexOf(decimalChar) != -1)
            {
                res = false;
                return res;
            }

            //check if it´s a digit, decimal separator and backspace
            if (!Char.IsDigit(ch) && ch != decimalChar && ch != (char)Keys.Back)
                res = false;

            return res;
        }


        int harga, total, total1, totalall, jumlah;

        private void button3_Click(object sender, EventArgs e) ////TOTAL
        {
            totalall = total + total1;

            textBox5.Text += ("\r\n\r\n\r\n Total\t:" + totalall);
        }

        private void button4_Click(object sender, EventArgs e) ///RESET
        {
            label14.Text = string.Empty;
            label15.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox5.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isNumber(e.KeyChar, textBox2.Text))
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isNumber(e.KeyChar, textBox3.Text))
                e.Handled = true;
        }

        private void button5_Click(object sender, EventArgs e) //BUAT BUKA FORM2
        {
            Form2 open = new Form2();
            open.Show();
        }

        private void button1_Click(object sender, EventArgs e) //PERSEGI
        {
            try
            {
                Class1 gs = new Class1();
                int bahan1 = comboBox1.SelectedIndex;
                int ukuran1 = comboBox2.SelectedIndex;
                int warna1 = comboBox3.SelectedIndex;
                gs.setbahan(bahan1);
                gs.setukuran(ukuran1);
                gs.setwarna(warna1);

                string bahan = comboBox1.GetItemText(comboBox1.SelectedItem);
                string ukuran = comboBox2.GetItemText(comboBox2.SelectedItem);
                string warna = comboBox3.GetItemText(comboBox3.SelectedItem);

                jumlah = int.Parse(textBox2.Text);

                switch (gs.getbahan())
                {
                    case 0: hargabahan = 15000; break;
                    case 1: hargabahan = 20000; break;
                    case 2: hargabahan = 25000; break;
                }

                switch (gs.getukuran())
                {
                    case 0: hargaukuran = 3000; break;
                    case 1: hargaukuran = 4000; break;
                    case 2: hargaukuran = 5000; break;
                }

                harga = hargabahan + hargaukuran;
                label15.Text = ("" + harga);

                total = harga * jumlah;

                if (string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    textBox5.Text = ("Jilbab Pesegi" + "\r\n\r\nBahan\t:" + bahan + "\r\nUkuran\t:" + ukuran + "\r\nWarna\t:" + warna + "\r\nJumlah\t:" + jumlah + "\r\nTotal\t:" + total);
                }
                else
                {
                    textBox5.Text += ("\r\n\r\n\r\nJilbab Pesegi" + "\r\n\r\nBahan\t:" + bahan + "\r\nUkuran\t:" + ukuran + "\r\nWarna\t:" + warna + "\r\nJumlah\t:" + jumlah + "\r\nTotal\t:" + total);
                }
            }
            catch
            {
                MessageBox.Show("Jangan Ada yang kosong yaa!!!");
            }

        }

        int hargabahan = 0, hargaukuran = 0, hargawarna = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)  //INSTAN
        {
            try
            {
                Class1 gs = new Class1();
                int bahan1 = comboBox6.SelectedIndex;
                int ukuran1 = comboBox5.SelectedIndex;
                int warna1 = comboBox4.SelectedIndex;
                gs.setbahan(bahan1);
                gs.setukuran(ukuran1);
                gs.setwarna(warna1);

                string bahan = comboBox6.GetItemText(comboBox6.SelectedItem);
                string ukuran = comboBox5.GetItemText(comboBox5.SelectedItem);
                string warna = comboBox4.GetItemText(comboBox4.SelectedItem);

                jumlah = int.Parse(textBox3.Text);

                switch (gs.getbahan())
                {
                    case 0: hargabahan = 15000; break;
                    case 1: hargabahan = 20000; break;
                    case 2: hargabahan = 25000; break;
                }

                switch (gs.getukuran())
                {
                    case 0: hargaukuran = 3000; break;
                    case 1: hargaukuran = 4000; break;
                    case 2: hargaukuran = 5000; break;
                }

                harga = hargabahan + hargaukuran;
                label14.Text = ("" + harga);

                total1 = harga * jumlah;

                if (string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    textBox5.Text = ("Jilbab Instan" + "\r\n\r\nBahan\t:" + bahan + "\r\nUkuran\t:" + ukuran + "\r\nWarna\t:" + warna + "\r\nJumlah\t:" + jumlah + "\r\nTotal\t:" + total1);
                }
                else
                {
                    textBox5.Text += ("\r\n\r\n\r\nJilbab Instan" + "\r\n\r\nBahan\t:" + bahan + "\r\nUkuran\t:" + ukuran + "\r\nWarna\t:" + warna + "\r\nJumlah\t:" + jumlah + "\r\nTotal\t:" + total1);
                }
            }
            catch
            {
                MessageBox.Show("Jangan Ada yang kosong yaa!!!");
            }

        }
    }
}

