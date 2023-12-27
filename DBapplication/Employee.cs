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
    public partial class Employee : Form
    {
        StartForm SF;
        public Employee(StartForm sf)
        {
            InitializeComponent();
            SF = sf;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SF.Show();
            this.Close();
        }
    }
}
