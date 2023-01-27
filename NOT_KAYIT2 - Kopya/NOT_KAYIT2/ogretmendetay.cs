using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NOT_KAYIT2
{
    public partial class ogretmendetay : Form
    {
        public ogretmendetay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=RMYS\SQLEXPRESS;Initial Catalog=DbNotkayıt;Integrated Security=True");

        private void ogretmendetay_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dbNotkayıtDataSet.tblders' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbldersTableAdapter.Fill(this.dbNotkayıtDataSet.tblders);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblders (ogrnumara,ograd,ogrsoyad)values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", msknumara.Text);
            komut.Parameters.AddWithValue("@p2", txtad.Text);
            komut.Parameters.AddWithValue("@p3", txtsoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Sisteme Eklendi");
            this.tbldersTableAdapter.Fill(this.dbNotkayıtDataSet.tblders);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            msknumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtsınav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsınav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtsınav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void buton2_Click(object sender, EventArgs e)
        {
            double ortalama, s1, s2, s3;
            string durum;
            s1 = Convert.ToDouble(txtsınav1.Text);
            s2 = Convert.ToDouble(txtsınav2.Text);
            s3 = Convert.ToDouble(txtsınav3.Text);

            ortalama = (s1 + s2 + s3) / 3;
            lblortalama.Text = ortalama.ToString();

            if (ortalama >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }


            baglanti.Open();
            SqlCommand komut = new SqlCommand("update tblders set OGRSINAV1=@P1, OGRSINAV2=@P2, OGRSINAV3=@P3, ORTALAMA=@P4,DURUM=@P5 WHERE OGRNUMARA=@P6", baglanti);
            komut.Parameters.AddWithValue("@p1", txtsınav1.Text);
            komut.Parameters.AddWithValue("@p2", txtsınav2.Text);
            komut.Parameters.AddWithValue("@p3", txtsınav3.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(lblortalama.Text));
            komut.Parameters.AddWithValue("@p5", durum);
            komut.Parameters.AddWithValue("@p6", msknumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Notları Güncellendi");
            this.tbldersTableAdapter.Fill(this.dbNotkayıtDataSet.tblders);
        }

    
    }
}
