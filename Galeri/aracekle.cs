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
using System.Data.SqlTypes;
using System.Runtime.Remoting.Messaging;

namespace Galeri
{
    public partial class aracekle : Form
    {
        public aracekle()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection
("Provider=Microsoft.ACE.OLEDB.16.0; Data Source=" + Application.StartupPath + "\\DB.accdb");


        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void aracekle_Load(object sender, EventArgs e)
        {
            /*
            // yabancı anahtar bağlantısı için sorgu oluştur
            string query = "ALTER TABLE model ADD CONSTRAINT ad_marka FOREIGN KEY (marka_ad) REFERENCES marka(marka)";

            // bağlantıyı aç ve sorguyu çalıştır
            baglanti.Open();
            OleDbCommand command = new OleDbCommand(query, baglanti);
            command.ExecuteNonQuery();

            // bağlantıyı kapat
            baglanti.Close();*/

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand
                ("select kategori from kategori", baglanti);
            OleDbDataReader oku= komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["kategori"].ToString());
                
            }
            baglanti.Close();


            baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand
                ("select marka from marka", baglanti);
            OleDbDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                comboBox2.Items.Add(oku2["marka"].ToString());

            }
            baglanti.Close();

            /*
            baglanti.Open();
            OleDbCommand komut3 = new OleDbCommand
                ("select model from model", baglanti);
            OleDbDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                comboBox3.Items.Add(oku3["model"].ToString());

            }
            baglanti.Close();*/

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            baglanti.Open();
            OleDbCommand komut3 = new OleDbCommand(
                "select model from model where marka_ad= '" + comboBox2.Text + "'", baglanti);
            OleDbDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                comboBox3.Items.Add(oku3["model"].ToString());
            }
            baglanti.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen araç ID'si giriniz!");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    OleDbCommand komut = new OleDbCommand("insert into arac (id,kategori,marka,model,yil,yakit,vites,km,renk,gtarih) values ('" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + comboBox6.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "')", baglanti);
                    komut.ExecuteNonQuery();
                    label11.Text = "Araç kaydedildi!";
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    /*comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    comboBox3.SelectedIndex = -1;
                    comboBox4.SelectedIndex = -1;
                    comboBox5.SelectedIndex = -1;
                    comboBox6.SelectedIndex = -1;*/

                }
                catch (OleDbException ex)
                {
                    if (ex.ErrorCode == -2147467259) //duplicate primary key error code
                    {
                        MessageBox.Show("Bu ID ile kayıtlı araç zaten var!");
                    }
                    else
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
                finally
                {
                    baglanti.Close();
                    //aracekle_Load(sender, e);
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        { 
        }
    }
}
