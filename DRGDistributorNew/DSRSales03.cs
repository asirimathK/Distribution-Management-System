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
    public partial class DSRSales03 : Form
    {

        public static DSRSales03 instance;
        public Label lab7;
        public Label lab12;
        public Label lab15;
        public Label lab16;
        public Label lab19;
        public Label lab20;
        public DataGridView dgv1;
        private string salesID;

        public DSRSales03()
        {
            InitializeComponent();
            instance = this;
            //lab7 = label7;
            //lab12 = label12;
            lab15 = label15;
            lab16 = label16;
            lab19 = label19;
            dgv1 = dataGridView1;
        }

        public DSRSales03(string salesID)
        {
            this.salesID = salesID;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-AJA1KQB\SQLEXPRESS;Initial Catalog=DRGdistributors;Integrated Security=True");
        public void refresh()
        {

            
            
            string querry = "select top 1 mpTotal as Milk_Packet, frtTotal as Fruit_Juice, fMilk as Fresh_Milk, totSalesItems as Items, totSalesvalue as Sales_Value from DRGinvoice order by salesID DESC;";
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(querry,conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            conn.Close();

            string qry1 = "select top 1 date from DRGinvoice order by salesID DESC;";
            SqlCommand cmd1 = new SqlCommand(qry1, conn);
            DataSet ds = new DataSet();
            conn.Open();
            label15.Text = Convert.ToString(cmd1.ExecuteScalar());
            conn.Close();

            string qry2 = "select top 1 totSalesvalue from DRGinvoice order by salesID DESC;";
            SqlCommand cmd2 = new SqlCommand(qry2, conn);
            DataSet ds2 = new DataSet();
            conn.Open();
            label19.Text = Convert.ToString(cmd2.ExecuteScalar());
            conn.Close();

            string qry3 = "select top 1 salesID from DRGinvoice order by salesID DESC;";
            SqlCommand cmd3 = new SqlCommand(qry3, conn);
            DataSet ds3 = new DataSet();
            conn.Open();
            label16.Text = Convert.ToString(cmd3.ExecuteScalar());
            conn.Close();




        }

        private void DSRSales03_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

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

        private void button5_Click(object sender, EventArgs e)
        {
            DSRSales01 fm = new DSRSales01();
            fm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DSRSales01 fm = new DSRSales01();
            fm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Connect the Printer");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refresh();
             timer1.Start();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
