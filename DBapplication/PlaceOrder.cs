using System;
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
    public partial class PlaceOrder : Form
    {
        Controller controllerObj;
        public PlaceOrder()
        {
            InitializeComponent();
            controllerObj = new Controller();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void PlaceOrder_Load(object sender, EventArgs e)
        {
            label4.Hide();
            comboBox1.DataSource = controllerObj.getemployees();
            comboBox1.DisplayMember = "EmployeeId";
            comboBox1.ValueMember = "EmployeeId";
            comboBox2.DataSource = controllerObj.getcustomerID();
            comboBox2.DisplayMember = "CustomerID";
            comboBox2.ValueMember = "CustomerID";
            comboBox3.DataSource = controllerObj.getbranchID();
            comboBox3.DisplayMember = "BranchID";
            comboBox3.ValueMember = "BranchID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Hide();
            bool c = true;
            int x = 0;
            if (textBox1.Text == "")
            {
                label4.Show();
                c = false;
            }
            else
            {
                if (!int.TryParse(textBox1.Text, out x))
                {
                    MessageBox.Show("The OrderID has to be a number");
                    c = false;
                }
            }
            if (c)
            {
                int f=controllerObj.addorder(x,Convert.ToInt32(comboBox1.SelectedValue),Convert.ToInt32(comboBox2.SelectedValue));
                if (f == 1)
                {
                    Addproducttoorder a= new Addproducttoorder();
                    a.orderid = x;
                    a.customerid = Convert.ToInt32(comboBox2.SelectedValue);
                    a.branchid= Convert.ToInt32(comboBox3.SelectedValue);
                    a.Show();
                }
                else MessageBox.Show("The order ID already exists");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
