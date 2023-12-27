﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DBapplication
{
    public partial class NewSubscriptions : Form
    {
        Controller controllerObj;
        List<DateTime> tempxValues;
        List<string> xValues;
        List<int> yValues;
        public NewSubscriptions()
        {
            InitializeComponent();
            controllerObj = new Controller();
            DataTable dt = controllerObj.newSubscriptions();
            tempxValues = new List<DateTime>();
            yValues = new List<int>();
            tempxValues = dt.AsEnumerable().Where(row => row["month"] != DBNull.Value && row["month"] is string).Select(row => ParseDateString(row["month"].ToString())).ToList();
            
            xValues = tempxValues.Select(date => date.ToString("yyyy-MM")).ToList();
            yValues = dt.AsEnumerable().Select(row => row.Field<int>("New_Subscribers")).ToList();

        }

        private void NewSubscriptions_Load(object sender, EventArgs e)
        {
            chart1.Series["New Subscribers"].Points.DataBindXY(xValues, yValues);
        }

        static DateTime ParseDateString(string dateString)
        {
            return DateTime.ParseExact(dateString, "yyyy-MM", CultureInfo.InvariantCulture);
        }
    }
}
