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
    public partial class satisyap : Form
    {
        public satisyap()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection
("Provider=Microsoft.ACE.OLEDB.16.0; Data Source=" + Application.StartupPath + "\\DB.accdb");
        DataTable tablo = new DataTable();
        DataTable tablo2 = new DataTable();

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox8.Clear();
            textBox7.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand(
                "select * from musteri where id = '"+textBox9.Text+"'",baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBox8.Text = oku["ad"].ToString();
                textBox7.Text = oku["soyad"].ToString();
                textBox4.Text = oku["adres"].ToString();
                textBox5.Text = oku["telefon"].ToString();
                textBox6.Text = oku["eposta"].ToString();
            }
            baglanti.Close();

        }

        private void satisyap_Load(object sender, EventArgs e)
        {
            label16.Text = string.Empty;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            textBox2.Clear();
            textBox3.Clear();

            baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand(
                "select * from arac where id = '" + textBox1.Text + "'", baglanti);
            OleDbDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                comboBox1.Text = oku2["kategori"].ToString();
                comboBox2.Text = oku2["marka"].ToString();
                comboBox3.Text = oku2["model"].ToString();
                comboBox4.Text = oku2["yil"].ToString();
                comboBox5.Text = oku2["yakit"].ToString();
                comboBox6.Text = oku2["vites"].ToString();
                textBox2.Text = oku2["km"].ToString();
                textBox3.Text = oku2["renk"].ToString();

            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand(
                "insert into satis (" +
                "musteri_id," +
                "ad," +
                "soyad," +
                "adres," +
                "telefon," +
                "eposta," +
                "arac_id," +
                "kategori," +
                "marka," +
                "model," +
                "yil," +
                "yakit," +
                "vites," +
                "km," +
                "renk," +
                "starih) values(" +
                "'"+textBox9.Text+"'," +
                "'"+textBox8.Text+"'," +
                "'"+ textBox7.Text + "'," +
                "'"+ textBox4.Text + "'," +
                "'"+ textBox5.Text + "'," +
                "'"+ textBox6.Text + "'," +
                "'"+ textBox1.Text + "'," +
                "'"+comboBox1.Text+"'," +
                "'"+ comboBox2.Text + "'," +
                "'"+ comboBox3.Text + "'," +
                "'"+ comboBox4.Text + "'," +
                "'"+ comboBox5.Text + "'," +
                "'"+ comboBox6.Text + "'," +
                "'"+ textBox2.Text + "'," +
                "'"+ textBox3.Text + "'," +
                "'"+ dateTimePicker1.Text +"')",baglanti);
            komut.ExecuteNonQuery();

            OleDbCommand komut2 = new OleDbCommand("delete from arac where id = '" + textBox1.Text + "'", baglanti);
            komut2.ExecuteNonQuery();

            label16.Text = "Satış tamamlandı!";
            baglanti.Close();


            /*baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand(
                "select * from arac where id = '" + textBox1.Text + "'", baglanti);
            OleDbDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {


            }
            baglanti.Close();*/

        }
    }
}
