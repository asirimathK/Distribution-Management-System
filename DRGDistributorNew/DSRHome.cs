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
    public partial class DSRHome : Form
    {
        public DSRHome()
        {
            InitializeComponent();
        }

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

        private void button2_Click(object sender, EventArgs e)
        {
            DSRLoading fm = new DSRLoading();
            fm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DSRUnloading fm = new DSRUnloading();
            fm.Show();
            this.Hide();
        }
    }
}
