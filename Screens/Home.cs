﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PharmacyStock.Screens;

namespace PharmacyStock.Screens
{
    public partial class Home : Form
    {

        //when login show some information about who login
        public Home()
        {
            InitializeComponent();
            label1.Text = PharmacyStock.user.name;
            pictureBox1.ImageLocation = PharmacyStock.user.image;
            label3.Text=PharmacyStock.user.phone;
            label4.Text=PharmacyStock.user.email;
            label5.Text=PharmacyStock.user.possition;
        }


        //access managers and pharmacists only can open form edit product.
        private void button6_Click(object sender, EventArgs e)
        {
            if (user.possition == "manager"||user.possition=="pharmacist")
            {
                this.Close();
                Thread th = new Thread(openformEditProduct);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Only Manager or pharmacist can access .");
            }
        }
        void openformEditProduct()
        {
            Application.Run(new EditProduct());
        }


        //to close app
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
                 this.Close();
        }


        //
        private void addNewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            EditEmployee ins = new EditEmployee();
            ins.Show();
        }


        //open add new product form
        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
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



        // open edit employee form
        private void button4_Click(object sender, EventArgs e)
        {
            if (user.possition == "manager")
            {
                this.Close();
                Thread th = new Thread(openformEditEmployee);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Only Manager can access .");
            }
        }
        void openformEditEmployee()
        {
            Application.Run(new EditEmployee());
        }


        // open edit supplier form
        private void button5_Click(object sender, EventArgs e)
        {
            if (user.possition == "manager")
            {
                this.Close();
                Thread th = new Thread(openformEditSupplier);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Only Manager can access .");
            }

        }
        void openformEditSupplier()
        {
            Application.Run(new EditSupplier());
        }



        private void addNewSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            EditSupplier supp=new EditSupplier();
            supp.Show();
        }

        //hidden form to show when click on button
        private void Home_Load(object sender, EventArgs e)
        {
            panel1.Visible= true;
        }


        //private void listProductToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //    EditProduct products=new EditProduct();
        //    products.Show();
        //}


        // open edit product form and close current form
        private void manageProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user.possition == "manager" || user.possition == "pharmacist")
            {
                this.Close();
                Thread th = new Thread(openformEditProduct);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Only Manager or pharmacist can access .");
            }
        }
       

        //open edit employee form and close current form
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (user.possition == "manager")
            {
                this.Close();
                Thread th = new Thread(openformEditEmployee);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Only Manager can access .");
            }
        }
        

        //open add new employee form and close home
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (user.possition == "manager")
            {
                this.Close();
                Thread th = new Thread(openformInsertNewEmployee);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Only Manager can access .");
            }
        }
        void openformInsertNewEmployee()
        {
            Application.Run(new Insert_New_Employee());
        }


        // open add new suppliers and close home
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (user.possition == "manager")
            {
                this.Close();
                Thread th = new Thread(openformInsertSupplier);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Only Manager can access .");
            }
        }
        void openformInsertSupplier()
        {
            Application.Run(new Insert_New_Supplier());
        }



        //open edit suppliers form and close home
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (user.possition == "manager")
            {
                this.Close();
                Thread th = new Thread(openformEditSupplier);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Only Manager can access .");
            }
        }
        


        //open sale bill form and close home
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openformSaleBill);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void openformSaleBill()
        {
            Application.Run(new SaleBill());
        }



        //open Procurement bill form and close home
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openformProcBill);
            th.SetApartmentState(ApartmentState.STA);
            th.Start(); 
        }
        void openformProcBill()
        {
            Application.Run(new ProcBill());
        }


        //open Procurement bill form and close home
        private void addNewTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openformProcBill);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }


        //open Procurement bill form and close home
        private void listTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openformListProcBill);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void openformListProcBill()
        {
            Application.Run(new transaction());
        }


        //open sale bill form and close home
        private void addNewSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openformSaleBill);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }



        //open sale bill list form and close home
        private void listSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openformListSaleBill);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void openformListSaleBill()
        {
            Application.Run(new ListSaleBill()) ;
        }


        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        // logout from current and go to login form 
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openformLogin);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void openformLogin()
        {
            Application.Run(new Login());
        }


        //show user information panel 
        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }
    }
}
