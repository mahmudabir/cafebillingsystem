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
    public partial class OwnerUpdatePassword : Form
    {
        ownerLoginEntity obj;

        public OwnerUpdatePassword(ownerLoginEntity ole)
        {
            InitializeComponent();
            obj = ole;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text != ""))
            {
                ownerlogin ol = new ownerlogin();
                ol.Update_Password(obj.ownerId, textBox2.Text);
                MessageBox.Show("Password Changed.");
            }
            else
            {
                MessageBox.Show("Please insert a valid password.");
            }
        }

        private void OwnerUpdatePassword_Load(object sender, EventArgs e)
        {
            textBox1.Text = obj.ownerId;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowOwnerInfo soi= new ShowOwnerInfo(obj);
            soi.Show();
        }
    }
}
