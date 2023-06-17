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
    public partial class DSRLoading : Form
    {
        public DSRLoading()
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
            DSRStock fm = new DSRStock();
            fm.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DSRHome fm = new DSRHome();
            fm.Show();
            this.Hide();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            int PRD002 = Convert.ToInt32(textBox4.Text);
            int PRD003 = Convert.ToInt32(textBox5.Text);
            int PRD004 = Convert.ToInt32(textBox6.Text);
            int PRD005 = Convert.ToInt32(textBox7.Text);
            int PRD006 = Convert.ToInt32(textBox8.Text);
            int PRD007 = Convert.ToInt32(textBox9.Text);

            MessageBox.Show("Please Connect the Printer");


        }

        private void button7_Click(object sender, EventArgs e)
        {

            int PRD001 = Convert.ToInt32(textBox3.Text);
            string qtyQuery = "SELECT prdQty from  DRGProduct WHERE prdID = 'PRD001'";
            SqlCommand cmd = new SqlCommand(qtyQuery, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            conn.Open();
            DataTable table = new DataTable();
            sda.Fill(table);

            foreach(DataRow dr in table.Rows)
            {
                int existQty = int.Parse(dr["prdQty"].ToString());
                int newQty = existQty - PRD001;
                string updateQuery = "UPDATE DRGProduct SET prdQty = '" + newQty + "' WHERE prdID = 'PRD001'";
                SqlCommand cmd2 = new SqlCommand(updateQuery, conn);
                try
                {
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Item Loaded Successfully");
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }
                conn.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int PRD002 = Convert.ToInt32(textBox4.Text);
            string qtyQuery = "SELECT prdQty from  DRGProduct WHERE prdID = 'PRD002'";
            SqlCommand cmd = new SqlCommand(qtyQuery, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            conn.Open();
            DataTable table = new DataTable();
            sda.Fill(table);

            foreach (DataRow dr in table.Rows)
            {
                int existQty = int.Parse(dr["prdQty"].ToString());
                int newQty = existQty - PRD002;
                string updateQuery = "UPDATE DRGProduct SET prdQty = '" + newQty + "' WHERE prdID = 'PRD002'";
                SqlCommand cmd2 = new SqlCommand(updateQuery, conn);
                try
                {
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Item Loaded Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }
                conn.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int PRD003 = Convert.ToInt32(textBox5.Text);
            string qtyQuery = "SELECT prdQty from  DRGProduct WHERE prdID = 'PRD003'";
            SqlCommand cmd = new SqlCommand(qtyQuery, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            conn.Open();
            DataTable table = new DataTable();
            sda.Fill(table);

            foreach (DataRow dr in table.Rows)
            {
                int existQty = int.Parse(dr["prdQty"].ToString());
                int newQty = existQty - PRD003;
                string updateQuery = "UPDATE DRGProduct SET prdQty = '" + newQty + "' WHERE prdID = 'PRD003'";
                SqlCommand cmd2 = new SqlCommand(updateQuery, conn);
                try
                {
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Item Loaded Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }
                conn.Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int PRD004 = Convert.ToInt32(textBox6.Text);
            string qtyQuery = "SELECT prdQty from  DRGProduct WHERE prdID = 'PRD004'";
            SqlCommand cmd = new SqlCommand(qtyQuery, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            conn.Open();
            DataTable table = new DataTable();
            sda.Fill(table);

            foreach (DataRow dr in table.Rows)
            {
                int existQty = int.Parse(dr["prdQty"].ToString());
                int newQty = existQty - PRD004;
                string updateQuery = "UPDATE DRGProduct SET prdQty = '" + newQty + "' WHERE prdID = 'PRD004'";
                SqlCommand cmd2 = new SqlCommand(updateQuery, conn);
                try
                {
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Item Loaded Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }
                conn.Close();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int PRD005 = Convert.ToInt32(textBox7.Text);
            string qtyQuery = "SELECT prdQty from  DRGProduct WHERE prdID = 'PRD005'";
            SqlCommand cmd = new SqlCommand(qtyQuery, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            conn.Open();
            DataTable table = new DataTable();
            sda.Fill(table);

            foreach (DataRow dr in table.Rows)
            {
                int existQty = int.Parse(dr["prdQty"].ToString());
                int newQty = existQty - PRD005;
                string updateQuery = "UPDATE DRGProduct SET prdQty = '" + newQty + "' WHERE prdID = 'PRD005'";
                SqlCommand cmd2 = new SqlCommand(updateQuery, conn);
                try
                {
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Item Loaded Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                   
                }
                conn.Close();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int PRD006 = Convert.ToInt32(textBox8.Text);
            string qtyQuery = "SELECT prdQty from  DRGProduct WHERE prdID = 'PRD006'";
            SqlCommand cmd = new SqlCommand(qtyQuery, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            conn.Open();
            DataTable table = new DataTable();
            sda.Fill(table);

            foreach (DataRow dr in table.Rows)
            {
                int existQty = int.Parse(dr["prdQty"].ToString());
                int newQty = existQty - PRD006;
                string updateQuery = "UPDATE DRGProduct SET prdQty = '" + newQty + "' WHERE prdID = 'PRD006'";
                SqlCommand cmd2 = new SqlCommand(updateQuery, conn);
                try
                {
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Item Loaded Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }
                conn.Close();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int PRD007 = Convert.ToInt32(textBox9.Text);
            string qtyQuery = "SELECT prdQty from  DRGProduct WHERE prdID = 'PRD007'";
            SqlCommand cmd = new SqlCommand(qtyQuery, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            conn.Open();
            DataTable table = new DataTable();
            sda.Fill(table);

            foreach (DataRow dr in table.Rows)
            {
                int existQty = int.Parse(dr["prdQty"].ToString());
                int newQty = existQty - PRD007;
                string updateQuery = "UPDATE DRGProduct SET prdQty = '" + newQty + "' WHERE prdID = 'PRD007'";
                SqlCommand cmd2 = new SqlCommand(updateQuery, conn);
                try
                {
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Item Loaded Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                   
                }
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DSRUnloading fm = new DSRUnloading();
            fm.Show();
            this.Hide();
        }
    }
}
