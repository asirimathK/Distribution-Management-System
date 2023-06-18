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
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

namespace DRGDistributorNew
{
    public partial class ManagerAnlSales : Form
    {
        public ManagerAnlSales()
        {
            InitializeComponent();
        }
        //Connection String
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-AJA1KQB\SQLEXPRESS;Initial Catalog=DRGdistributors;Integrated Security=True");
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


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            ManagerHome fm = new ManagerHome();
            fm.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ManagerAnlDSR fm = new ManagerAnlDSR();
            fm.Show(); this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ManagerAnl fm = new ManagerAnl();
            fm.Show(); this.Hide();
        }

        void DisplayTotSales()
        {
            string querry = "select sum(salesValue) from salesWeekly;";
            SqlCommand com1 = new SqlCommand(querry, conn);

            DataSet ds1 = new DataSet();
            conn.Open();
            label3.Text = Convert.ToString(com1.ExecuteScalar());
            conn.Close();
        }

        //Method to predic the sales using a basic function
         void Predict()
        {
            double predWeeklySales, predDailySales, predWeeklyItems, predDailyItems;
            string querry1 = "select sum(salesValue) as sales from salesWeekly;";
            SqlCommand  com1 = new SqlCommand(querry1, conn);
            DataSet ds1 = new DataSet();
            conn.Open();
            double WsalesVal = Convert.ToDouble(com1.ExecuteScalar());

            predWeeklySales = WsalesVal / 4;

            label6.Text = Convert.ToString(predWeeklySales);

            //-----------------------------------------------------------
            string querry2 = "select sum(salesValue) as sales from salesWeekly;";
            SqlCommand com2 = new SqlCommand(querry2, conn);
            DataSet ds2 = new DataSet();
           
            double DsalesVal = Convert.ToDouble(com2.ExecuteScalar());

            predDailySales = (DsalesVal / 30)*3;

            label13.Text = Convert.ToString(predDailySales);
            

            //-----------------------------------------------------------
            string querry3 = "select sum(totSalesItems) as sales from DRGsales;";
            SqlCommand com3 = new SqlCommand(querry3, conn);
            DataSet ds3 = new DataSet();

            int WsalesItem = Convert.ToInt32(com3.ExecuteScalar());

            predWeeklyItems = WsalesItem / 4;

            label15.Text = Convert.ToString(predWeeklyItems);
            

            //-------------------------------------------------------------------------
            string querry4 = "select sum(totSalesItems) as sales from DRGsales;";
            SqlCommand com4 = new SqlCommand(querry4, conn);
            DataSet ds4 = new DataSet();

            int DsalesItem = Convert.ToInt32(com3.ExecuteScalar());

            predDailyItems = DsalesItem / 30;

            label16.Text = Convert.ToString(predDailyItems);
            conn.Close();


        }
        private void button4_Click(object sender, EventArgs e)
        {

            //Viewing weekly sales according to their respective weeks
            string weekNum = comboBox1.Text;
            if (weekNum == "1")
            {
                DataTable dt = new DataTable();
                conn.Open();
                string querry = "select dsrID, salesValue from salesWeekly where weeknum = 1;";
                SqlDataAdapter da = new SqlDataAdapter(querry, conn);
                da.Fill(dt);
                AnsSales.DataSource = dt;
                AnsSales.DataBind();


                AnsSales.Series["Sales"].XValueMember = "dsrID";
                AnsSales.Series["Sales"].YValueMembers = "salesValue";
                conn.Close();

                string querry2 = "select sum(salesValue) from salesWeekly where weekNum = 1;";
                SqlCommand com1 = new SqlCommand(querry2, conn);

                DataSet ds1 = new DataSet();
                conn.Open();
                label5.Text = Convert.ToString(com1.ExecuteScalar());
                conn.Close();

                


            }
            else if (weekNum == "2")
            {
                DataTable dt = new DataTable();
                conn.Open();
                string querry = "select dsrID, salesValue from salesWeekly where weeknum = 2;";
                SqlDataAdapter da = new SqlDataAdapter(querry, conn);
                da.Fill(dt);
                AnsSales.DataSource = dt;
                AnsSales.DataBind();


                AnsSales.Series["Sales"].XValueMember = "dsrID";
                AnsSales.Series["Sales"].YValueMembers = "salesValue";
                conn.Close();

                string querry2 = "select sum(salesValue) from salesWeekly where weekNum = 2;";
                SqlCommand com1 = new SqlCommand(querry2, conn);

                DataSet ds1 = new DataSet();
                conn.Open();
                label5.Text = Convert.ToString(com1.ExecuteScalar());
                conn.Close();
            }
            else if(weekNum == "3")
            {
                DataTable dt = new DataTable();
                conn.Open();
                string querry = "select dsrID, salesValue from salesWeekly where weeknum = 3;";
                SqlDataAdapter da = new SqlDataAdapter(querry, conn);
                da.Fill(dt);
                AnsSales.DataSource = dt;
                AnsSales.DataBind();


                AnsSales.Series["Sales"].XValueMember = "dsrID";
                AnsSales.Series["Sales"].YValueMembers = "salesValue";
                conn.Close();

                string querry2 = "select sum(salesValue) from salesWeekly where weekNum = 3;";
                SqlCommand com1 = new SqlCommand(querry2, conn);

                DataSet ds1 = new DataSet();
                conn.Open();
                label5.Text = Convert.ToString(com1.ExecuteScalar());
                conn.Close();
            }
            else if(weekNum == "4")
            {
                DataTable dt = new DataTable();
                conn.Open();
                string querry = "select dsrID, salesValue from salesWeekly where weeknum = 4;";
                SqlDataAdapter da = new SqlDataAdapter(querry, conn);
                da.Fill(dt);
                AnsSales.DataSource = dt;
                AnsSales.DataBind();


                AnsSales.Series["Sales"].XValueMember = "dsrID";
                AnsSales.Series["Sales"].YValueMembers = "salesValue";
                conn.Close();

                string querry2 = "select sum(salesValue) from salesWeekly where weekNum = 4;";
                SqlCommand com1 = new SqlCommand(querry2, conn);

                DataSet ds1 = new DataSet();
                conn.Open();
                label5.Text = Convert.ToString(com1.ExecuteScalar());
                conn.Close();
            }
            else
            {
                MessageBox.Show("Please select a week to proceed.");
            }

            
        }

        private void ManagerAnlSales_Load(object sender, EventArgs e)
        {
            DisplayTotSales();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Predict();
        }
    }
}
