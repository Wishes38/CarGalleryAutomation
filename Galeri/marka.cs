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
    public partial class marka : Form
    {
        public marka()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection
            ("Provider=Microsoft.ACE.OLEDB.16.0; Data Source=" + Application.StartupPath + "\\DB.accdb");

        private void marka_Load(object sender, EventArgs e)
        {
            label3.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (textBox2.Text.Trim() == "")
                {
                    MessageBox.Show("Marka adı boş bırakılamaz.");
                    return;
                }

                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into marka (marka) values ('" + textBox2.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                label3.Text = textBox2.Text + " markası oluşturuldu";
                textBox2.Clear();
            }
            catch (OleDbException ex)
            {
                if (ex.ErrorCode == -2147467259)
                {
                    MessageBox.Show("Bu marka zaten mevcut. Lütfen farklı bir marka adı girin.");
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
