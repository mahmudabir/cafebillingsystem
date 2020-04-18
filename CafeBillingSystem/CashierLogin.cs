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
using CafeBillingSystem.Database_Connection;
using CafeBillingSystem.Entity;

namespace CafeBillingSystem
{
    public partial class CashierLogin : Form
    {
        
        public CashierLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage home_page = new HomePage();
            home_page.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cashierLoginEntity clentity = new cashierLoginEntity();
            cashierlogin cl = new cashierlogin();

            clentity = cl.getCashier(textBox1.Text, textBox2.Text);

            if ((clentity != null) && (clentity.cashierId == textBox1.Text) && (clentity.cashierStatus == "active"))
            {
                this.Hide();
                CashierForm cf = new CashierForm(clentity);
                cf.Show();
                MessageBox.Show("Owner ID " + clentity.cashierId);
            }
            else
            {
                MessageBox.Show("Incorrect ID or Password");
            }
        }

        private void CashierLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
