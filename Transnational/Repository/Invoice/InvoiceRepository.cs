using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Transnational.Models.VM;
using Transnational.Common;
using System.Data;
using Transnational.Models;

namespace Transnational.Repository.Invoice
{

    public class InvoiceRepository
    {

        public DataSet GetInvoice(string dbParam,int InvoiceId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            string query = "";
            //query = "Select * from tblInvoiceHeader Where InvoiceId=" + InvoiceId + "";
            query = " Select ISNULL(LanguageId ,0) As LanguageId,ISNULL(CompanyId ,'') As CompanyId,ISNULL(ContractCostCntrDprt,'') As ContractCostCntrDprt , ";
            query += " ISNULL(ContractId,0) As ContractId from tblInvoiceHeader Where InvoiceId=" + InvoiceId + " ";

            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                return ds;
            }
        }
        public DataSet GetInvoiceAddress(string dbParam, int InvoiceId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            string query = "";
            //query = "Select * from tblInvoiceHeader Where InvoiceId=" + InvoiceId + "";
            //query = " Select ISNULL(LanguageId ,0) As LanguageId,ISNULL(CompanyId ,'') As CompanyId,ISNULL(ContractCostCntrDprt,'') As ContractCostCntrDprt , ";
            //query += " ISNULL(ContractId,0) As ContractId from tblInvoiceHeader Where InvoiceId=" + InvoiceId + " ";
            query = "Select ISNULL(BranchName ,'') As BranchName, ISNULL (Department, '') As Department,";
            query += "ISNULL (ContactName, '') As ContactName, ISNULL (Address, '') As Address, ISNULL (Address2, '') As Address2,";
            query += "ISNULL (Address3, '') As Address3, ISNULL (Address4, '') As Address4, ISNULL (CountryId, 0) As CountryId,";
            query += "ISNULL (StateId, 0) As StateId, ISNULL (DistrictId, 0) As DistrictId,";
            query += "ISNULL (CityId, 0) As CityId, ISNULL (SpecialInstruction, '') As SpecialInstruction, ISNULL(Phone, '')As Phone,";
            query += "ISNULL (Phone1, '')As Phone1, ISNULL (Extension1, '') As Extension1, ISNULL (Extension2, '') As Extension2,";
            query += "ISNULL (PostalCode, '') As PostalCode   from tblInvoiceAddress Where InvoiceId =" + InvoiceId + "";


            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                return ds;
            }
        }
        public DataSet GetInvoiceDeliveryAddress(string dbParam, int InvoiceId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            string query = "";
            //query = "Select * from tblInvoiceHeader Where InvoiceId=" + InvoiceId + "";
            //query = " Select ISNULL(LanguageId ,0) As LanguageId,ISNULL(CompanyId ,'') As CompanyId,ISNULL(ContractCostCntrDprt,'') As ContractCostCntrDprt , ";
            //query += " ISNULL(ContractId,0) As ContractId from tblInvoiceHeader Where InvoiceId=" + InvoiceId + " ";
            query = "Select ISNULL(BranchName ,'') As BranchName, ISNULL (Department, '') As Department,";
            query += "ISNULL (ContactName, '') As ContactName, ISNULL (Address, '') As Address, ISNULL (Address2, '') As Address2,";
            query += "ISNULL (Address3, '') As Address3, ISNULL (Address4, '') As Address4, ISNULL (CountryId, 0) As CountryId,";
            query += "ISNULL (StateId, 0) As StateId, ISNULL (DistrictId, 0) As DistrictId,";
            query += "ISNULL (CityId, 0) As CityId, ISNULL (SpecialInstruction, '') As SpecialInstruction, ISNULL(Phone, '')As Phone,";
            query += "ISNULL (Phone1, '')As Phone1, ISNULL (Extension1, '') As Extension1, ISNULL (Extension2, '') As Extension2,";
            query += "ISNULL (PostalCode, '') As PostalCode   from  tblInvoiceDeliveryAddress Where InvoiceId =" + InvoiceId + "";


            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                return ds;

            }
        }
        public int InvoiceDetail ( InvoiceDetail InvD )
        {

            CommonFuns commnfun = new CommonFuns();
           // DbConnections conobj = new DbConnections();
            //var con = conobj.connection();
            
            DataSet ds = new DataSet();
            string query = "";
            query = "Insert Into tblInvoiceDetail(InvoiceId, ServiceId, Qty, Price) Values(" + InvD.InvoiceId + ", " + InvD.ServiceId + ", " + InvD.Qty + ", "+ InvD.Price + ")";
           
            DbConnections conobj = new DbConnections();
            var con = conobj.connection();
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            var result = command.ExecuteNonQuery();
            return 1;
            //com = new SqlCommand("spInsertNewOrder", con);
            //var invoiceId = (int)com.Parameters["@InvoiceId"].Value;
            //if (invoiceId >= 0)
            //{
              //  return invoiceId;
            //}
            //else
            //{
              //  return 0;
            //}
        }

        
        }
    }
    

    
