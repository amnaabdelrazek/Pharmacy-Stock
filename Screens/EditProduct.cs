using PharmacyStock.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyStock.Screens
{
   
    public partial class EditProduct : Form
    {
        PharmacyStockEntities2 db = new PharmacyStockEntities2();
        int code = 0;
        
        //DB.Product pro;
        public EditProduct()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.Products.ToList();
        }



        private void EditProduct_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pharmacyStockDataSet25.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter1.Fill(this.pharmacyStockDataSet25.Products);
            dataGridView1.DataSource = db.Products.ToList();
        }


        //search about product with name.
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Products.Where(x => x.Name.Contains(textBox1.Text)).ToList();
        }


        //refresh the grid view.
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Products.ToList();
        }

        //show information in grid view
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                    return;
                var selectedRow = dataGridView1.CurrentRow;
                textBox5.Text = selectedRow.Cells[1].Value.ToString();
                textBox2.Text = selectedRow.Cells[0].Value.ToString();
                textBox3.Text = selectedRow.Cells[2].Value.ToString();
                textBox4.Text = selectedRow.Cells[3].Value.ToString();
            }
            catch
            {

            }
        }


        //change and update informaton
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                code = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var pros = db.Products.FirstOrDefault(x => x.code == code);
                pros.Name = textBox5.Text;
                pros.Price = float.Parse(textBox3.Text);
                pros.code = int.Parse(textBox2.Text);

                db.SaveChanges();
                dataGridView1.DataSource = db.Products.ToList();
                MessageBox.Show("Modified successfully");
            }
            catch
            {
                MessageBox.Show("Something is incorrect.");
            }
        }

       
        //go to add form and close current form
        private void button5_Click(object sender, EventArgs e)
        {

            if (user.possition == "manager" || user.possition == "pharmacist")
            {
                this.Close();
                Thread th = new Thread(openformInsertProduct);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Only Manager or pharmacist can access .");
            }
        }
        void openformInsertProduct()
        {
            Application.Run(new Insert_New_Product());
        }



        //when select product the information show in textboxs
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DataSource = db.Products.ToList();
        }

        

        //go to home form and close current form
        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openformHome);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void openformHome()
        {
            Application.Run(new Home());
        }
    }
}
