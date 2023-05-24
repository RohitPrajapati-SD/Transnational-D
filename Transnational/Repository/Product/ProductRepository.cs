using System.Configuration;
using System.Data.SqlClient;
using Transnational.Models.VM;
using Transnational.Common;
using System.Data;
using System;
namespace Transnational.Repository.Product
{
    public class ProductRepository
    {



        public DataSet GetProduct(string dbParam, int ContractId, int LanguageId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            string query = "";
            //query = "select * from tblProductPrice PC where PC.SeqNo in (select CS.ServiceId from tblContractServices CS ";
            //query += "where CS.ContractId = " + ContractId + ") and PC.LanguageId=" + LanguageId + "  ";

            query = "select * from tblProductPrice PC where PC.ClientOScreen='1' and PC.SeqNo in ";
            query += "(select CS.ServiceId from tblContractServices CS where CS.ContractId = " + ContractId + ") and PC.LanguageId=" + LanguageId + "";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                return ds;
            }
        }


        public DataSet GetProduct1(string dbParam, int ContractId, int LanguageId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            string query = "";
            query = "select * from tblProductPrice PC where PC.SeqNo in (select CS.ServiceId from tblContractServices CS where CS.ContractId = " + ContractId + ") and PC.LanguageId = " + LanguageId + "";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                return ds;
            }
        }
        //==============================navdeep///////////////////////////================================//
        public DataSet GetContractReturnServices(string dbParam,int ContractId, int LanguageId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            string query = "";
            //query = "select * from tblProductPrice PC where PC.SeqNo in (select CS.ServiceId from tblContractServices CS where CS.ContractId = " + ContractId + ") and PC.LanguageId = " + LanguageId + "";
            query = "select * from  tblProductPrice PC where PC.SeqNo in (select CS.ServiceId  from tblProductPric CS where CS.ContractId =  " + ContractId + ") and PC.LanguageId= " + LanguageId + "";


            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                return ds;


            }
        }
        public DataSet GetContractServices(int ContractId, int LanguageId, string dbParam)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            string query = "";
            //query = "select * from tblProductPrice PC where PC.SeqNo in (select CS.ServiceId from tblContractServices CS where CS.ContractId = " + ContractId + ") and PC.LanguageId = " + LanguageId + "";
            //query = "select * from  tblProductPrice PC where PC.SeqNo in (select CS.ServiceId  from tblContractServices CS where CS.ContractId =  " + ContractId + ") and PC.LanguageId= " + LanguageId + "";
            query = "select * from tblProductPrice PC where PC.ClientOScreen='1' and PC.SeqNo in (select CS.ServiceId from tblContractServices CS where CS.ContractId =" + ContractId + ") and PC.LanguageId=" + LanguageId + "";



            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                return ds;
            }
        }
        public DataSet GetReturnService(string dbParam, int SeqNo)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            string query = "";
            //query = "select * from tblProductPrice PC where PC.SeqNo in (select CS.ServiceId from tblContractServices CS where CS.ContractId = " + ContractId + ") and PC.LanguageId = " + LanguageId + "";
            //query = "select * from  tblProductPrice PC where PC.SeqNo in (select CS.ServiceId  from tblContractServices CS where CS.ContractId =  " + ContractId + ") and PC.LanguageId= " + LanguageId + "";
            //query = "select * from tblProductPrice PC where PC.ClientOScreen='1' and PC.SeqNo in (select CS.ServiceId from tblContractServices CS where CS.ContractId =" + ContractId + ") and PC.LanguageId=" + LanguageId + "";
            query = "Select Coalesce(ReturnServiceType,0) as ReturnServiceType from tblProductPrice where SeqNo= '" + SeqNo + "'";



            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                return ds;
            }
        }
        public DataSet GetDeliveryduration(string dbParam, int languageId, int ContractId, int ServiceId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            string query = "";
            //query = "select * from tblProductPrice PC where PC.SeqNo in (select CS.ServiceId from tblContractServices CS where CS.ContractId = " + ContractId + ") and PC.LanguageId = " + LanguageId + "";
            //query = "select * from  tblProductPrice PC where PC.SeqNo in (select CS.ServiceId  from tblContractServices CS where CS.ContractId =  " + ContractId + ") and PC.LanguageId= " + LanguageId + "";
            //query = "select * from tblProductPrice PC where PC.ClientOScreen='1' and PC.SeqNo in (select CS.ServiceId from tblContractServices CS where CS.ContractId =" + ContractId + ") and PC.LanguageId=" + LanguageId + "";
            //query = "Select Coalesce(ReturnServiceType,0) as ReturnServiceType from tblProductPrice where SeqNo= '" + SeqNo + "'";
            query = "Select  Coalesce(tblProductPrice.Deliveryduration,0) as Deliveryduration  From tblContractServices ,tblProductPrice where tblProductPrice.SeqNo =tblContractServices.ServiceId and tblProductPrice.languageId =1 and   ContractId='" + ContractId + "' And ServiceId='" + ServiceId + "'";



            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                return ds;
            }
        }
    }
}
       