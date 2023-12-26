using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;

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
        public int deleteEmployee(int ID)
        {
            string SPN = StoredProcedures.FIREEMPLOYEE;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@SSN", ID);
            return dbMan.ExecuteNonQuery(SPN, Parameters);
        }

    }
}
