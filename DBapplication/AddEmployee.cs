﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBapplication
{
    public partial class AddEmployee : Form
    {
        Controller controllerObj;
        public AddEmployee()
        {
            InitializeComponent();
            controllerObj = new Controller();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            label9.Hide();
            label10.Hide(); 
            label11.Hide();
            label12.Hide();
            label13.Hide(); 
            label14.Hide();
            label15.Hide();
            comboBox1.DataSource=controllerObj.getbranchID();
            comboBox1.DisplayMember= "BranchID";
            comboBox1.ValueMember = "BranchID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label15.Hide();
            bool c = true;
            if (textBox1.Text == "")
            {
                label9.Show();
                c = false;
            }
            if (textBox2.Text == "")
            {
                label10.Show(); 
                c = false;
            }
            if (textBox3.Text == "")
            {
                label11.Show();
                c = false;
            }
            if (textBox4.Text == "")
            {
                label12.Show();
                c = false;
            }
            if (textBox5.Text == "")
            { 
                label13.Show();
                c = false; 
            }
            if (textBox6.Text == "")
            {
                label14.Show();
                c = false;
            }
            if (textBox7.Text == "")
            {
                label15.Show(); 
                c = false;
            }
            int x,y,z;
            if (!int.TryParse(textBox1.Text, out x))
            {
                MessageBox.Show("The Employee ID has to be an integer");
                c = false;
            }
            if (!int.TryParse(textBox3.Text, out y))
            {
                MessageBox.Show("The Salary has to be an integer");
                c = false;
            }
            if (!int.TryParse(textBox5.Text, out z))
            {
                MessageBox.Show("The Phone Number has to be an integer");
                c = false;
            }
            if (textBox7.Text.Length < 8)
            {
                MessageBox.Show("The Password has to be more than 8 characters");
                c = false;
            }
            if (textBox5.Text.Length != 11)
            {
                MessageBox.Show("The Phone number has to be 11 number");
                c = false;
            }

            if (c)
            {
                int f=controllerObj.insertEmployee(x, textBox2.Text, y, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, Convert.ToInt32(comboBox1.SelectedValue));
                if (f == 1)
                    MessageBox.Show("Done");
                else
                    MessageBox.Show("This ID is already existing");
            }
              
        }
    }
}