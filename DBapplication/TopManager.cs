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
    public partial class TopManager : Form
    {
        StartForm SF;
        public TopManager(StartForm sf)
        {
            InitializeComponent();
            SF = sf;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SF.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FireManager fm = new FireManager();
            fm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddManager f = new AddManager();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddBranch f = new AddBranch();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DeleteBranch f = new DeleteBranch();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UPDATEMANAGER f = new UPDATEMANAGER();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CreateManager f = new CreateManager();
            f.Show();
        }
    }
}