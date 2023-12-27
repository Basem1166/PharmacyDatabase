﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Xml.Linq;

namespace DBapplication
{
    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }

      
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }
        public DataTable getbranchID()
        {
            string SPN = StoredProcedures.GETBRANCHIDS;
            return dbMan.ExecuteReader(SPN, null);

        }
        public DataTable getemployeeID()
        {
            string SPN = StoredProcedures.GETEMPLOYEEID;
            return dbMan.ExecuteReader(SPN, null);

        }
        public DataTable getmanagers()
        {
            string SPN = StoredProcedures.GETMANAGERS;
            return dbMan.ExecuteReader(SPN, null);

        }
        public DataTable getproductids()
        {
            string SPN = StoredProcedures.GETPRODUCTIDS;
            return dbMan.ExecuteReader(SPN, null);

        }
        public DataTable getcustomerID()
        {
            string SPN = StoredProcedures.GETCUSTOMERIDS;
            return dbMan.ExecuteReader(SPN, null);

        }
        public DataTable getemployees()
        {
            string SPN = StoredProcedures.GETEMPLOYEES;
            return dbMan.ExecuteReader(SPN, null);

        }
        public DataTable getbatchids(int branchid)
        {
            string SPN = StoredProcedures.GETBATCHIDS;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@BRANCHID", branchid);
            return dbMan.ExecuteReader(SPN, Parameters);

        }
        public int addorder(int OrderID,int EmployeeID , int CustomerID)
        {
            string SPN = StoredProcedures.ADDORDER;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ORDERID", OrderID);
            Parameters.Add("@EMPLOYEEID", EmployeeID);
            Parameters.Add("@CUSTOMERID", CustomerID);
            return dbMan.ExecuteNonQuery(SPN, Parameters);
        }
        public int addproductinorder(int OrderID, int BatchID, int Quantity)
        {
            string SPN = StoredProcedures.ADDPRODUCTINORDER;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ORDERID", OrderID);
            Parameters.Add("@BATCHID", BatchID);
            Parameters.Add("@QUANTITY", Quantity);
            return dbMan.ExecuteNonQuery(SPN, Parameters);
        }
        public object getbdao(int OrderID)
        {
            string SPN = StoredProcedures.GETBDAO;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ORDERID", OrderID);
            int x = Convert.ToInt32(dbMan.ExecuteScalar(SPN, Parameters));
            return x;
        }
        public object getbd(int OrderID)
        {
            string SPN = StoredProcedures.GETBD;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ORDERID", OrderID);
            int x=Convert.ToInt32(dbMan.ExecuteScalar(SPN, Parameters));
            return x;
        }
        public object getafter(int OrderID)
        {
            string SPN = StoredProcedures.GETTOTAL;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ORDERID", OrderID);
            int x = Convert.ToInt32(dbMan.ExecuteScalar(SPN, Parameters));
            return x;
        }
        public DataTable getproductsinorder(int OrderID)
        {
            string SPN = StoredProcedures.VIEWPRODUCTSINORDER;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ORDERID", OrderID);
            return dbMan.ExecuteReader(SPN, Parameters);
        }
        public object getQUANTITY(int BatchID)
        {
            string SPN = StoredProcedures.GETQUANTITY;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@BATCHID", BatchID);
            int x = Convert.ToInt32(dbMan.ExecuteScalar(SPN, Parameters));
            return x;
        }
        public object gettier(int CustomerID)
        {
            string SPN = StoredProcedures.GETTIER;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@CUSTOMERID", CustomerID);
            int x = Convert.ToInt32(dbMan.ExecuteScalar(SPN, Parameters));
            return x;
        }
        public int calculateorder(int  OrderID,int customerID,ref int BDAO,ref int  BD,ref int A) {
            string SPN = StoredProcedures.CALCULATETOTAL;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ORDERID", OrderID);
            Parameters.Add("@CUSTOMERID", customerID);
            Parameters.Add("@BEFOREDISCOUNTSANDOFFER", BDAO);
            Parameters.Add("@BEFOREDISCOUNTS", BD);
            Parameters.Add("@AFTER", A);
            return dbMan.ExecuteNonQuery(SPN, Parameters);
        } 
        public int insertEmployee(int ID, string Name, float Salary, string Role, string phone, string Address, string Password, int BranchID)
        {
            string SPN = StoredProcedures.ADDEMPLOYEE;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@EMPLOYEEID", ID);
            Parameters.Add("@EMPLOYEENAME", Name);
            Parameters.Add("@SALARY", Salary);
            Parameters.Add("@ROLE", Role);
            Parameters.Add("@PHONENUMBER", phone);
            Parameters.Add("@ADDRESS", Address);
            Parameters.Add("@PASSWORD", Password);
            Parameters.Add("@BRANCHID", BranchID);
            return dbMan.ExecuteNonQuery(SPN, Parameters);
        }
        public int insertmanager(int ID, string Name, float Salary, string Role, string phone, string Address, string Password, int BranchID)
        {
            string SPN = StoredProcedures.ADDMANAGER;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@EMPLOYEEID", ID);
            Parameters.Add("@EMPLOYEENAME", Name);
            Parameters.Add("@SALARY", Salary);
            Parameters.Add("@ROLE", Role);
            Parameters.Add("@PHONENUMBER", phone);
            Parameters.Add("@ADDRESS", Address);
            Parameters.Add("@PASSWORD", Password);
            Parameters.Add("@BRANCHID", BranchID);
            return dbMan.ExecuteNonQuery(SPN, Parameters);
        }
        public int updatemanager(int ID,int BranchId)
        {
            string SPN = StoredProcedures.UPDATEMANAGER;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@SSN", ID);
            Parameters.Add("@BRANCHID", BranchId);
            return dbMan.ExecuteNonQuery(SPN, Parameters);
        }
        public int updateprice(int PID, float Price)
        {
            string SPN = StoredProcedures.UPDATEPRICE;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@PID", PID);
            Parameters.Add("@NEWPRICE", Price);
            return dbMan.ExecuteNonQuery(SPN, Parameters);
        }
        public int upgradetier(int CustomerID)
        {
            string SPN = StoredProcedures.UPGRADETIER;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@CUSTOMERID", CustomerID);
            return dbMan.ExecuteNonQuery(SPN, Parameters);
        }
        public int deleteEmployee(int ID)
        {
            string SPN = StoredProcedures.FIREEMPLOYEE;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@SSN", ID);
            return dbMan.ExecuteNonQuery(SPN, Parameters);
        }
        public int deletemanager(int ID)
        {
            string SPN = StoredProcedures.FIREMANAGER;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@SSN", ID);
            return dbMan.ExecuteNonQuery(SPN, Parameters);
        }
        public int insertcustomer(int ID,string name,string address,string phonenumber)
        {
            string SPN = StoredProcedures.ADDCUSTOMER;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@CUSID", ID);
            Parameters.Add("@CUSTOMERNAME", name);
            Parameters.Add("@ADDRESS", address);
            Parameters.Add("@PHONENUMBER", phonenumber);
            return dbMan.ExecuteNonQuery(SPN, Parameters);
        }

    }
}
