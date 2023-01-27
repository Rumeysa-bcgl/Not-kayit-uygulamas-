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
    public partial class ogrencidetay : Form
    {
        public ogrencidetay()
        {
            InitializeComponent();
        }
        public string numara;

        SqlConnection baglanti = new SqlConnection(@"Data Source=RMYS\SQLEXPRESS;Initial Catalog=DbNotkayıt;Integrated Security=True");

        private void ogrencidetay_Load(object sender, EventArgs e)
        {
            lblnumara.Text = numara;
            baglanti.Open();
            SqlCommand komut =new SqlCommand("select * from tblders where ogrnumara=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                lblsinav1.Text = dr[4].ToString();
                lblsinav2.Text = dr[5].ToString();
                lblsinav3.Text = dr[6].ToString();
                lblortalama.Text = dr[7].ToString();
                lbldurum.Text = dr[8].ToString();

            }
            baglanti.Close();
        }
    }
}
//Data Source=RMYS\SQLEXPRESS;Initial Catalog=DbNotkayıt;Integrated Security=True