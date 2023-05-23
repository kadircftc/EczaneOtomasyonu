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
    public partial class Eczane : Form
    {

        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter dat;


        public Eczane()
        {
            InitializeComponent();
        }

        private void Eczane_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eczaneDataSet2.EczaneStok' table. You can move, or remove it, as needed.
            this.eczaneStokTableAdapter1.Fill(this.eczaneDataSet2.EczaneStok);
            // TODO: This line of code loads data into the 'eczaneDataSet.IlacFirmasi' table. You can move, or remove it, as needed.
            this.ilacFirmasiTableAdapter.Fill(this.eczaneDataSet.IlacFirmasi);
            // TODO: This line of code loads data into the 'eczaneDataSet.Ilac' table. You can move, or remove it, as needed.
            this.ilacTableAdapter.Fill(this.eczaneDataSet.Ilac);
            // TODO: This line of code loads data into the 'eczaneDataSet.IlacTedarik' table. You can move, or remove it, as needed.
            this.ilacTedarikTableAdapter.Fill(this.eczaneDataSet.IlacTedarik);
            // TODO: This line of code loads data into the 'eczaneDataSet.IlacYazmaIslemi' table. You can move, or remove it, as needed.
            this.ilacYazmaIslemiTableAdapter.Fill(this.eczaneDataSet.IlacYazmaIslemi);
            // TODO: This line of code loads data into the 'eczaneDataSet.IlacSatis' table. You can move, or remove it, as needed.
            this.ilacSatisTableAdapter.Fill(this.eczaneDataSet.IlacSatis);
            // TODO: This line of code loads data into the 'eczaneDataSet1.EczaneStok' table. You can move, or remove it, as needed.
            this.eczaneStokTableAdapter.Fill(this.eczaneDataSet1.EczaneStok);
            // TODO: This line of code loads data into the 'eczaneDataSet.EczaneTelefon' table. You can move, or remove it, as needed.
            this.eczaneTelefonTableAdapter.Fill(this.eczaneDataSet.EczaneTelefon);
            // TODO: This line of code loads data into the 'eczaneDataSet.Eczane' table. You can move, or remove it, as needed.
            this.eczaneTableAdapter.Fill(this.eczaneDataSet.Eczane);
            EczaneGetir();
            IlacSatisGetir();
        }

        private void GeributtonDoktor_Click(object sender, EventArgs e)
        {
            Form1 form1=new Form1();    
            form1.Show();
            this.Hide();
        }

        void EczaneGetir()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-K34TCBL\\SQLEXPRESS;Initial Catalog=Eczane;Integrated Security=True");
            baglanti.Open();
            dat = new SqlDataAdapter("SELECT *FROM Eczane", baglanti);
            DataTable tablo = new DataTable();
            dat.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO Eczane(EczaneAdi,EczaneAdresi) values (@ad,@adres)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ad", EczaneAdText.Text);
            komut.Parameters.AddWithValue("@adres", EczaneAdresText.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            EczaneGetir();
            MessageBox.Show("Eczane Kaydedildi!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EczaneIDText.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            EczaneAdText.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            EczaneAdresText.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM Eczane WHERE EczaneID=@ıd";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ıd", Convert.ToInt32(EczaneIDText.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            EczaneGetir();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("Select * From EczaneStok where EczabeStokEczaneID like '%" + EczaneStokDurumText.Text + "%'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView4.DataSource = ds.Tables[0];

            baglanti.Close();
        }
        void IlacSatisGetir()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-K34TCBL\\SQLEXPRESS;Initial Catalog=Eczane;Integrated Security=True");
            baglanti.Open();
            dat = new SqlDataAdapter("SELECT *FROM IlacSatis", baglanti);
            DataTable tablo = new DataTable();
            dat.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglanti.Close();
        }
        

        private void button6_Click(object sender, EventArgs e)
        {
            int fiyat = Convert.ToInt32(textBox4.Text);
            int satisEczaneID = Convert.ToInt32(EczaneIlacSatiscombo.Text);
            int satisIlacYazimiID = Convert.ToInt32(EczaneIlacSatisIlacYazimcombo.Text);

            

            
            baglanti.Open();

             
                
            

            // Stok kontrolü
            int ilacYazmaID = satisIlacYazimiID;
            string ilacMiktariSorgu = "select IlacMiktari from IlacYazmaIslemi where IlacYazmaID=@ilacYazmaID";
            SqlCommand ilacMiktarKomut=new SqlCommand(ilacMiktariSorgu, baglanti);
            ilacMiktarKomut.Parameters.AddWithValue("@ilacYazmaID", satisIlacYazimiID);
            int ilacMiktari = Convert.ToInt32(ilacMiktarKomut.ExecuteScalar());

            
            

            // EczaneStok tablosundan EczaneStokIlacAdedi'ni çekme sorgusu
            string stokSorgusu = "SELECT EczaneStokIlacAdedi FROM EczaneStok WHERE EczaneStokIlacID =(select IlacIlacID from IlacYazmaIslemi where IlacYazmaID=@IlacYazmaID) AND EczabeStokEczaneID = @SatisEczaneID";
            SqlCommand komut1 = new SqlCommand(stokSorgusu, baglanti);
            komut1.Parameters.AddWithValue("@IlacYazmaID", ilacYazmaID);
            komut1.Parameters.AddWithValue("@SatisEczaneID", satisEczaneID);
            int eczaneStokAdedi = Convert.ToInt32(komut1.ExecuteScalar());

            if (ilacMiktari > eczaneStokAdedi)
            {

                 MessageBox.Show("Stokta yeterli miktarda ilaç bulunmamaktadır.");
                 
            }
            else 
            {
                // İlacSatis tablosuna kayıt ekleme sorgusu
                string ilacSatisQuery = "INSERT INTO IlacSatis (Fiyat, SatisEczaneID, SatisIlacYazımıID) VALUES (@Fiyat, @SatisEczaneID, @SatisIlacYazimiID)";

                SqlCommand komut = new SqlCommand(ilacSatisQuery, baglanti);

                komut.Parameters.AddWithValue("@Fiyat", fiyat);
                komut.Parameters.AddWithValue("@SatisEczaneID", satisEczaneID);
                komut.Parameters.AddWithValue("@SatisIlacYazimiID", satisIlacYazimiID);

                komut.ExecuteNonQuery();
                // Stoktan ilacı düşme sorgusu
                string stokDusurQuery = "UPDATE EczaneStok SET EczaneStokIlacAdedi = EczaneStokIlacAdedi - @IlacMiktari WHERE EczaneStokIlacID = (select IlacIlacID from IlacYazmaIslemi where IlacYazmaID=@IlacYazmaID) AND EczabeStokEczaneID = @SatisEczaneID";

            SqlCommand komut2= new SqlCommand(stokDusurQuery, baglanti);
            komut2.Parameters.AddWithValue("@IlacMiktari", ilacMiktari);
            komut2.Parameters.AddWithValue("@IlacYazmaID", ilacYazmaID);
            komut2.Parameters.AddWithValue("@SatisEczaneID", satisEczaneID);

            komut2.ExecuteNonQuery();
            }

            baglanti.Close();
            IlacSatisGetir();
            EczaneStokGetir();

            //baglanti.Open();
            //int fiyat =Convert.ToInt32(textBox4.Text);
            //int eczaneID= Convert.ToInt32(EczaneIlacSatiscombo.Text); 
            //int ilacYazimiID= Convert.ToInt32(EczaneIlacSatisIlacYazimcombo.Text);
            //string sorgu = "INSERT INTO IlacSatis(Fiyat,SatisEczaneID,SatisIlacYazımıID) values(@fiyat,@eczaneID,@ilacYazimiID)";
            //SqlCommand komut = new SqlCommand(sorgu, baglanti);
            //komut.Parameters.AddWithValue("@fiyat", textBox4.Text);
            //komut.Parameters.AddWithValue("@eczaneID", EczaneIlacSatiscombo.Text);
            //komut.Parameters.AddWithValue("@ilacYazimiID", EczaneIlacSatisIlacYazimcombo.Text);
            //komut.ExecuteNonQuery();

            ////İlaçYazım tablosundaki ilaç miktarı eczane stoğunda yeterli sayıda var mı?
            //string sorgu2 = "select IlacMiktari from IlacYazmaIslemi where IlacYazmaID=@ilacYazimiID";
            //string sorgu3 = "select EczaneStokIlacAdedi from EczaneStok where EczabeStokEczaneID=@eczaneID and EczaneStokIlacID = (select IlacIlacID from IlacYazmaIslemi where IlacYazmaID = @ilacYazimiID";
            //SqlCommand komut3 = new SqlCommand(sorgu3, baglanti);
            //SqlCommand komut2=new SqlCommand(sorgu2, baglanti);
            //komut2.Parameters.AddWithValue("@ilacYazimiID", EczaneIlacSatisIlacYazimcombo.Text);
            //komut2.ExecuteNonQuery();
            //if (Convert.ToInt32(sorgu3)>= Convert.ToInt32(sorgu2))
            //{
            //    string sorgu1 = "Update EczaneStok Set EczaneStokIlacAdedi=EczaneStokIlacAdedi-(select IlacMiktari from IlacYazmaIslemi where IlacYazmaID=@ilacYazimiID) where EczabeStokEczaneID = @eczaneID and EczaneStokIlacID = (select IlacIlacID from IlacYazmaIslemi where IlacYazmaID = @ilacYazimiID)";
            //    SqlCommand komut1 = new SqlCommand(sorgu1, baglanti);
            //    komut1.ExecuteNonQuery();
            //}
            //else
            //{
            //    MessageBox.Show("Satışı yapılacak ilaç miktarından seçilen eczane stoğunda yeteri adette yyoktur.");
            //}


            //baglanti.Close();
            //IlacSatisGetir();
            //EczaneStokGetir();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM IlacSatis WHERE SatisID=@id";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            IlacSatisGetir();
        }
        void EczaneStokGetir()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-K34TCBL\\SQLEXPRESS;Initial Catalog=Eczane;Integrated Security=True");
            baglanti.Open();
            dat = new SqlDataAdapter("SELECT *FROM EczaneStok", baglanti);
            DataTable tablo = new DataTable();
            dat.Fill(tablo);
            dataGridView4.DataSource = tablo;
            baglanti.Close();
        }
        void IlacTedarikGetir()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-K34TCBL\\SQLEXPRESS;Initial Catalog=Eczane;Integrated Security=True");
            baglanti.Open();
            dat = new SqlDataAdapter("SELECT *FROM IlacTedarik", baglanti);
            DataTable tablo = new DataTable();
            dat.Fill(tablo);
            dataGridView3.DataSource = tablo;
            baglanti.Close();

        }
        private void button7_Click(object sender, EventArgs e)
        {
            int ilacTedarikMiktar = int.Parse(IlacAdetText.Text);
            int ilacTedarikIlacFirmasiID = int.Parse(TedarikIlacFİrmasıIDText.Text);
            int ilacTedarikIlacID = int.Parse(IlaçTedarikIlacIDText.Text);
            int ilacTedarikEczaneID = int.Parse(comboBox2.Text);

            int ilacFirmasiMiktar = GetIlacFirmasiMiktar(ilacTedarikIlacFirmasiID, ilacTedarikIlacID);

            if (ilacFirmasiMiktar >= ilacTedarikMiktar)
            {
                int updatedIlacFirmasiMiktar = ilacFirmasiMiktar - ilacTedarikMiktar;
                int updatedEczaneStokIlacAdedi = GetEczaneStokIlacAdedi(ilacTedarikEczaneID, ilacTedarikIlacID) + ilacTedarikMiktar;
                baglanti.Open();

                try
                {
                        // IlacFirmasiStok tablosundan ilaç miktarını güncelle
                        string updateIlacFirmasiStokQuery = "UPDATE IlacFirmasiStok SET IlacFirmasiMiktar = @UpdatedIlacFirmasiMiktar " +
                            "WHERE IlacFirmasiIlacFirmasiID = @IlacFirmasiIlacFirmasiID AND IlacFirmasiIlacID = @IlacFirmasiIlacID";
                        SqlCommand updateIlacFirmasiStokCommand = new SqlCommand(updateIlacFirmasiStokQuery, baglanti);
                        updateIlacFirmasiStokCommand.Parameters.AddWithValue("@UpdatedIlacFirmasiMiktar", updatedIlacFirmasiMiktar);
                        updateIlacFirmasiStokCommand.Parameters.AddWithValue("@IlacFirmasiIlacFirmasiID", ilacTedarikIlacFirmasiID);
                        updateIlacFirmasiStokCommand.Parameters.AddWithValue("@IlacFirmasiIlacID", ilacTedarikIlacID);
                        updateIlacFirmasiStokCommand.ExecuteNonQuery();

                    // EczaneStok tablosunda ilacı güncelle veya ekle
                    try
                    {
                        
                            

                            // EczaneStok tablosunda kayıt kontrolü yap
                            string checkRecordQuery = "SELECT COUNT(*) FROM EczaneStok WHERE EczaneStokIlacID = @IlacID AND EczabeStokEczaneID = @EczaneID";
                            SqlCommand checkRecordCommand = new SqlCommand(checkRecordQuery, baglanti);
                            checkRecordCommand.Parameters.AddWithValue("@IlacID", ilacTedarikIlacID);
                            checkRecordCommand.Parameters.AddWithValue("@EczaneID", ilacTedarikEczaneID);
                            int recordCount = (int)checkRecordCommand.ExecuteScalar();

                            if (recordCount == 0)
                            {
                                // EczaneStok tablosuna yeni kayıt ekle
                                string insertQuery = "INSERT INTO EczaneStok (EczaneStokIlacID, EczaneStokIlacAdedi, EczabeStokEczaneID) " +
                                    "VALUES (@IlacID, @IlacAdedi, @EczaneID)";
                                SqlCommand insertCommand = new SqlCommand(insertQuery, baglanti);
                                insertCommand.Parameters.AddWithValue("@IlacID", ilacTedarikIlacID);
                                insertCommand.Parameters.AddWithValue("@IlacAdedi", ilacTedarikMiktar);
                                insertCommand.Parameters.AddWithValue("@EczaneID", ilacTedarikEczaneID);
                                insertCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                // EczaneStok tablosundaki ilaç adedini güncelle
                                string updateQuery = "UPDATE EczaneStok SET EczaneStokIlacAdedi = EczaneStokIlacAdedi + @IlacAdedi " +
                                    "WHERE EczaneStokIlacID = @IlacID AND EczabeStokEczaneID = @EczaneID";
                                SqlCommand updateCommand = new SqlCommand(updateQuery, baglanti);
                                updateCommand.Parameters.AddWithValue("@IlacAdedi", ilacTedarikMiktar);
                                updateCommand.Parameters.AddWithValue("@IlacID", ilacTedarikIlacID);
                                updateCommand.Parameters.AddWithValue("@EczaneID", ilacTedarikEczaneID);
                                updateCommand.ExecuteNonQuery();
                            }

                            
                        

                        MessageBox.Show("İşlem başarıyla tamamlandı.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata oluştu: " + ex.Message);
                    }

                    // IlacTedarik tablosuna yeni kayıt ekle
                    string insertIlacTedarikQuery = "INSERT INTO IlacTedarik (IlacTedarikMiktar, IlacTedarikIlacFirmasiID, IlacTedarikIlacID, IlacTedarikEczaneID) " +
                            "VALUES (@IlacTedarikMiktar, @IlacTedarikIlacFirmasiID, @IlacTedarikIlacID, @IlacTedarikEczaneID)";
                        SqlCommand insertIlacTedarikCommand = new SqlCommand(insertIlacTedarikQuery, baglanti);
                        insertIlacTedarikCommand.Parameters.AddWithValue("@IlacTedarikMiktar", ilacTedarikMiktar);
                        insertIlacTedarikCommand.Parameters.AddWithValue("@IlacTedarikIlacFirmasiID", ilacTedarikIlacFirmasiID);
                        insertIlacTedarikCommand.Parameters.AddWithValue("@IlacTedarikIlacID", ilacTedarikIlacID);
                        insertIlacTedarikCommand.Parameters.AddWithValue("@IlacTedarikEczaneID", ilacTedarikEczaneID);
                        insertIlacTedarikCommand.ExecuteNonQuery();

                        
                    

                    MessageBox.Show("Kayıt başarıyla eklendi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu:1 " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Stok yeterli değil.");
            }
            baglanti.Close();
            EczaneStokGetir();
            IlacTedarikGetir();
        }

        private int GetIlacFirmasiMiktar(int ilacFirmasiID, int ilacID)
        {
            int ilacFirmasiMiktar = 0;

            try
            {
                
                    baglanti.Open();

                    string query = "SELECT IlacFirmasiMiktar FROM IlacFirmasiStok WHERE IlacFirmasiIlacFirmasiID = @IlacFirmasiIlacFirmasiID " +
                        "AND IlacFirmasiIlacID = @IlacFirmasiIlacID";
                    SqlCommand command = new SqlCommand(query, baglanti);
                    command.Parameters.AddWithValue("@IlacFirmasiIlacFirmasiID", ilacFirmasiID);
                    command.Parameters.AddWithValue("@IlacFirmasiIlacID", ilacID);
                    object result = command.ExecuteScalar();

                    if (result != null)
                        ilacFirmasiMiktar = Convert.ToInt32(result);

                    baglanti.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:2 " + ex.Message);
            }

            return ilacFirmasiMiktar;
        }

        private int GetEczaneStokIlacAdedi(int eczaneID, int ilacID)
        {
            int eczaneStokIlacAdedi = 0;

            try
            {
                
                    baglanti.Open();

                    string query = "SELECT EczaneStokIlacAdedi FROM EczaneStok WHERE EczaneStokIlacID = @EczaneStokIlacID " +
                        "AND EczabeStokEczaneID = @EczaneStokEczaneID";
                    SqlCommand command = new SqlCommand(query, baglanti);
                    command.Parameters.AddWithValue("@EczaneStokIlacID", ilacID);
                    command.Parameters.AddWithValue("@EczaneStokEczaneID", eczaneID);
                    object result = command.ExecuteScalar();

                    if (result != null)
                        eczaneStokIlacAdedi = Convert.ToInt32(result);

                    baglanti.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:3 " + ex.Message);
            }

            return eczaneStokIlacAdedi;
        }

        private bool IsEczaneStokIlacExists(int eczaneID, int ilacID)
        {
            bool exists = false;

            try
            {

                baglanti.Open();

                string query = "SELECT COUNT(*) FROM EczaneStok WHERE EczaneStokIlacID = @EczaneStokIlacID " +
                    "AND EczabeStokEczaneID = @EczaneStokEczaneID";
                SqlCommand command = new SqlCommand(query, baglanti);
                command.Parameters.AddWithValue("@EczaneStokIlacID", ilacID);
                command.Parameters.AddWithValue("@EczaneStokEczaneID", eczaneID);
                int count = (int)command.ExecuteScalar();

                if (count > 0)
                    exists = true;

                baglanti.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:4 " + ex.Message);
            }

            return exists;
        





        



            //baglanti.Open();
            //int miktar = Convert.ToInt32(IlacAdetText.Text);
            //int firmaID= Convert.ToInt32(TedarikIlacFİrmasıIDText.Text);
            //int IlacID = Convert.ToInt32(IlaçTedarikIlacIDText.Text);
            //int eczaneID = Convert.ToInt32(comboBox2.Text);

            //string sorgu = "if @miktar>(select IlacFirmasiMiktar from IlacFirmasiStok as ifs where ifs.IlacFirmasiIlacID=@IlacID AND ifs.IlacFirmasiIlacFirmasiID=@firmaID)\r\nbegin \r\n print('istediğin adetten stokta yok.')   \r\nend\r\nelse\r\nbegin\r\ninsert into IlacTedarik(IlacTedarikMiktar,IlacTedarikIlacFirmasiID,IlacTedarikIlacID,IlacTedarikEczaneID) values (@miktar,@firmaID,@IlacID,@eczaneID)\r\ninsert into EczaneStok(EczaneStokIlacID,EczaneStokIlacAdedi,EczabeStokEczaneID) values(@IlacID,@miktar,@eczaneID)\r\nupdate IlacFirmasiStok set IlacFirmasiMiktar=IlacFirmasiMiktar-@miktar where IlacFirmasiIlacID=@IlacID and IlacFirmasiIlacFirmasiID=@firmaID\r\nend";
            //SqlCommand komut = new SqlCommand(sorgu, baglanti);
            //komut.Parameters.AddWithValue("@miktar", IlacAdetText.Text);
            //komut.Parameters.AddWithValue("@firmaID", TedarikIlacFİrmasıIDText.Text);
            //komut.Parameters.AddWithValue("@IlacID", IlaçTedarikIlacIDText.Text);
            //komut.Parameters.AddWithValue("@eczaneID", TedarikIlacFİrmasıIDText.Text);
            //komut.ExecuteNonQuery();
            //baglanti.Close();

            //IlacTedarikGetir();
            //EczaneStokGetir();

        }

        private void IlacTedarikEtmeIslemleriSilButton_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            EczaneIlacSatiscombo.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            EczaneIlacSatisIlacYazimcombo.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
