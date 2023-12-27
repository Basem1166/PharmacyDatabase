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
        public DataTable getproductids()
        {
            string SPN = StoredProcedures.GETPRODUCTIDS;
            return dbMan.ExecuteReader(SPN, null);

        }

        public DataTable findproduct(int productID)
        {
            string SPN = StoredProcedures.FINDPRODUCT;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ProductID", productID);
            return dbMan.ExecuteReader(SPN, Parameters);

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
        public string Login(string ID, string Password )
        {
            string SPN = StoredProcedures.GETLOGINROLE;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@EmployeeID", ID);
            Parameters.Add("@Password", Password);
            return dbMan.ExecuteScalar(SPN, Parameters).ToString();


        }

        public int addBranch(float budget, string location, int managerID)
        {
            string SPN = StoredProcedures.ADDBRANCH;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Budget", budget);
            Parameters.Add("@Location", location);
            Parameters.Add("@EmployeeID", managerID);
            return dbMan.ExecuteNonQuery(SPN, Parameters);
        }

        public int deleteBranch(int branchID)
        {
            string SPN = StoredProcedures.DELETEBRANCH;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@BranchID", branchID);
            return dbMan.ExecuteNonQuery(SPN, Parameters);
        }

        public int addReview(int reviewID, string description, float rating, int customerID, int branchID)
        {
            string SPN = StoredProcedures.ADDCOMPLAINT;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ReviewID", reviewID);
            Parameters.Add("@Description", description);
            Parameters.Add("@Rating", rating);
            Parameters.Add("@CustomerID", customerID);
            Parameters.Add("@BranchId", branchID);
            return dbMan.ExecuteNonQuery(SPN, Parameters);
        }

        public int addInBody(int inBodyID, float weight, float height, int age, string gender, float muscleMass, float fatPercent, int cusotmerID)
        {
            string SPN = StoredProcedures.ADDINBODY;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@InBodyID", inBodyID);
            Parameters.Add("@Weight", weight);
            Parameters.Add("@Height", height);
            Parameters.Add("@Age", age);
            Parameters.Add("@Gender", gender);
            Parameters.Add("@MuscleMass", muscleMass);
            Parameters.Add("@FatPercent", fatPercent);
            Parameters.Add("@CustomerID", cusotmerID);
            return dbMan.ExecuteNonQuery(SPN, Parameters);
        }

        public int approveRefund(int orderID, string description, int employeeID)
        {
            string SPN = StoredProcedures.APPROVEREFUND;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@OrderID", orderID);
            Parameters.Add("@Description", description);
            Parameters.Add("@EmployeeID", employeeID);
            return dbMan.ExecuteNonQuery(SPN, Parameters);
        }

    }
}
