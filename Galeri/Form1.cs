using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Galeri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection
            ("Provider=Microsoft.ACE.OLEDB.16.0; Data Source="+Application.StartupPath+ "\\DB.accdb");

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" && textBox2.Text=="")
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz");
            }
            else if (textBox1.Text=="")
            {
                MessageBox.Show("Lütfen ID'nizi giriniz");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen şifrenizi giriniz");
            }
            else
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand
                    ("select * from kullanici_bilgi where id='"+textBox1.Text+"'",baglanti);
                OleDbDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.Read() == true)
                {
                    if (textBox1.Text == okuyucu["id"].ToString() && textBox2.Text == okuyucu["sifre"].ToString())
                    {
                        MessageBox.Show("Hoşgeldiniz Sayın " + okuyucu["adsoyad"].ToString());
                        Form frm1 = new anamenu();
                        frm1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı giriş yapıldı!, lütfen tekrar deneyiniz");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen giriş bilgilerinizi kontrol ediniz");
                }
                baglanti.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
