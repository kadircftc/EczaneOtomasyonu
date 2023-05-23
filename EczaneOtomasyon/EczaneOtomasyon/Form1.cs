using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void HastaIslemleributton_Click(object sender, EventArgs e)
        {
            Hasta form2 = new Hasta();
            form2.Show();
            this.Hide();
        }

        private void DoktorYetkilibutton_Click(object sender, EventArgs e)
        {
            Doktor doktorForm = new Doktor();
            doktorForm.Show();
            this.Hide();
        }

        private void IlacIslemleriButton_Click(object sender, EventArgs e)
        {
           Ilac ılacForm=new Ilac();
            ılacForm.Show();
            this.Hide();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Eczanebutton_Click(object sender, EventArgs e)
        {
            Eczane eczaneForm = new Eczane();
            eczaneForm.Show();
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
