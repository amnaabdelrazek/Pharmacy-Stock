﻿using PharmacyStock.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace PharmacyStock.Screens
{
    public partial class Insert_New_Product : Form
    {
        PharmacyStockEntities2 db = new PharmacyStockEntities2();


        public Insert_New_Product()
        {
            InitializeComponent();
        }

        private void Insert_New_Product_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text!= null || textBox2.Text != null || textBox3.Text != null)
                {
                    Product pro = new Product();
                    pro.Name = textBox1.Text;
                    int code= int.Parse(textBox2.Text);
                    bool flag =db.Products.Any(x=>x.code==code);
                    if (!flag)
                    {
                        pro.code = code;
                        pro.Price = float.Parse(textBox3.Text);
                        db.Products.Add(pro);
                        db.SaveChanges();
                        MessageBox.Show("Done");

                    }
                    else
                    {
                        MessageBox.Show("The code is already exsit");
                    }
                }
                else
                {
                    MessageBox.Show("Please Complete required data.");
                }
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
            }
            catch
            {
                MessageBox.Show("Something is incorrect.");
            }
        }


        private void button7_Click(object sender, EventArgs e)
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

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openformEditPro);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void openformEditPro()
        {
            Application.Run(new EditProduct());
        }
    }
}
