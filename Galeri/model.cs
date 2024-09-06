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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Galeri
{
    public partial class model : Form
    {
        public model()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection
    ("Provider=Microsoft.ACE.OLEDB.16.0; Data Source=" + Application.StartupPath + "\\DB.accdb");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    throw new ArgumentException("Lütfen ID numarasını girin.");
                }

                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into model (id,model,marka_ad) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                label3.Text = textBox2.Text + " modeli oluşturuldu";
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (OleDbException ex)
            {
                if (ex.ErrorCode == -2147467259)
                {
                    MessageBox.Show("Bu ID numarası zaten kullanılıyor. Lütfen farklı bir ID numarası seçin.");
                }
                else
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }


        }

        private void model_Load(object sender, EventArgs e)
        {
            label3.Text = string.Empty;

            baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand
                ("select marka from marka", baglanti);
            OleDbDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                comboBox1.Items.Add(oku2["marka"].ToString());

            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
