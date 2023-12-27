using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DBapplication
{
    public partial class StartForm : Form
    {
        Controller controllerobj;
        public StartForm()
        {
            InitializeComponent();
            controllerobj = new Controller();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            UpdatePrice u = new UpdatePrice();
            u.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox2.Text;
            string ID = textBox1.Text;
            
            string ret = controllerobj.Login(ID,password);

            if (ret == "")
            {
                label3.Visible = true;
            }
            else
            {
                MessageBox.Show("Login Succesful! Redirecting....");
                Thread.Sleep(500);
                if (ret == "Manager   ")
                {
                    //start manager form
                }
                else if (ret == "TopManager")
                {
                    // start topmanager form
                }
                else
                {
                    //start employee form
                }
            }

            
        }

    }
}
