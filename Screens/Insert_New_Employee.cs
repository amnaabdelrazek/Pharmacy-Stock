using PharmacyStock.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Security.Cryptography;
using BCrypt.Net;


namespace PharmacyStock.Screens
{
    public partial class Insert_New_Employee : Form
    {
        PharmacyStockEntities2 db = new PharmacyStockEntities2();
        string imagePath="";
        public Insert_New_Employee()
        {
            InitializeComponent();
            
        }

        private void Insert_New_Employee_Load(object sender, EventArgs e)
        {
            
        }




        //take information from textboxs and insert it in database
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text != null || textBox2.Text != null || textBox3.Text != null || textBox4.Text != null || textBox5.Text != null || textBox6.Text != null)
                {
                    employee emp = new employee();
                    string name = textBox1.Text;
                    if (IsValidName(name) == true)
                    {
                        emp.Name = name;
                    }
                    else
                    {
                        MessageBox.Show("The name is not valid.\nThis should contain only letters.");
                    }
                    string password = textBox2.Text;
                    string hashedPassword = HashPassword(password);
                    emp.Password = hashedPassword;
                    string NID = textBox3.Text;
                    if (IsValidNID(NID) == true)
                    {
                        emp.NationalID = NID;
                    }
                    else
                    {
                        MessageBox.Show("The national number is not valid.\nThis should contain 14 number.");
                    }

                    emp.Address = textBox4.Text;
                    emp.position = comboBox1.Text.ToString();
                    emp.DateOfBirth = dateTimePicker1.Value.Date;
                    string email = textBox5.Text;
                    if (IsValidEmail(email) == true)
                    {
                        emp.Email = email;
                    }
                    else
                    {
                        MessageBox.Show("The email is not valid.");
                    }

                    string phone = textBox6.Text;

                    if (IsValidPhone(phone) == true)
                    {
                        emp.phone = phone;
                    }
                    else
                    {
                        MessageBox.Show("The phone number is not valid.\nThis should contain only number and begin with 01");
                    }

                    emp.image = imagePath;


                    if (imagePath != "")
                    {

                        string newPath = Environment.CurrentDirectory + "\\images\\Users\\" + emp.NationalID + ".jpg";
                        File.Copy(imagePath, newPath);
                        emp.image = imagePath;

                    }
                    db.employees.Add(emp);
                    db.SaveChanges();

                    MessageBox.Show("Done");
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    textBox5.Text = string.Empty;
                    textBox6.Text = string.Empty;
                    comboBox1.SelectedIndex = -1;
                    pictureBox1.Image = null;
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
            string pattern = @"^01\d{9}$";
            return Regex.IsMatch(phone, pattern);
        }
        public bool IsValidNID(string NID)
        {
            string pattern = @"^\d{14}$"; ;
            return Regex.IsMatch(NID, pattern);
        }
        void openform()
        {
            Application.Run(new EditEmployee());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                if (op.ShowDialog() == DialogResult.OK)
                {
                    imagePath = op.FileName;
                    pictureBox1.Image = Image.FromFile(imagePath);
                }
            }
            catch {
                MessageBox.Show("This is not image.");
            }
        }


        // open home form and close current form
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


        // open edit employee form and close current form
        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openformEditEmp);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void openformEditEmp()
        {
            Application.Run(new EditEmployee());
        }



        // hashing passowerd before insert it in database
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
