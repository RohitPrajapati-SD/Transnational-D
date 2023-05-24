//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using Transnational.Common;
//using Transnational.Models;


//namespace Transnational.Repository
//{
//    public class AddressRepository
//    {
//        public DataSet GetAddress(Address obj)
//        {

//            DataSet ds = new DataSet();

//            CommonFuns commnfun = new CommonFuns();

//            DbConnections conobj = new DbConnections();
//            var con = conobj.connection(obj.CD);
//           SqlCommand com = new SqlCommand("spGetAddress", con);
//            com.CommandType = CommandType.StoredProcedure;
//            com.Parameters.AddWithValue("@PostalCode", obj.PostalCode);
//            com.Parameters.AddWithValue("@PostalCodeTo", obj.PostalCodeTo);
//            using (SqlDataAdapter da = new SqlDataAdapter(com))
//            {
//                con.Open();
//                da.Fill(ds);
//            }
//            return ds;
//        }
//        public DataSet GetProductSubscription(ProductSubscription obj)
//        {

//            DataSet ds = new DataSet();
            
//            DbConnections conobj = new DbConnections();
//            var con = conobj.connection(obj.CD);
//            SqlCommand com = new SqlCommand("spGetProductSubscription", con);
//            com.CommandType = CommandType.StoredProcedure;
//            com.Parameters.AddWithValue("@LanguageId", obj.LanguageId);
//            using (SqlDataAdapter da = new SqlDataAdapter(com))
//            {
//                con.Open();

//                da.Fill(ds);

//            }
//            return ds;
//        }
//    }
//}
    
