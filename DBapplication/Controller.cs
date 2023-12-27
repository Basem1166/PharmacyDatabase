using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

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
