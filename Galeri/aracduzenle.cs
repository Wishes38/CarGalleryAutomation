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
    public partial class aracduzenle : Form
    {
        public aracduzenle()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection
("Provider=Microsoft.ACE.OLEDB.16.0; Data Source=" + Application.StartupPath + "\\DB.accdb");


        private void aracduzenle_Load(object sender, EventArgs e)
        {
            label11.Text = string.Empty;

        }



        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand
                ("update arac set " +
                "id= '" + textBox1.Text + "'," +
                "kategori='" + comboBox1.Text + "', " +
                "marka='" + comboBox2.Text + "', " +
                "model='" + comboBox3.Text + "'," +
                "yil='" + comboBox4.Text + "'," +
                "yakit='" + comboBox5.Text + "'," +
                "vites='" + comboBox6.Text + "'," +
                "km='" + textBox2.Text + "'," +
                "renk='" + textBox3.Text + "'," +
                "gtarih='" + dateTimePicker1.Text + "'" +
                "where id='" + textBox1.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            label11.Text = textBox1.Text + " ID'li araç düzenlendi!";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            //aracduzenle_Load(sender, e);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            textBox2.Clear();
            textBox3.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from arac where id='" + textBox1.Text + "'", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Text = oku["kategori"].ToString();
                comboBox2.Text = oku["marka"].ToString();
                comboBox3.Text = oku["model"].ToString();
                comboBox4.Text = oku["yil"].ToString();
                comboBox5.Text = oku["yakit"].ToString();
                comboBox6.Text = oku["vites"].ToString();
                textBox2.Text = oku["km"].ToString();
                textBox3.Text = oku["renk"].ToString();
                dateTimePicker1.Text = oku["gtarih"].ToString();
            }
            baglanti.Close();
        }
    }
}
