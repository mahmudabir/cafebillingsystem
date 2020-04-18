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
    public partial class ShowOwnerInfo : Form
    {
        ownerLoginEntity owner;
        public ShowOwnerInfo(ownerLoginEntity o)
        {
            InitializeComponent();
            owner = o;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            OwnerForm owner_form = new OwnerForm(owner);
            owner_form.Show();
        }

        private void ShowOwnerInfo_Load(object sender, EventArgs e)
        {
            owner obj = new owner();
            Owner abj = new Owner();

            obj = abj.getOwner(owner.ownerId);
            textBox1.Text = obj.ownerId;
            textBox2.Text = obj.ownerName;
            textBox3.Text = obj.ownerPhone;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            OwnerUpdatePassword oup = new OwnerUpdatePassword(owner);
            oup.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.ReadOnly = false;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox3.Text != ""))
            {
                Owner odb = new Owner();
                odb.Updae_Phone(owner.ownerId, textBox3.Text);
                MessageBox.Show("Phone Number Changed.");
            }
            else
            {
                MessageBox.Show("Please fill up the text box.");
            }
        }
    }
}
