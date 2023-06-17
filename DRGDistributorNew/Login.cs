using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;
using System.Globalization;

namespace DRGDistributorNew
{
    public partial class Login : Form
    {
        string username, password, date, LinTime, LoutTime;
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-AJA1KQB\SQLEXPRESS;Initial Catalog=DRGdistributors;Integrated Security=True");


        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            username = txtUsername.Text;
            password = txtPassword.Text;


            try
            {
                string querry = "SELECT role FROM AccessCredentials where username = '" + txtUsername.Text + "' AND password = '" + txtPassword.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(querry,conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    username = txtUsername.Text;
                    password = txtPassword.Text;
                    string role = dt.Rows[0][0].ToString();

                    if(role == "Manager")
                    {
                        ManagerHome fm = new ManagerHome();
                        fm.Show();
                        this.Hide();
                    }
                    else
                    {
                        DSRHome fm = new DSRHome();
                        fm.Show();
                        this.Hide();
                    }

                    getLoginDateTime();
                    

                    
                }
                else
                {
                    MessageBox.Show("Invalid user. Please check again!");
                }

            }
            catch 
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close(); 
            }
            

        }
        void getLoginDateTime()
        {
            date = DateTime.Now.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            LinTime = DateTime.Now.ToString("HH.mm.ss");
           

            String querry = "INSERT INTO Logininfo VALUES ('" + date + "','" + txtUsername.Text + "','" + LinTime + "');";
            SqlCommand cmd = new SqlCommand(querry, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
