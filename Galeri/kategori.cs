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
    public partial class kategori : Form
    {
        public kategori()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0; Data Source=" + Application.StartupPath + "\\DB.accdb");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    throw new Exception("Lütfen bir ID girin.");
                }

                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into kategori (id,kategori) values ('" + textBox1.Text + "','" + textBox2.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                label3.Text = textBox2.Text + " kategorisi oluşturuldu";
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (OleDbException ex)
            {
                if (ex.ErrorCode == -2147467259)
                {
                    MessageBox.Show("Bu kategori zaten mevcut. Lütfen farklı bir kategori adı veya ID girin.");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kategori_Load(object sender, EventArgs e)
        {
            label3.Text = string.Empty;
        }
    }
}
