using PharmacyStock.DB;
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
using System.Threading;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PharmacyStock.Screens
{
    public partial class Insert_New_Supplier : Form
    {
        PharmacyStockEntities2 db = new PharmacyStockEntities2();
        
        public Insert_New_Supplier()
        {
            InitializeComponent();
        }

        private void Insert_New_Suplier_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != null || textBox2.Text != null || textBox4.Text != null || textBox5.Text != null || textBox6.Text != null)
                {
                    Supplier sup = new Supplier();
                    string name = textBox1.Text;
                    int id= int.Parse(textBox2.Text);
                    bool flag = db.Suppliers.Any(x => x.ID == id);
                    if (!flag)
                    {
                        sup.ID = id;

                        if (IsValidName(name) == true)
                        {
                            sup.Name = name;
                        }
                        else
                        {
                            MessageBox.Show("The name is not valid.\nThis should contain only letters.");
                        }

                        sup.Addres = textBox4.Text;
                        string phone = textBox5.Text;
                        if (IsValidPhone(phone) == true)
                        {
                            sup.Phone = phone;
                        }
                        else
                        {
                            MessageBox.Show("The phone number is not valid.\nThis should contain only number with length of 11");
                        }
                        string email = textBox6.Text;
                        if (IsValidEmail(email) == true)
                        {
                            sup.Email = email;
                        }
                        else
                        {
                            MessageBox.Show("The email is not valid.");
                        }
                        db.Suppliers.Add(sup);
                        db.SaveChanges();
                        MessageBox.Show("Done");
                    }
                    else
                    {
                        MessageBox.Show("The id is already exsit");
                    }
                }
                else
                {
                    MessageBox.Show("Please Complete required data.");
                }
            }
            catch
            {
                MessageBox.Show("Something is incorrect.");
            }
                textBox1.Text= string.Empty;
                textBox2.Text= string.Empty;
                textBox4.Text= string.Empty;
                textBox5.Text= string.Empty;
                textBox6.Text= string.Empty;
            
        }
        public bool IsValidEmail(string email)
        {
            string pattern = @"[a-zA-Z0-9\._%+-]+@[a-zA-Z0-9.-]+";
            return Regex.IsMatch(email, pattern);
        }
        public bool IsValidName(string name)
        {
            string pattern = @"[a-zA-Z]";
            return Regex.IsMatch(name, pattern);
        }
        public bool IsValidPhone(string phone)
        {
            string pattern = @"^\d{11}$";
            return Regex.IsMatch(phone, pattern);
        }
        void openform()
        {
            Application.Run(new EditSupplier());
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

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

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openformEditSup);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void openformEditSup()
        {
            Application.Run(new EditSupplier());
        }
    }
}
