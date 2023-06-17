using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DRGDistributorNew
{
    public partial class DeleteSales : Form
    {
        public DeleteSales()
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

        private void button5_Click(object sender, EventArgs e)
        {
            Sales fm = new Sales();
            fm.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            String salesID = textBox1.Text;

            if (String.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("Insert Sales ID to DELETE Records");
            }
            else
            {

                
                string qryDel = "delete from DRGsales where salesID='" + salesID + "'";
               // string del1 = "delete from Invoice where salesID='" + salesID + "'";
                SqlCommand cmd = new SqlCommand(qryDel, conn);
                //SqlCommand cmd1 = new SqlCommand(del1, conn);


                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //cmd1.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully");



                }
                catch (SqlException es)
                {
                    MessageBox.Show("" + es);
                }

                DeleteSales fm = new DeleteSales();
                fm.Show();
                this.Hide();
                
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            String id = textBox1.Text;

            if (String.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("Insert Sales ID to VIEW Records");
            }
            else
            {

               
                string qry = "select date as date, dsrID as DSR_ID, salesID as Sales_ID, mpVanila as Vanila, mpChoco as Chocolate, mpStrbry as Strawberry, frtOrg as Orange, frtMng as Mango, frtMix as Mix, totSalesvalue as Sales_Value from DRGsales where salesID='" + id + "' ORDER BY salesID ";



                SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                DataSet ds = new DataSet();



                da.Fill(ds, "DRGsales");
                dataGridView1.DataSource = ds.Tables["DRGsales"];

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerHome fm = new ManagerHome();
            fm.Show();
            this.Hide();
        }
    }
}
