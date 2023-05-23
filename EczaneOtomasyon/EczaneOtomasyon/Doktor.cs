using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneOtomasyon
{
    public partial class Doktor : Form
    {

        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter dat;


        public Doktor()
        {
            InitializeComponent();
        }


        void DoktorGetir()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-K34TCBL\\SQLEXPRESS;Initial Catalog=Eczane;Integrated Security=True");
            baglanti.Open();
            dat = new SqlDataAdapter("SELECT *FROM Doktor", baglanti);
            DataTable tablo = new DataTable();
            dat.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }



        private void Doktor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eczaneDataSet.Hasta' table. You can move, or remove it, as needed.
            this.hastaTableAdapter.Fill(this.eczaneDataSet.Hasta);
            // TODO: This line of code loads data into the 'eczaneDataSet.Muayene' table. You can move, or remove it, as needed.
            this.muayeneTableAdapter.Fill(this.eczaneDataSet.Muayene);
            // TODO: This line of code loads data into the 'eczaneDataSet.Ilac' table. You can move, or remove it, as needed.
            this.ilacTableAdapter.Fill(this.eczaneDataSet.Ilac);
            // TODO: This line of code loads data into the 'eczaneDataSet.IlacYazmaIslemi' table. You can move, or remove it, as needed.
            this.ilacYazmaIslemiTableAdapter.Fill(this.eczaneDataSet.IlacYazmaIslemi);
            // TODO: This line of code loads data into the 'eczaneDataSet.Doktor' table. You can move, or remove it, as needed.
            this.doktorTableAdapter.Fill(this.eczaneDataSet.Doktor);
            DoktorGetir();
            MuayeneGetir();
            IlacGetir();

        }

        private void GeributtonDoktor_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void DoktorKaydetButton_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string query = "SELECT COUNT(*) FROM Doktor WHERE TCKimlik = @tcKimlik";
            SqlCommand command = new SqlCommand(query, baglanti);
            command.Parameters.AddWithValue("@tcKimlik", DoktorTcmasked.Text);
            int rowCount = (int)command.ExecuteScalar();

            if (rowCount == 0)
            {
                string sorgu = "INSERT INTO Doktor(Ad,Soyad,TCKimlik,Brans,TecrubeYili) values (@ad,@soyad,@tc,@brans,@tecrubeyili)";
                komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ad", DoktorAdText.Text);
                komut.Parameters.AddWithValue("@soyad", DoktorSoyadText.Text);
                komut.Parameters.AddWithValue("@tc", DoktorTcmasked.Text);
                komut.Parameters.AddWithValue("@brans", DoktorBransText.Text);
                komut.Parameters.AddWithValue("@tecrubeyili", DoktorTecrubeText.Text);
                
                komut.ExecuteNonQuery();
                DoktorGetir();
                MessageBox.Show("Doktor Kaydedildi!");
            }
            else
            {
                MessageBox.Show(DoktorTcmasked.Text + " bu TC Kimlik numarasında kayıtlı bir doktor var.");
            }

            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DoktorIDText.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DoktorAdText.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            DoktorSoyadText.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            DoktorTcmasked.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            DoktorBransText.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            DoktorTecrubeText.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM Doktor WHERE DoktorID=@ıd";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ıd", Convert.ToInt32(DoktorIDText.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            DoktorGetir();
        }

        void MuayeneGetir()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-K34TCBL\\SQLEXPRESS;Initial Catalog=Eczane;Integrated Security=True");
            baglanti.Open();
            dat = new SqlDataAdapter("SELECT *FROM Muayene", baglanti);
            DataTable tablo = new DataTable();
            dat.Fill(tablo);
            dataGridView3.DataSource = tablo;
            baglanti.Close();
        }
       

        private void MuayeneKaydet_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO Muayene(MuayeneTarih,MuayeneHastaID,MuayeneDoktorID) values (@tarih,@hastaID,@DoktorID)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@tarih", dateTimePicker2.Value);
            komut.Parameters.AddWithValue("@hastaID", MuayeneHastaIDText.Text);
            komut.Parameters.AddWithValue("@DoktorID", MuayeneDoktorIDText.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MuayeneGetir();
            MessageBox.Show("Muayene Kaydedildi!");
        }
        void IlacGetir()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-K34TCBL\\SQLEXPRESS;Initial Catalog=Eczane;Integrated Security=True");
            baglanti.Open();
            dat = new SqlDataAdapter("SELECT *FROM IlacYazmaIslemi", baglanti);
            DataTable tablo = new DataTable();
            dat.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglanti.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO IlacYazmaIslemi(IlacYazimTarihi,IlacMiktari,IlacIlacID,IlacYazmaMuayeneID) values (@YazimTarihi,@IlacMiktar,@IlacID,@MuayeneID)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@YazimTarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@IlacMiktar", IlacMiktarıText.Text);
            komut.Parameters.AddWithValue("@IlacID", DoktorIlacID.Text);
            komut.Parameters.AddWithValue("@MuayeneID", MuayeneIDcomboBox.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            IlacGetir();
            MessageBox.Show("İlaç Yazımı Kaydedildi!");
        }

        private void Doktor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
