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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Galeri
{
    public partial class anamenu : Form
    {
        
        public anamenu()
        {
            
            InitializeComponent();
            
        }

        OleDbConnection baglanti = new OleDbConnection
("Provider=Microsoft.ACE.OLEDB.16.0; Data Source=" + Application.StartupPath + "\\DB.accdb");
        DataTable tablo = new DataTable();

        private void anamenu_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            tablo.Clear();
            OleDbDataAdapter adap2 = new OleDbDataAdapter("select * from arac", baglanti);
            adap2.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 giris = new Form1();
            giris.Show();
            this.Hide();
        }

        private void satşYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form satisYap = new satisyap();
            satisYap.Show();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form yardim = new yardim();
            yardim.Show();
        }

        private void kategoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form kategori = new kategori();
            kategori.Show();
        }

        private void markaOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form mark = new marka();
            mark.Show();
        }

        private void modelOluştuırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form model = new model();
            model.Show();
        }

        private void kullanıcıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ke= new kullaniciekle();
            ke.Show();
        }

        private void müşteriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form musteri = new musteri();
            musteri.Show();
        }

        private void araçEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form arac = new aracekle();
            arac.Show();
        }

        private void araçSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form aracSil = new aracsil();
            aracSil.Show();
        }

        private void araçDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form aracDuzenle = new aracduzenle();
            aracDuzenle.Show();
        }

        private void aramaYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ara = new aramayap();
            ara.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
