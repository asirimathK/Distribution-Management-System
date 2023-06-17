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

namespace DRGDistributorNew
{
    public partial class EditSales : Form
    {
        public EditSales()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-AJA1KQB\SQLEXPRESS;Initial Catalog=DRGdistributors;Integrated Security=True");
        public void refresh()
        {
            String id = textBox8.Text;

            if (String.IsNullOrEmpty(textBox8.Text.Trim()))
            {
                MessageBox.Show("Insert Invoice ID to VIEW Records");
            }
            else
            {

                //String conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\drgDB.mdf;Integrated Security=True;Connect Timeout=30";
                string qry = "SELECT Customer,Payment,ProductName,QTY FROM Sales where InvoiceID='" + id + "' ORDER BY InvoiceID";



                //SqlDataAdapter da = new SqlDataAdapter(qry, conString);
                DataSet ds = new DataSet();



                //da.Fill(ds, "Sales");
                dataGridView1.DataSource = ds.Tables["Sales"];

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            }

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

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            String id = textBox8.Text;

            if (String.IsNullOrEmpty(textBox8.Text.Trim()))
            {
                MessageBox.Show("Insert Sales ID to VIEW Records");
            }
            else
            {

                
                string qry = "SELECT mpVanila as Vanila, mpChoco as Chocolate, mpStrbry as Strawberry, frtOrg as Orange, frtMng as Mango, frtMix as Mix, fMilk as Milk FROM DRGsales where salesID='" + id + "' ORDER BY salesID";



                SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                DataSet ds = new DataSet();



                da.Fill(ds, "DRGSales");
                dataGridView1.DataSource = ds.Tables["DRGSales"];

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox8.Text.Trim()))
            {
                MessageBox.Show("Insert Sales ID to UPDATE Records");
            }
            else if(String.IsNullOrEmpty(textBox1.Text.Trim()) && String.IsNullOrEmpty(textBox2.Text.Trim()) && String.IsNullOrEmpty(textBox3.Text.Trim()) && String.IsNullOrEmpty(textBox4.Text.Trim()) && String.IsNullOrEmpty(textBox5.Text.Trim()) && String.IsNullOrEmpty(textBox6.Text.Trim()) && String.IsNullOrEmpty(textBox7.Text.Trim()))
            {
                MessageBox.Show("No Data Added to UPDATE the Records");
            }
            else
            {

                String salesID = textBox8.Text;

                string querry = "select mpVanila as Vanila, mpChoco, mpStrbry, frtOrg, frtMng, frtMix, fMilk from DRGsales where salesID ='"+salesID+"'";
                SqlDataAdapter da = new SqlDataAdapter(querry,conn);
                conn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                conn.Close();

                string qry = "SELECT SUM(Amount) FROM Sales where InvoiceID='" + salesID + "' ";
                SqlCommand com = new SqlCommand(qry, conn);

                DataSet ds = new DataSet();


                conn.Open();
                label24.Text = Convert.ToString(com.ExecuteScalar());
                conn.Close();



                //Invoice Update


                string upd = "update Invoice set Total='" + label24.Text + "' where InvoiceID='" + salesID + "'";
                SqlCommand cmd = new SqlCommand(upd, conn);



                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully");



                }
                catch (SqlException es)
                {
                    MessageBox.Show(es.Message);
                }

