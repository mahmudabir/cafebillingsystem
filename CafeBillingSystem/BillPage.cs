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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace CafeBillingSystem
{
    public partial class BillPage : Form
    {
        public string id;
        public string id1;
        public int subamount = 0;
        public int totalamount = 0;

        cashierLoginEntity obj;
        public BillPage(cashierLoginEntity cle)
        {
            InitializeComponent();
            obj = cle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage home_page = new HomePage();
            home_page.Show();
        }

        private void BillPage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cafedbDataSet.billline' table. You can move, or remove it, as needed.
            this.billlineTableAdapter.Fill(this.cafedbDataSet.billline);
            timer1.Start();
            DateLabel.Text = DateTime.Now.ToShortDateString();
            TimeLabel.Text = DateTime.Now.ToLongTimeString();

            id = createId();

            dataGridView1.DataSource = null;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateLabel.Text = DateTime.Now.ToShortDateString();
            TimeLabel.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage home_page = new HomePage();
            home_page.Show();
        }

        public string createId()
        {
            Random xx = new Random();
            int y = xx.Next(0, 100000);
            string a = "B-" + y;
            return a;
        }

        public string createId1()
        {
            Random xx = new Random();
            int y = xx.Next(0, 100000);
            string a = "BL-" + y;
            return a;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BillLineDB bldb = new BillLineDB();
            ItemDB idb = new ItemDB();

            if((textBox17.Text!="") && (textBox18.Text != ""))
            {
                itemEntity a;
                a = idb.getItem(textBox17.Text);
                if((a!=null) && (a.itemId==textBox17.Text))
                {
                    subamount = Convert.ToInt32(a.itemCost) * Convert.ToInt32(textBox18.Text);
                    totalamount = totalamount + subamount;
                    BillLineEntity ble = new BillLineEntity();
                    id1 = createId1();
                    ble.billLineId = id1;

                    ble.billId = id;

                    ble.itemId = a.itemId;
                    ble.amount = subamount.ToString();
                    subamount = 0;
                    bldb.InsertBillLine(ble);
                    dataGridView1.DataSource = bldb.GetBillLineList(id);

                }
                else
                {
                    MessageBox.Show("Please fill All the boxes.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BillDB bdb = new BillDB();
            BillEntity ble = new BillEntity();
            textBox21.Text = totalamount.ToString();
            ble.billId = id;
            ble.billAmount = totalamount.ToString();
            totalamount = 0;
            bdb.InsertBill(ble);
            MessageBox.Show("Bill ID: " + ble.billId);

            //dataGridView1.DataSource = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CashierForm cf = new CashierForm(obj);
            cf.Show();
        }


        public void exporttopdf(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(dgw.Columns.Count);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text= new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            //add header
            foreach (DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);

            }

            //add data row
            foreach(DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdftable.AddCell(new Phrase(cell.Value.ToString(), text));

                }
            }

            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = filename;
            savefiledialoge.DefaultExt = ".pdf";
            if(savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdftable);
                    string total = Convert.ToString(textBox21.Text);
                    pdfdoc.Add(new Paragraph("Total = " + total + " TK"));
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            exporttopdf(dataGridView1, "Text");
            dataGridView1.DataSource = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
