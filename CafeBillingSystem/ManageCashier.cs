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
    public partial class ManageCashier : Form
    {
        ownerLoginEntity obj;
        public ManageCashier(ownerLoginEntity ole)
        {
            InitializeComponent();
            obj = ole;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CashierDB cdb = new CashierDB();
            cashier c = new cashier();
            cashierLoginEntity cle = new cashierLoginEntity();
            cashierlogin clogin = new cashierlogin();

            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != "") && (textBox6.Text != ""))
            {
                cashier c1 = new cashier();
                CashierDB cdb1 = new CashierDB();
                c1 = cdb1.getCashier(textBox1.Text);
                if(c1.cashierId== textBox1.Text)
                {
                    MessageBox.Show("Id has already been taken.");
                }
                else
                { 
                    c.cashierId = textBox1.Text;
                    c.cashireName = textBox2.Text;
                    c.cashierPhone = textBox3.Text;
                    c.cashierAddress = textBox4.Text;
                    c.cashierSalary = textBox5.Text;
                    c.cashierStatus = "active";
                    cdb.InsertCashier(c);

                    cle.cashierId = textBox1.Text;
                    cle.cashierPassword = textBox6.Text;
                    cle.cashierStatus = "active";
                    clogin.InsertUser(cle);

                    MessageBox.Show("Cashier Inserted.");

                    dataGridView1.DataSource = cdb.GetCashierList();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear(); 
                }
                

          

            }
            else
            {
                MessageBox.Show("Please fillup all text boxes.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            OwnerForm of = new OwnerForm (obj);
            of.Show();
        }

        private void ManageCashier_Load(object sender, EventArgs e)
        {
            CashierDB cdb = new CashierDB();
            dataGridView1.DataSource = cdb.GetCashierList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CashierDB cdb = new CashierDB();
            cashier c = new cashier();
            

            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != ""))
            {
                c.cashierId = textBox1.Text;
                c.cashireName = textBox2.Text;
                c.cashierPhone = textBox3.Text;
                c.cashierAddress = textBox4.Text;
                c.cashierSalary = textBox5.Text;
                c.cashierStatus = "active";
                cdb.UpdateCashier(c.cashierId, c.cashierSalary);

                

                MessageBox.Show("Cashier Updated.");

                dataGridView1.DataSource = cdb.GetCashierList();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            else
            {
                MessageBox.Show("Please fillup all text boxes.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CashierDB cdb = new CashierDB();
            cashier c = new cashier();
            cashierLoginEntity cle = new cashierLoginEntity();
            cashierlogin clogin = new cashierlogin();

            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != ""))
            {
                c.cashierId = textBox1.Text;
                c.cashireName = textBox2.Text;
                c.cashierPhone = textBox3.Text;
                c.cashierAddress = textBox4.Text;
                c.cashierSalary = textBox5.Text;
                c.cashierStatus = "active";
                cdb.DeleteCashier(c.cashierId);

                cle.cashierId = textBox1.Text;
                cle.cashierPassword = textBox6.Text;
                cle.cashierStatus = "active";
                clogin.DeleteCashierLogin(cle.cashierId);

                MessageBox.Show("Cashier Deleted.");

                dataGridView1.DataSource = cdb.GetCashierList();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            else
            {
                MessageBox.Show("Please fillup all text boxes.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
