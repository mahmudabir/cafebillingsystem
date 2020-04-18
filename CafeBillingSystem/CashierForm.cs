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
    public partial class CashierForm : Form
    {
        cashierLoginEntity obj;
        
        public CashierForm(cashierLoginEntity ole)
        {
            InitializeComponent();
            obj = ole;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowCashierInfo sci = new ShowCashierInfo(obj);
            sci.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            BillPage bp = new BillPage(obj);
            bp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hp = new HomePage();
            hp.Show();
        }

        private void CashierForm_Load(object sender, EventArgs e)
        {

        }
    }
}
