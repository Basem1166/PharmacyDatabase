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
    public partial class ApproveRefund : Form
    {
        Controller controllerObj;
        public ApproveRefund()
        {
            InitializeComponent();
            controllerObj = new Controller();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(OrderIDTextBox.Text == "" || DescriptionTextBox.Text == "" || EmployeeIDTextBox.Text == "")
            {
                MessageBox.Show("Please enter all the information");
                return;
            }
            int orderID, employeeID;
            try { orderID = int.Parse(OrderIDTextBox.Text); }
            catch { MessageBox.Show("Enter a Valid Order ID"); return; }

            try { employeeID = int.Parse(EmployeeIDTextBox.Text); }
            catch { MessageBox.Show("Enter a Valid Employee ID"); return; }

            int check = controllerObj.approveRefund(orderID, DescriptionTextBox.Text, employeeID);
            if (check == 0) { MessageBox.Show("Refund not approved. Make sure all the data entered were valid."); }
            else
            {
                MessageBox.Show("Refund Approved Successfully");
                OrderIDTextBox.Text = "";
                DescriptionTextBox.Text = "";
                EmployeeIDTextBox.Text = "";
            }
        }
    }
}
