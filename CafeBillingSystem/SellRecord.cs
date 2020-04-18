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
    
    public partial class SellRecord : Form
    {
        ownerLoginEntity obj;
        public SellRecord(ownerLoginEntity ole)
        {
            InitializeComponent();
            obj = ole;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            OwnerForm of = new OwnerForm(obj);
            of.Show();
        }

        private void SellRecord_Load(object sender, EventArgs e)
        {
            BillDB bdb = new BillDB();
            dataGridView1.DataSource = bdb.GetItemList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
