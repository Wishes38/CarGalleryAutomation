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
    public partial class kullaniciekle : Form
    {
        public kullaniciekle()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection
    ("Provider=Microsoft.ACE.OLEDB.16.0; Data Source=" + Application.StartupPath + "\\DB.accdb");


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void kullaniciekle_Load(object sender, EventArgs e)
        {
            label5.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Lütfen id alanını doldurunuz.");
                return;
            }

            try
            {
                baglanti.Open();
                OleDbCommand komut2 = new OleDbCommand("insert into kullanici_bilgi (id,sifre,adsoyad,unvan) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", baglanti);
                komut2.ExecuteNonQuery();
                label5.Text = "Kullanıcı kaydedildi!";
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            catch (OleDbException ex)
            {
                if (ex.ErrorCode == -2147467259)
                {
                    MessageBox.Show("Bu kullanıcı zaten mevcut. Lütfen farklı bir id girin.");
                }
                else
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
            finally
            {
                baglanti.Close();
            }


        }
    }
}
