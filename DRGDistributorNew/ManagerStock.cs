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
    public partial class ManagerStock : Form
    {
        public ManagerStock()
        {
            InitializeComponent();
        }
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {
            ManagerDSRact fm = new ManagerDSRact();
            fm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ManagerAnl fm = new ManagerAnl();
            fm.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string pID = textBox1.Text;
            int qty = int.Parse(textBox2.Text);

            string qry = "UPDATE DRGProduct SET prdQty = '" + qty +"' where prdID='"+ pID +"'";
            SqlDataAdapter ad = new SqlDataAdapter(qry,conn);
            DataTable dt = new DataTable();
            conn.Open();

            try
            {


                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                if (pID != null || qty != null)
                {
                    MessageBox.Show("Product updated successfuly.");
                    dataGridView1.Refresh();
                    textBox1.Clear();
                    textBox2.Clear();
                    viewStock();
                }
                else
                {
                    MessageBox.Show("Please Check again.");
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


        }
        void viewStock()
        {
            string querry = "select * from DRGProduct;";
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(querry, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void ManagerStock_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dRGdistributorsDataSet1.DRGProduct' table. You can move, or remove it, as needed.
            this.dRGProductTableAdapter.Fill(this.dRGdistributorsDataSet1.DRGProduct);
            viewStock();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            viewStock();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
