using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EczaneOtomasyon
{
    public partial class IlacFirmasi : Form
    {

        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter dat;

        public IlacFirmasi()
        {
            InitializeComponent();
        }

        private void GeributtonDoktor_Click(object sender, EventArgs e)
        {
            Ilac ılac = new Ilac();
            ılac.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        void IlacFirmasiGetir()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-K34TCBL\\SQLEXPRESS;Initial Catalog=Eczane;Integrated Security=True");
            baglanti.Open();
            dat = new SqlDataAdapter("SELECT *FROM IlacFirmasi", baglanti);
            DataTable tablo = new DataTable();
            dat.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        
        private void IlacFirmasi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eczaneDataSet.IlacFirmasiStok' table. You can move, or remove it, as needed.
            this.ilacFirmasiStokTableAdapter.Fill(this.eczaneDataSet.IlacFirmasiStok);
            // TODO: This line of code loads data into the 'eczaneDataSet.Ilac' table. You can move, or remove it, as needed.
            this.ilacTableAdapter.Fill(this.eczaneDataSet.Ilac);
            // TODO: This line of code loads data into the 'eczaneDataSet.IlacFirmasi' table. You can move, or remove it, as needed.
            this.ilacFirmasiTableAdapter.Fill(this.eczaneDataSet.IlacFirmasi);
            IlacFirmasiGetir();
            IlacGetir();
            IlacFirmasiStokGetir();
        }
        void IlacGetir()
        {
            baglanti.Open();
            listView1.Items.Clear();
            SqlCommand komut1 = new SqlCommand("Select IlacID,Marka From Ilac", baglanti);
            SqlDataReader oku = komut1.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem(oku["IlacID"].ToString());
                ekle.SubItems.Add(oku["Marka"].ToString());
                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        }
        private void IlacFirmasiKaydetButton_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO IlacFirmasi(IlacFirmasiAdi,Adres) values (@FirmaAdi,@Adres)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@FirmaAdi", IlacFirmasiAdText.Text);
            komut.Parameters.AddWithValue("@Adres", IlacFirmasiAdresText.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            IlacFirmasiGetir();
            MessageBox.Show("İlaç Firması Kaydedildi!");

            
        }

        private void IlacFirmasiGuncelleButton_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE IlacFirmasi SET IlacFirmasiAdi=@ad ,Adres=@adres WHERE IlacFirmasiID=@ıd";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ıd", Convert.ToInt32(IlacFirmasiIDText.Text));
            komut.Parameters.AddWithValue("@ad", IlacFirmasiAdText.Text);
            komut.Parameters.AddWithValue("@adres", IlacFirmasiAdresText.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            IlacFirmasiGetir();
        }
       

        private void IlacFirmasi_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            int firmaID = Convert.ToInt32(IlacFirmasiIDCombo.Text);
            int ilacid=Convert.ToInt32(IlacFirmasiIlacIDCombo.Text);
            string sorgu = "SELECT COUNT(*) FROM IlacFirmasiStok WHERE IlacFirmasiIlacFirmasiID = @firmaID AND IlacFirmasiIlacID=@ilacid";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@firmaID", firmaID);
            komut.Parameters.AddWithValue("@ilacid", ilacid);
            int rowCount = (int)komut.ExecuteScalar();

            if (rowCount == 0)
            {
                // İlaç firması stok tablosunda kayıt yok, yeni kayıt ekle
               string sorgu1 = "INSERT INTO IlacFirmasiStok(IlacFirmasiIlacFirmasiID, IlacFirmasiIlacID, IlacFirmasiMiktar) VALUES (@ilacFirmasiID, @ilacID, @miktar)";
                komut = new SqlCommand(sorgu1, baglanti);
                komut.Parameters.AddWithValue("@ilacFirmasiID", firmaID);
                komut.Parameters.AddWithValue("@ilacID", IlacFirmasiIlacIDCombo.Text);
                komut.Parameters.AddWithValue("@miktar", IlacFirmasiStokIlacAdetText.Text);
                
            }
            else
            {
                string sorgu2 = "UPDATE IlacFirmasiStok SET IlacFirmasiMiktar = IlacFirmasiMiktar + @miktar WHERE IlacFirmasiIlacFirmasiID = @ilacFirmasiID AND IlacFirmasiIlacID = @ilacID";
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@miktar", IlacFirmasiStokIlacAdetText.Text);
                komut.Parameters.AddWithValue("@ilacFirmasiID", IlacFirmasiIDCombo.Text);
                komut.Parameters.AddWithValue("@ilacID", IlacFirmasiIlacIDCombo.Text);
            }
            komut.ExecuteNonQuery();
            baglanti.Close();
            IlacFirmasiStokGetir();

        }

        void IlacFirmasiStokGetir()
        {
            baglanti.Open();
            dat = new SqlDataAdapter("SELECT *FROM IlacFirmasiStok", baglanti);
            DataTable tablo = new DataTable();
            dat.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IlacFirmasiIDText.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            IlacFirmasiAdText.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            IlacFirmasiAdresText.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE IlacFirmasiStok SET IlacFirmasiIlacFirmasiID=@ilacFirmasiID,IlacFirmasiMiktar=@miktarIlac,IlacFirmasiIlacID=@ilacID  WHERE IlacFirmasiStokID=@ıd";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ıd", Convert.ToInt32(IlacFirmasiStokIDText.Text));
            komut.Parameters.AddWithValue("@ilacFirmasiID", IlacFirmasiIDCombo.Text);
            komut.Parameters.AddWithValue("@miktarIlac", IlacFirmasiStokIlacAdetText.Text);
            komut.Parameters.AddWithValue("@ilacID", IlacFirmasiIlacIDCombo.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            IlacFirmasiStokGetir();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IlacFirmasiStokIDText.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            IlacFirmasiIDCombo.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            IlacFirmasiIlacIDCombo.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            IlacFirmasiStokIlacAdetText.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Visible=false;
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
    }
}
