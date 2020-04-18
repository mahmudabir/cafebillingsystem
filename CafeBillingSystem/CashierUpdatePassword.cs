using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeBillingSystem.Database_Connection;
using CafeBillingSystem.Entity;

namespace CafeBillingSystem
{
    public partial class CashierUpdatePassword : Form
    {
        cashierLoginEntity obj;
        public CashierUpdatePassword(cashierLoginEntity cle)
        {
            InitializeComponent();
            obj = cle;
        }

        private void CashierUpdatePassword_Load(object sender, EventArgs e)
        {
            textBox1.Text = obj.cashierId;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowCashierInfo sci = new ShowCashierInfo(obj);
            sci.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cashierlogin cl = new cashierlogin();
            if(textBox2.Text != "")
            {
                cl.Update_Password(textBox1.Text, textBox2.Text);
                MessageBox.Show("Password Cahnged.");
            }
            else
            {
                MessageBox.Show("Please fill up the text Box.");
            }
        }
    }
}
