using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NOT_KAYIT2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            ogrencidetay frm = new ogrencidetay();
            frm.numara = maskedtextbox1.Text;
            frm.Show();
        }

        private void maskedtextbox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedtextbox1.Text == "1111")
            {
                ogretmendetay fr = new ogretmendetay();
                fr.Show();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
