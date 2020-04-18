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
    public partial class OwnerForm : Form
    {
        ownerLoginEntity owner;
        public OwnerForm(ownerLoginEntity o)
        {
            InitializeComponent();
            owner = o;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage home_page = new HomePage();
            home_page.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageCashier mc = new ManageCashier(owner);
            mc.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ShowOwnerInfo show_owner_info = new ShowOwnerInfo(owner);
            show_owner_info.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeItemCost cic = new ChangeItemCost(owner);
            cic.Show();
        }

        private void OwnerForm_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            SellRecord sr = new SellRecord(owner);
            sr.Show();
        }
    }
}
