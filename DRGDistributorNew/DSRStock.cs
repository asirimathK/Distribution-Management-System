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

namespace DRGDistributorNew
{
    public partial class DSRStock : Form
    {
        public DSRStock()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-AJA1KQB\SQLEXPRESS;Initial Catalog=DRGdistributors;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            Login fm = new Login();
            fm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DSRSales01 fm = new DSRSales01();
            fm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            DSRHome fm = new DSRHome();
            fm.Show();
            this.Hide();
        }
        void viewStock()
        {
           /* SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM DRGProduct;", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;*/
           conn.Open();
            SqlCommand cmd = new SqlCommand("viewStock", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            viewStock();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DSRUnloading fm = new DSRUnloading();
            fm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DSRLoading fm = new DSRLoading();
            fm.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void DSRStock_Load(object sender, EventArgs e)
        {
            viewStock();
        }
    }
}
