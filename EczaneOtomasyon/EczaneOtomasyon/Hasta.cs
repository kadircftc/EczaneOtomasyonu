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
    public partial class Hasta : Form
    {

        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter dat;

        public Hasta()
        {
            InitializeComponent();
        }

        void HastaGetir()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-K34TCBL\\SQLEXPRESS;Initial Catalog=Eczane;Integrated Security=True");
            baglanti.Open();
            dat = new SqlDataAdapter("SELECT *FROM Hasta", baglanti);
            DataTable tablo = new DataTable();
            dat.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void Hasta_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eczaneDataSet.IlacYazmaIslemi' table. You can move, or remove it, as needed.
            this.ilacYazmaIslemiTableAdapter.Fill(this.eczaneDataSet.IlacYazmaIslemi);
            // TODO: This line of code loads data into the 'eczaneDataSet.Muayene' table. You can move, or remove it, as needed.
            this.muayeneTableAdapter.Fill(this.eczaneDataSet.Muayene);
            // TODO: This line of code loads data into the 'eczaneDataSet.Hasta' table. You can move, or remove it, as needed.
            this.hastaTableAdapter.Fill(this.eczaneDataSet.Hasta);
            // TODO: This line of code loads data into the 'eczaneDataSet.Doktor' table. You can move, or remove it, as needed.
            this.doktorTableAdapter.Fill(this.eczaneDataSet.Doktor);
            HastaGetir();

        }

        private void HastaKaydetButton_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu1 = "SELECT COUNT(*) FROM Hasta WHERE TCKimlikNO = @tcKimlikNo";
            SqlCommand komut1 = new SqlCommand(sorgu1, baglanti);
            komut1.Parameters.AddWithValue("@tcKimlikNo", HastaTcMasked.Text);
            int rowCount = (int)komut1.ExecuteScalar();

            if (rowCount == 0)
            {
                string sorgu = "INSERT INTO Hasta(Ad,Soyad,TCKimlikNO,Adres,Yas,DogumTarihi,HastaAileDoktorID) values (@ad,@soyad,@tc,@adres,@yas,@dogumTarihi,@AileDoktorID)";
                komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ad", HastaAdText.Text);
                komut.Parameters.AddWithValue("@soyad", HastaSoyadText.Text);
                komut.Parameters.AddWithValue("@tc", HastaTcMasked.Text);
                komut.Parameters.AddWithValue("@adres", HastaAdresText.Text);
                komut.Parameters.AddWithValue("@yas", HastaYasText.Text);
                komut.Parameters.AddWithValue("@dogumTarihi", DogumTarihiMasked.Text);
                komut.Parameters.AddWithValue("@AileDoktorID", HastaAileDoktoruIDCombo.Text);

                komut.ExecuteNonQuery();
                HastaGetir();
                MessageBox.Show("Hasta Kaydedildi!");
            }
            else
            {
                MessageBox.Show(HastaTcMasked.Text + " bu TC Kimlik numarasında kayıtlı bir hasta var.");
            }
            baglanti.Close();
        }

        private void Geributton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HastaIDText.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            HastaAdText.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            HastaSoyadText.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            HastaTcMasked.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            HastaAdresText.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            HastaYasText.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            DogumTarihiMasked.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            HastaAileDoktoruIDCombo.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

        }

        private void HastaSilButton_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM Hasta WHERE HastaID=@ıd";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ıd", Convert.ToInt32(HastaIDText.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            HastaGetir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu1 = "SELECT COUNT(*) FROM Hasta WHERE TCKimlikNO = @tcKimlikNo";
            SqlCommand komut5 = new SqlCommand(sorgu1, baglanti);
            komut5.Parameters.AddWithValue("@tcKimlikNo", maskedTextBox1.Text);
            int rowCount = (int)komut5.ExecuteScalar();

            if (rowCount == 0)
            {
                MessageBox.Show(maskedTextBox1.Text + " bu TC Kimlik numarasında kayıtlı bir hasta yok.");
            }
            else
            {
                SqlCommand komut = new SqlCommand("Select * From Hasta where TCKimlikNO like '%" + maskedTextBox1.Text + "%'", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                SqlCommand komut1 = new SqlCommand("select *from Muayene as mu inner join Hasta as h on h.HastaID=mu.MuayeneHastaID where h.TCKimlikNO like'%" + maskedTextBox1.Text + "%'", baglanti);
                SqlDataAdapter da1 = new SqlDataAdapter(komut1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                dataGridView2.DataSource = ds1.Tables[0];

                SqlCommand komut2 = new SqlCommand("select* from IlacYazmaIslemi as iy\r\ninner join Muayene as mu on mu.MuayeneID=iy.IlacYazmaMuayeneID\r\ninner join Hasta as h on h.HastaID=mu.MuayeneHastaID \r\nwhere h.TCKimlikNO like'%" + maskedTextBox1.Text + "%'", baglanti);
                SqlDataAdapter da2 = new SqlDataAdapter(komut2);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dataGridView3.DataSource = ds2.Tables[0];

                listView1.Items.Clear();
                SqlCommand komut3 = new SqlCommand("select h.TCKimlikNO, h.Ad,h.Soyad,mu.MuayeneTarih,do.Brans,i.Marka from Hasta as h \r\ninner join Muayene as mu on mu.MuayeneHastaID=h.HastaID\r\ninner join IlacYazmaIslemi as iy on iy.IlacYazmaMuayeneID=mu.MuayeneID\r\ninner join Ilac as i on i.IlacID=iy.IlacIlacID\r\ninner join Doktor as do on do.DoktorID=mu.MuayeneDoktorID\r\nwhere h.TCKimlikNO like '%" + maskedTextBox1.Text + "%'", baglanti);
                SqlDataReader oku = komut3.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem(oku["TCKimlikNO"].ToString());
                    ekle.SubItems.Add(oku["Ad"].ToString());
                    ekle.SubItems.Add(oku["Soyad"].ToString());
                    ekle.SubItems.Add(oku["MuayeneTarih"].ToString());
                    ekle.SubItems.Add(oku["Brans"].ToString());
                    ekle.SubItems.Add(oku["Marka"].ToString());

                    listView1.Items.Add(ekle);

                }
            }
                baglanti.Close();

                baglanti.Open();
                listView2.Items.Clear();
                SqlCommand komut4 = new SqlCommand("select do.Ad,do.Soyad from Hasta as h \r\ninner join Muayene as mu on mu.MuayeneHastaID=h.HastaID\r\ninner join IlacYazmaIslemi as iy on iy.IlacYazmaMuayeneID=mu.MuayeneID\r\ninner join Ilac as i on i.IlacID=iy.IlacIlacID\r\ninner join Doktor as do on do.DoktorID=mu.MuayeneDoktorID\r\nwhere h.TCKimlikNO like '%" + maskedTextBox1.Text + "%'", baglanti);
                SqlDataReader oku1 = komut4.ExecuteReader();
                while (oku1.Read())
                {
                    ListViewItem ekle1 = new ListViewItem(oku1["Ad"].ToString());
                    ekle1.SubItems.Add(oku1["Soyad"].ToString());


                    listView2.Items.Add(ekle1);
                }
            
            

            baglanti.Close();
        }
        
        private void TumHastalar_Click(object sender, EventArgs e)
        {
            HastaGetir();
        }

        private void Hasta_FormClosing(object sender, FormClosingEventArgs e)
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
