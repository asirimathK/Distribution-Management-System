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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using System.Globalization;

namespace DRGDistributorNew
{
    public partial class Sales : Form
    {
        public Sales()
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
            ManagerHome fm = new ManagerHome();
            fm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            DeleteSales fm = new DeleteSales();
            fm.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            EditSales fm = new EditSales();
            fm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //DateTime Date = dateTimePicker1.Value;
            

            if (String.IsNullOrEmpty(comboBox1.Text.Trim()))
            {
                MessageBox.Show("Insert DSR ID");
            }
            else
            {

                /*String conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\drgDB.mdf;Integrated Security=True;Connect Timeout=30";
                string qry = "SELECT Date,Customer,InvoiceID,Payment,Total FROM Invoice where Date='" + Date + "' ORDER BY InvoiceID";



                SqlDataAdapter da = new SqlDataAdapter(qry, conString);
                DataSet ds = new DataSet();



                da.Fill(ds, "Invoice");
                dataGridView1.DataSource = ds.Tables["Invoice"];

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                String date = dateTimePicker1.Text;
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\drgDB.mdf;Integrated Security=True;Connect Timeout=30");


                string qry1 = "SELECT SUM(Total) FROM Invoice where Date='" + date + "' ";
                SqlCommand com = new SqlCommand(qry1, con);

                string qry2 = "SELECT COUNT(Total) FROM Invoice where Date='" + date + "' ";
                SqlCommand com1 = new SqlCommand(qry2, con);

                DataSet ds1 = new DataSet();


                con.Open();
                label12.Text = Convert.ToString(com.ExecuteScalar());
                con.Close();

                con.Open();
                label13.Text = Convert.ToString(com1.ExecuteScalar());
                con.Close();*/

                string id = comboBox1.Text;

                string querry = "SELECT * FROM DRGsales WHERE dsrID = '" +id+ "';";
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(querry,conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

                string qry1 = "SELECT SUM(totSalesvalue) FROM DRGsales WHERE dsrID = '" + id + "';";
                SqlCommand com = new SqlCommand(qry1, conn);

                string qry2 = "SELECT COUNT(dsrID) FROM DRGsales WHERE dsrID = '" + id + "';";
                SqlCommand com1 = new SqlCommand(qry2, conn);

                DataSet ds1 = new DataSet();


                conn.Open();
                label12.Text = Convert.ToString(com.ExecuteScalar());
                conn.Close();

                conn.Open();
                label13.Text = Convert.ToString(com1.ExecuteScalar());
                conn.Close();

                /* conn.Open();
                 SqlCommand cmd = new SqlCommand("displaySales", conn);
                 cmd.CommandType = CommandType.StoredProcedure;

                 DataTable dt = new DataTable();
                 dt.Load(cmd.ExecuteReader());
                 dataGridView1.DataSource = dt;
                 conn.Close();*/

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ManagerAnl fm = new ManagerAnl();
            fm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ManagerDSRact fm = new ManagerDSRact();
            fm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ManagerStock fm = new ManagerStock();
            fm.Show();
            this.Hide();
        }
    }
}
