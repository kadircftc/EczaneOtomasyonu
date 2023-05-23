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
    public partial class Ilac : Form
    {
        
        public Ilac()
        {
            InitializeComponent();
        }

        private void GeributtonDoktor_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void IlacIslemleriButton_Click(object sender, EventArgs e)
        {
            IlacIslemleriForm ılacIslemlerForm= new IlacIslemleriForm();
            ılacIslemlerForm.Show();
            this.Hide();
        }

        private void IlacFirmasıButton_Click(object sender, EventArgs e)
        {
            IlacFirmasi firmaForm = new IlacFirmasi();
            firmaForm.Show();
            this.Hide();
        }
        private void Ilac_FormClosing(object sender, FormClosingEventArgs e)
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
