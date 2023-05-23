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
    public partial class IlacIslemleriForm : Form
    {

        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter dat;
        public IlacIslemleriForm()
        {
            InitializeComponent();
        }

        private void GeributtonDoktor_Click(object sender, EventArgs e)
        {
            Ilac ılac = new Ilac();
            ılac.Show();
            this.Hide();
        }

        private void IlacIslemleriForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eczaneDataSet.Ilac' table. You can move, or remove it, as needed.
            this.ilacTableAdapter.Fill(this.eczaneDataSet.Ilac);
            IlacGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
         void IlacGetir()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-K34TCBL\\SQLEXPRESS;Initial Catalog=Eczane;Integrated Security=True");
            baglanti.Open();
            dat = new SqlDataAdapter("SELECT *FROM Ilac", baglanti);
            DataTable tablo = new DataTable();
            dat.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void IlacEkleButton_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO Ilac(Formul,Marka) values(@formul,@marka)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@formul", IlacFormülText.Text);
            komut.Parameters.AddWithValue("@marka", IlacMarkaText.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            IlacGetir();
            MessageBox.Show("İlaç Kaydedildi!");

        }

        private void IlacSilButton_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM Ilac WHERE IlacID=@id";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@id", Convert.ToInt32(IlacIDText.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            IlacGetir();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IlacIDText.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            IlacFormülText.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            IlacMarkaText.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void IlacGüncelleButton_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE Ilac SET Formul=@formul ,Marka=@marka WHERE IlacID=@ıd";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ıd", Convert.ToInt32(IlacIDText.Text));
            komut.Parameters.AddWithValue("@formul", IlacFormülText.Text);
            komut.Parameters.AddWithValue("@marka", IlacMarkaText.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            IlacGetir();
        }
        private void IlacIslemleriForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void IlacIslemleriForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
