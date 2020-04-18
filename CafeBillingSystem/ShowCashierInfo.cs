using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeBillingSystem.Entity;
using CafeBillingSystem.Database_Connection;

namespace CafeBillingSystem
{
    public partial class ShowCashierInfo : Form
    {
        cashierLoginEntity obj;
        public ShowCashierInfo(cashierLoginEntity cle)
        {
            InitializeComponent();
            obj = cle;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CashierUpdatePassword cup = new CashierUpdatePassword(obj);
            cup.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CashierForm cf = new CashierForm(obj);
            cf.Show();

        }

        private void ShowCashierInfo_Load(object sender, EventArgs e)
        {
            CashierDB cdb = new CashierDB();
            cashier c = new cashier();

            c = cdb.getCashier(obj.cashierId);
            textBox1.Text = c.cashierId;
            textBox2.Text = c.cashireName;
            textBox3.Text = c.cashierPhone;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.ReadOnly = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CashierDB cdb = new CashierDB();

            if(textBox3.Text != "")
            {
                cdb.UpdateCashierSelf(textBox1.Text, textBox3.Text);
                MessageBox.Show("Phone number updated.");
            }
            else
            {
                MessageBox.Show("Please fillup the text box.");
            }
        }
    }
}
