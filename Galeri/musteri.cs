using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Galeri
{
    public partial class musteri : Form
    {
        public musteri()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection
("Provider=Microsoft.ACE.OLEDB.16.0; Data Source=" + Application.StartupPath + "\\DB.accdb");


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void musteri_Load(object sender, EventArgs e)
        {
            label7.Text = string.Empty;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    throw new Exception("Lütfen geçerli bir ID girin.");
                }

                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into musteri (id,ad,soyad,adres,telefon,eposta) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                label7.Text = "Müşteri kaydedildi!";
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            catch (OleDbException ex)
            {
                if (ex.ErrorCode == -2147467259)
                {
                    MessageBox.Show("Bu müşteri zaten mevcut. Lütfen farklı bir id girin.");
                }
                else
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }


        }
    }
}
