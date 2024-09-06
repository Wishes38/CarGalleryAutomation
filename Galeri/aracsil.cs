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
    public partial class aracsil : Form
    {
        public aracsil()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection
("Provider=Microsoft.ACE.OLEDB.16.0; Data Source=" + Application.StartupPath + "\\DB.accdb");


        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("delete from arac where id = '" + textBox1.Text+"'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            label5.Text = $"{textBox1.Text} ID'li Araç Silindi!";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void aracsil_Load(object sender, EventArgs e)
        {
            label5.Text=string.Empty;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from arac where id='"+ textBox1.Text+ "'",baglanti);
            OleDbDataReader oku=komut.ExecuteReader();
            while(oku.Read())
            {
                textBox2.Text = oku["marka"].ToString();
                textBox3.Text = oku["model"].ToString();
            }
            baglanti.Close();
        }
    }
}
