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
    public partial class DSRSales01 : Form
    {
        public DSRSales01()
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

        private void button9_Click(object sender, EventArgs e)
        {
            DSRHome fm = new DSRHome();
            fm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DSRStock fm = new DSRStock();
            fm.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DSRSales02 fm = new DSRSales02();
            fm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            string qry = "SELECT date as Date, salesID as Sales_ID, dsrName as Name, totSalesItems as Items, totSalesvalue as Sales_Value FROM DRGsales order by salesID DESC;";
            SqlDataAdapter ad = new SqlDataAdapter(qry,conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;

            string qry2 = "SELECT COUNT(dsrID) FROM DRGsales;";
            SqlCommand com1 = new SqlCommand(qry2, conn);

            DataSet ds1 = new DataSet();
            conn.Open();
            label13.Text = Convert.ToString(com1.ExecuteScalar());
            conn.Close();
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DSRLoading fm = new DSRLoading();
            fm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DSRUnloading fm = new DSRUnloading();
            fm.Show();
            this.Hide();
        }
    }
}
