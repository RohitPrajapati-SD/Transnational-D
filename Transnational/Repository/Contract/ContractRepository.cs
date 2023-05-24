using System.Configuration;
using System.Data.SqlClient;
using Transnational.Models.VM;
using Transnational.Models;
using Transnational.Common;
using System.Data;
using System;

namespace Transnational.Repository.Contract
{
    public class ContractRepository
    {
        public DataSet GetContract(int CompanyId, int ContactId, string dbParam)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            //int ContactId = 8;
            //int CompanyId = 9;
            string query = "";
            query = "Select Distinct ContractId, (contractNo + '-' + isnull(ContractRef,'')) as ContractNo,BillingCycle,Address1 from tblContract ";
            query += " where ContractId In(Select Distinct S.ContractId From tblContractServices S inner join tblContractAccessRight A on S.CServiceId=A.CServiceId where A.ContactId='" + ContactId + "') and CompanyId =  " + CompanyId + " ";
            query += " And StartDate <='" + DateTime.Now.ToString("MM/dd/yyyy") + "' And ExpiryDate >='" + DateTime.Now.ToString("MM/dd/yyyy") + "'";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;

            }
        }
        public DataTable GetContractBillingDetail(GetContractBillingDetails GetContractDetailsObj)


        {

            DataSet ds = new DataSet();
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(GetContractDetailsObj.CD);
            DataTable dt = new DataTable("DataTable");
            dt.Columns.Add(new DataColumn("BillingEmail", typeof(string)));
            dt.Columns.Add(new DataColumn("Address", typeof(string)));
            SqlCommand com = new SqlCommand("spGetContractBillingDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CompanyId", GetContractDetailsObj.CompanyId);
            com.Parameters.AddWithValue("@ContactId", GetContractDetailsObj.ContactId);

            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drtbl in ds.Tables[0].Rows)
                    {
                        DataRow dr = dt.NewRow();
                        dr["BillingEmail"] = drtbl["BillingEmail"];
                        dr["Address"] = drtbl["Address"];
                        dt.Rows.Add(dr);
                    }
                    con.Close();
                }
                return dt;
            }  
        }
        //public DataSet GetContractBillingDetail(int CompanyId, int ContactId, string dbParam)
        //{
        //    DbConnections conobj = new DbConnections();
        //    var con = conobj.connection(dbParam);
        //    DataSet ds = new DataSet();
        //    //int ContactId = 8;
        //    //int CompanyId = 9;
        //    string query = "";
        //    query = "Select Distinct ContractId, (contractNo + '-' + isnull(ContractRef,'')) as ContractNo,BillingCycle,Address1 from tblContract ";
        //    query += " where ContractId In(Select Distinct S.ContractId From tblContractServices S inner join tblContractAccessRight A on S.CServiceId=A.CServiceId where A.ContactId='" + ContactId + "') and CompanyId =  " + CompanyId + " ";
        //    query += " And StartDate <='" + DateTime.Now.ToString("MM/dd/yyyy") + "' And ExpiryDate >='" + DateTime.Now.ToString("MM/dd/yyyy") + "'";
        //    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
        //    {
        //        con.Open();
        //        da.Fill(ds);
        //        con.Close();
        //        return ds;

        //    }
        //}
    }
}