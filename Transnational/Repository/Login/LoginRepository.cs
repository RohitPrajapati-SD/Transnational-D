using System.Configuration;
using System.Data.SqlClient;
using Transnational.Models.VM;
using Transnational.Common;
using EnDecryptDLL;
using System.Data;

namespace Transnational.Repository.Login
{
  public class LoginRepository
    {
        private SqlCommand com;

        public DataSet CheckLoginWithDB(string dbParam, Logins login, string UserType)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            Security encObj = new Security();
            DataSet ds = new DataSet();
            DataSet tblds = new DataSet();
            DataTable dt = new DataTable("DataTable");
            //object FirstName, Email, ProfileImage, ContactId, ImageString;
            //int ContactId;
            //FirstName = "";
            //Email = "";
            //ProfileImage = "";
            //ContactId = "";
            //ImageString = "";
            dt.Columns.Add(new DataColumn("DatabaseName", typeof(string)));
            dt.Columns.Add(new DataColumn("Message", typeof(string)));
            dt.Columns.Add(new DataColumn("Status", typeof(string)));
            dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
            //dt.Columns.Add(new DataColumn("Email", typeof(string)));
            //dt.Columns.Add(new DataColumn("ProfileImage", typeof(string)));
            //dt.Columns.Add(new DataColumn("ContactId", typeof(string)));
            //dt.Columns.Add(new DataColumn("ImageString", typeof(string)));
            dt.Columns.Add(new DataColumn("Companies", typeof(DataSet)));
            
            if (UserType == "Contact")
            {

                com = new SqlCommand("spGetContactType", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Email", login.Email);
                com.Parameters.AddWithValue("@CPassword ", encObj.enCrypt(login.Password));
            }
            else
            {
                com = new SqlCommand("spGetUserTypeById", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@EmailAddress", login.Email);

                com.Parameters.AddWithValue("@Password ", encObj.enCrypt(login.Password));

            }
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(tblds);
                if (tblds.Tables[0].Rows.Count > 0)
                {
                   
                        DataRow dr = dt.NewRow();
                    dr["DatabaseName"] = dbParam;
                    dr["Status"] = "Success";
                    dr["FirstName"] = "";
                    dr["Message"] = "login successfully!";
                    dr["Companies"] = GetAllCompanyByContactLoginId(dbParam, login.Email);
                    dt.Rows.Add(dr);
                    ds.Tables.Add(dt);
                    }
             else
                {
                    DataRow dr = dt.NewRow();
                    dr["DatabaseName"] = dbParam;
                    dr["Status"] = "Fail";
                    dr["Message"] = "Sorry! Authentication failed";
                    dt.Rows.Add(dr);
                    ds.Tables.Add(dt);
                }
                con.Close();
                return ds;
            }


        }
        public DataSet GetAllCompanyByContactLoginId(string dbParam, string LoginId)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            Security encObj = new Security();

            DataSet ds = new DataSet();

            com = new SqlCommand("spGetAllCompanyByContactLoginId", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@LoginId", LoginId);

            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;
            }
        }
        public DataSet getLoginLocation(string dbParam, Logins login)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            Security encObj = new Security();

            DataSet ds = new DataSet();

            com = new SqlCommand("spGetLoginById", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmailId", login.Email);

            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {

                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;
                
            }
        }
  
        }

    }


