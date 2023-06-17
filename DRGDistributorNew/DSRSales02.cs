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
using System.Diagnostics;

namespace DRGDistributorNew
{
    public partial class DSRSales02 : Form
    {
        float totAmt = 0;
        

        public static DSRSales02 instance;
        public DSRSales02()
        {
            InitializeComponent();
            instance = this;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-AJA1KQB\SQLEXPRESS;Initial Catalog=DRGdistributors;Integrated Security=True");
        private void button11_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            DSRStock fm = new DSRStock();
            fm.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int mpPrice = 80, frtPrice = 85, fmilkPrice = 320;
            DateTime date = dateTimePicker1.Value;
            string dsrID = textBox10.Text;
            string salesID = TextBox1.Text;
            string dsrName = textBox2.Text;
         


            if (String.IsNullOrEmpty(dsrID.Trim()) || String.IsNullOrEmpty(salesID.Trim()))
            {
                button12.Enabled = false;
                MessageBox.Show("Please Enter Relevent Details!");
                button12.Enabled = true;
            }
            else
            {
                string Total = totAmt.ToString();
                int totQTY = 0;
                int mpVanila = 0, mpChoco = 0, mpStrbry = 0, frtOrg = 0, frtMng = 0, frtMix = 0, fMilk = 0;
                int mpTotal = 0, frtTotal = 0, totSalesItems = 0, totSalesvalue = 0 ;

                mpVanila = int.Parse(textBox3.Text);
                mpChoco = int.Parse(textBox4.Text);
                mpStrbry = int.Parse(textBox5.Text);
                mpTotal = mpVanila + mpChoco + mpStrbry;
                frtOrg = int.Parse(textBox8.Text);
                frtMng = int.Parse(textBox7.Text);
                frtMix = int.Parse(textBox9.Text);
                frtTotal = frtMng + frtOrg + frtMix;
                fMilk = int.Parse(textBox6.Text);

                
               
             
                totSalesItems = mpTotal + frtTotal + fMilk;
                label35.Text = totSalesItems.ToString();
                

                int totvalue = (mpTotal*mpPrice) + (frtTotal*frtPrice) + (fMilk*fmilkPrice);
                totSalesvalue = totvalue;
                label51.Text = totSalesvalue.ToString();






                string qry = "insert into DRGsales values('" + date + "','" + salesID + "','" + dsrID + "','" + dsrName + "','" + mpVanila + "','" + mpChoco + "','" + mpStrbry + "','" + mpTotal + "','" + frtOrg + "','" + frtMng + "','" + frtMix + "','" + frtTotal + "','" + fMilk + "','" + totSalesItems + "','" + totSalesvalue + "')";
                string qry1 = "insert into DRGinvoice values('" + date + "','" + dsrID + "','" + salesID + "','" + mpTotal + "','" + frtTotal + "','"+fMilk+"','" + totSalesItems + "','" + totSalesvalue + "')";
                SqlCommand cmd = new SqlCommand(qry,conn);
                SqlCommand cmd1 = new SqlCommand(qry1,conn);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show("Order Added Successfully");

                DSRSales03 fm = new DSRSales03();
                fm.Show();
                this.Hide();


            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
                String str1 = textBox3.Text;
                int qty;
                int.TryParse(str1, out qty);
                int price = int.Parse(l46.Text);
                int amount = qty * price;
                label32.Text = amount.ToString();

                
            
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            String str1 = textBox4.Text;
            int qty;
            int.TryParse(str1, out qty);
            int price = int.Parse(l45.Text);
            int amount = qty * price;
            label31.Text = amount.ToString();           



        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            String str1 = textBox5.Text;
            int qty;
            int.TryParse(str1, out qty);
            int price = int.Parse(l44.Text);
            int amount = qty * price;
            label30.Text = amount.ToString();

            

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            String str1 = textBox6.Text;
            int qty;
            int.TryParse(str1, out qty);
            int price = int.Parse(l43.Text);
            int amount = qty * price;
            label29.Text = amount.ToString();

            


        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            String str1 = textBox7.Text;
            int qty;
            int.TryParse(str1, out qty);
            int price = int.Parse(l42.Text);
            int amount = qty * price;
            label28.Text = amount.ToString();

            


        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            String str1 = textBox8.Text;
            int qty;
            int.TryParse(str1, out qty);
            int price = int.Parse(l41.Text);
            int amount = qty * price;
            label27.Text = amount.ToString();

            

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            String str1 = textBox9.Text;
            int qty;
            int.TryParse(str1, out qty);
            int price = int.Parse(l40.Text);
            int amount = qty * price;
            label26.Text = amount.ToString();

            

        }

        

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label26_Clicked(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DSRLoading fm = new DSRLoading();
            fm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DSRUnloading fm = new DSRUnloading();
            fm.Show();
            this.Close();
        }
    }
}
