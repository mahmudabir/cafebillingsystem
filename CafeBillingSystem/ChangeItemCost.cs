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
    public partial class ChangeItemCost : Form
    {
        ownerLoginEntity obj;
        public ChangeItemCost(ownerLoginEntity ole)
        {
            InitializeComponent();
            obj = ole;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ChangeItemCost_Load(object sender, EventArgs e)
        {
            ItemDB idb = new ItemDB();
            dataGridView1.DataSource = idb.GetItemList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            OwnerForm of = new OwnerForm(obj);
            of.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != null) && (textBox2.Text != null))
            {
                ItemDB idb = new ItemDB();

                idb.Update_Cost(textBox1.Text, textBox2.Text);
                dataGridView1.DataSource = idb.GetItemList();
            }
            else
            {
                MessageBox.Show("Please, Select an item.");
            }
        }
    }
}
