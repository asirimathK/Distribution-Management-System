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
using System.Windows.Forms.DataVisualization.Charting;

namespace DRGDistributorNew
{
    public partial class ManagerAnl : Form
    {
        public ManagerAnl()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-AJA1KQB\SQLEXPRESS;Initial Catalog=DRGdistributors;Integrated Security=True");
        void FillChart()
        {
            DataTable dt = new DataTable();
            conn.Open();
            string querry = "select  weekNum,sum(salesValue) as salesValue from salesWeekly group by weekNum;";
         
            SqlDataAdapter da = new SqlDataAdapter(querry,conn);
            da.Fill(dt);
            chart1.DataSource = dt;
            conn.Close();

            chart1.Series["Sales"].XValueMember = "weekNum";
            chart1.Series["Sales"].YValueMembers = "salesValue";

            

        }
         void FillChart2()
        {
            DataTable dt = new DataTable();
            conn.Open();
            string querry = "SELECT * from productSales";
            SqlDataAdapter da = new SqlDataAdapter( querry,conn);
            da.Fill(dt);
            chart2.DataSource = dt;
            chart2.DataBind();
            conn.Close();

            chart2.Series["Product"].XValueMember = "prdName";
            chart2.Series["Product"].YValueMembers = "salesQty";
           



        }
        
        void BestPerformingDSR()
        {
            string querry = "select dsrName, sum(totSalesvalue) as IndividualSales FROM DRGsales group by dsrName order by IndividualSales desc;";
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(querry, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        void BestSellingPrd()
        {
            string querry = "select top 3 * from productSales order by salesQty desc;";
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(querry,conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login fm = new Login();
            fm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
 
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sales fm = new Sales();
            fm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            ManagerHome fm = new ManagerHome();
            fm.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ManagerAnlSales fm = new ManagerAnlSales();
            fm.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ManagerAnlDSR fm = new ManagerAnlDSR(); 
            fm.Show();
            this.Hide();
        }

        private void ManagerAnl_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dRGdistributorsDataSet3.salesWeekly' table. You can move, or remove it, as needed.
            this.salesWeeklyTableAdapter1.Fill(this.dRGdistributorsDataSet3.salesWeekly);
            // TODO: This line of code loads data into the 'dRGdistributorsDataSet2.salesWeekly' table. You can move, or remove it, as needed.
            this.salesWeeklyTableAdapter.Fill(this.dRGdistributorsDataSet2.salesWeekly);
            FillChart();
            FillChart2();
            BestPerformingDSR();
            BestSellingPrd();
        }
    }
}