                Sales fm = new Sales();
                fm.Show();
                this.Hide();
            }
        }
        //Delete this snippet after work
        /*private void button18_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox8.Text.Trim()))
            {
                MessageBox.Show("Insert Invoice ID to UPDATE Records");
            }
            else if(String.IsNullOrEmpty(comboBox1.Text.Trim()))
            {
                MessageBox.Show("Insert Payment Method to UPDATE Records");
            }
            else
            {

                String InvoiceID = textBox8.Text;
                String Payment = comboBox1.Text;
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\drgDB.mdf;Integrated Security=True;Connect Timeout=30");
                string upd = "update Sales set Payment='" + Payment + "' where InvoiceID='" + InvoiceID + "'";
                SqlCommand cmd = new SqlCommand(upd, con);



                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully");



                }
                catch (SqlException es)
                {
                    MessageBox.Show(es.Message);
                }
            }
        }*/

        private void button17_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox8.Text.Trim()))
            {
                MessageBox.Show("Insert Sales ID to UPDATE Records");
            }
            else if (String.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("Insert Product Quantity to UPDATE Records");
            }
            else
            {

                String salesID = textBox8.Text;
                String QTY = textBox1.Text;
                SqlDataAdapter da = new SqlDataAdapter("update ", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    conn.Open();
                    string upd = "update Sales set QTY='" + QTY + "'  , Amount=('" + QTY + "'* Price ) where InvoiceID='" + salesID + "' AND ProductID= 'PR001'";
                    SqlCommand cmd = new SqlCommand(upd, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record Updated Successfully");

                }
                else
                {
                    MessageBox.Show("This Product is not included in the Invoice");
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox8.Text.Trim()))
            {
                MessageBox.Show("Insert Invoice ID to UPDATE Records");
            }
            else if (String.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                MessageBox.Show("Insert Product Quantity to UPDATE Records");
            }
            else
            {

                String InvoiceID = textBox8.Text;
                String QTY = textBox2.Text;
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\drgDB.mdf;Integrated Security=True;Connect Timeout=30");

                SqlDataAdapter da = new SqlDataAdapter("select ProductID From Sales where InvoiceID='" + InvoiceID + "' AND ProductID= 'PR002' ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    con.Open();
                    string upd = "update Sales set QTY='" + QTY + "'  , Amount=('" + QTY + "'* Price ) where InvoiceID='" + InvoiceID + "' AND ProductID= 'PR002' ";
                    SqlCommand cmd = new SqlCommand(upd, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Updated Successfully");



                }
                else
                {
                    MessageBox.Show("This Product is not included in the Invoice");
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox8.Text.Trim()))
            {
                MessageBox.Show("Insert Invoice ID to UPDATE Records");
            }
            else if (String.IsNullOrEmpty(textBox3.Text.Trim()))
            {
                MessageBox.Show("Insert Product Quantity to UPDATE Records");
            }
            else
            {

                String InvoiceID = textBox8.Text;
                String QTY = textBox3.Text;
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\drgDB.mdf;Integrated Security=True;Connect Timeout=30");

                SqlDataAdapter da = new SqlDataAdapter("select ProductID From Sales where InvoiceID='" + InvoiceID + "' AND ProductID= 'PR003' ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    con.Open();
                    string upd = "update Sales set QTY='" + QTY + "'  , Amount=('" + QTY + "'* Price ) where InvoiceID='" + InvoiceID + "' AND ProductID= 'PR003' ";
                    SqlCommand cmd = new SqlCommand(upd, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Updated Successfully");



                }
                else
                {
                    MessageBox.Show("This Product is not included in the Invoice");
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox8.Text.Trim()))
            {
                MessageBox.Show("Insert Invoice ID to UPDATE Records");
            }
            else if (String.IsNullOrEmpty(textBox4.Text.Trim()))
            {
                MessageBox.Show("Insert Product Quantity to UPDATE Records");
            }
            else
            {

                String InvoiceID = textBox8.Text;
                String QTY = textBox4.Text;
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\drgDB.mdf;Integrated Security=True;Connect Timeout=30");




                SqlDataAdapter da = new SqlDataAdapter("select ProductID From Sales where InvoiceID='" + InvoiceID + "' AND ProductID= 'PR004' ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    con.Open();
                    string upd = "update Sales set QTY='" + QTY + "'  , Amount=('" + QTY + "'* Price ) where InvoiceID='" + InvoiceID + "' AND ProductID= 'PR004' ";
                    SqlCommand cmd = new SqlCommand(upd, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Updated Successfully");



                }
                else
                {
                    MessageBox.Show("This Product is not included in the Invoice");
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox8.Text.Trim()))
            {
                MessageBox.Show("Insert Invoice ID to UPDATE Records");
            }
            else if (String.IsNullOrEmpty(textBox5.Text.Trim()))
            {
                MessageBox.Show("Insert Product Quantity to UPDATE Records");
            }
            else
            {

                String InvoiceID = textBox8.Text;
                String QTY = textBox5.Text;
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\drgDB.mdf;Integrated Security=True;Connect Timeout=30");




                SqlDataAdapter da = new SqlDataAdapter("select ProductID From Sales where InvoiceID='" + InvoiceID + "' AND ProductID= 'PR005' ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    con.Open();
                    string upd = "update Sales set QTY='" + QTY + "'  , Amount=('" + QTY + "'* Price ) where InvoiceID='" + InvoiceID + "' AND ProductID= 'PR005'";
                    SqlCommand cmd = new SqlCommand(upd, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Updated Successfully");



                }
                else
                {
                    MessageBox.Show("This Product is not included in the Invoice");
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox8.Text.Trim()))
            {
                MessageBox.Show("Insert Invoice ID to UPDATE Records");
            }
            else if (String.IsNullOrEmpty(textBox6.Text.Trim()))
            {
                MessageBox.Show("Insert Product Quantity to UPDATE Records");
            }
            else
            {

                String InvoiceID = textBox8.Text;
                String QTY = textBox6.Text;
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\drgDB.mdf;Integrated Security=True;Connect Timeout=30");




                SqlDataAdapter da = new SqlDataAdapter("select ProductID From Sales where InvoiceID='" + InvoiceID + "' AND ProductID= 'PR006' ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    con.Open();
                    string upd = "update Sales set QTY='" + QTY + "'  , Amount=('" + QTY + "'* Price ) where InvoiceID='" + InvoiceID + "' AND ProductID= 'PR006' ";
                    SqlCommand cmd = new SqlCommand(upd, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Updated Successfully");



                }
                else
                {
                    MessageBox.Show("This Product is not included in the Invoice");
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox8.Text.Trim()))
            {
                MessageBox.Show("Insert Invoice ID to UPDATE Records");
            }
            else if (String.IsNullOrEmpty(textBox7.Text.Trim()))
            {
                MessageBox.Show("Insert Product Quantity to UPDATE Records");
            }
            else
            {

                String InvoiceID = textBox8.Text;
                String QTY = textBox7.Text;
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\drgDB.mdf;Integrated Security=True;Connect Timeout=30");



                SqlDataAdapter da = new SqlDataAdapter("select ProductID From Sales where InvoiceID='" + InvoiceID + "' AND ProductID= 'PR007' ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    con.Open();
                    string upd = "update Sales set QTY='" + QTY + "' , Amount=('" + QTY + "'* Price ) where InvoiceID='" + InvoiceID + "' AND ProductID= 'PR007' ";
                    SqlCommand cmd = new SqlCommand(upd, con);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Updated Successfully");


                }
                else
                {
                    MessageBox.Show("This Product is not included in the Invoice");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refresh();
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ManagerHome fm = new ManagerHome();
            fm.Show();
            this.Hide();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
