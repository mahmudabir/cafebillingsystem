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
    public partial class OwnerLogin : Form
    {
        public OwnerLogin()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

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
            ownerLoginEntity olentity = new ownerLoginEntity();
            ownerlogin ol = new ownerlogin();

            olentity = ol.getOwner(textBox1.Text, textBox2.Text);

            if((olentity != null)  && (olentity.ownerId==textBox1.Text) && (olentity.ownerStatus=="active"))
            {
                this.Hide();
                OwnerForm of = new OwnerForm(olentity);
                of.Show();
                MessageBox.Show("Owner ID "+olentity.ownerId);
            }
            else
            {
                MessageBox.Show("Incorrect ID or Password");
            }

        }

        private void OwnerLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
