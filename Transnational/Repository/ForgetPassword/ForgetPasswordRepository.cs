using System.Configuration;
using System.Data.SqlClient;
using Transnational.Models.VM;
using Transnational.Common;
using EnDecryptDLL;
using System.Data;
using System;

namespace Transnational.Repository.ForgetPassword
{
    public class ForgetPasswordRepository
    {
        private SqlCommand com;
        public DataSet CheckLoginWithDB(string dbParam, Logins login, string UserType)
        {
            // string dbName = "Teamwork-SG-v2UAT";

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            Security encObj = new Security();
            // string dbName = "Teamwork-SG-v2UAT";


            DataSet ds = new DataSet();

            DataTable dt = new DataTable("DataTable");

            // dt.Columns.Add(new DataColumn("id", typeof(int)));
            dt.Columns.Add(new DataColumn("DatabaseName", typeof(string)));
            dt.Columns.Add(new DataColumn("Message", typeof(string)));
            dt.Columns.Add(new DataColumn("Status", typeof(string)));

            DataRow dr = dt.NewRow();




            if (UserType == "Contact")
            {

                com = new SqlCommand("spGetContactType", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Email", login.Email);
                com.Parameters.AddWithValue("@CPassword ", encObj.enCrypt(login.Password));
                //query = "Select ContactId from tblContacts Where 1=1 and  (Email = '" + login.Email + "' or Mobile = '" + login.Email + "' ) and CPassword = '" + encObj.enCrypt(login.Password) + "' ;";
            }
            else
            {
                com = new SqlCommand("spGetUserTypeById", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EmailAddress", login.Email);
                com.Parameters.AddWithValue("@Password ", encObj.enCrypt(login.Password));
                //query = "Select UserId from tblUser Where 1=1 and  ( LoginId = '" + login.Email + "' or  EmailAddress = '" + login.Email + "' or MobileNo = '" + login.Email + "') and Password = '" + encObj.enCrypt(login.Password) + "' ;";
            }
            using (SqlDataAdapter da = new SqlDataAdapter(com))

            {
                con.Open();
                var result = com.ExecuteScalar();

                if (result != null)
                {
                    //dr["id"] = result;
                    //dr["UserType"] = UserType;

                    dr["DatabaseName"] = dbParam;
                    dr["Status"] = "Success";
                    dr["Message"] = "login successfully!";
                    dt.Rows.Add(dr);
                    ds.Tables.Add(dt);
                }

                else
                {

                    // dr["id"] = 0;
                    // dr["UserType"] = UserType;
                    dr["DatabaseName"] = dbParam;
                    dr["Status"] = "Fail";
                    dr["Message"] = "Sorry! Authentication failed";
                    dt.Rows.Add(dr);
                    ds.Tables.Add(dt);
                }

                return ds;

            }

        }



        public DataSet getLoginLocation(string dbParam, Logins login)
        {
            // string dbName = "Teamwork-SG-v2UAT";

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            Security encObj = new Security();
            // string dbName = "Teamwork-SG-v2UAT";





            DataSet ds = new DataSet();
            com = new SqlCommand("spGetLoginById", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmailId", login.Email);
            //  query = "Select DatabaseName ,  UserType   from tblContacts Where Email = '" + login.Email + "' and CPassword = '" + encObj.enCrypt(login.Password) + "' ;";

            //query += " select DatabaseName ,  UserType   from login where 1=1  ";
            //query += "  and (EmailId = '" + login.Email + "'  or MobileNo = '" + login.Email + "' or UserId = '" + login.Email + "'); ";


            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {

                con.Open();
                da.Fill(ds);
                return ds;
            }


        }
        public String getforgetPassword(string dbParam, Logins Logins_Obj)
        {
            // string dbName = "Teamwork-SG-v2UAT";

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            Security encObj = new Security();




            {
                SqlCommand com = new SqlCommand("SpUpdateContact", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@CPassword", Logins_Obj.Password);
                com.Parameters.AddWithValue("@Email", Logins_Obj.Email);


                //query = "UPDATE tblContacts SET CPassword = '" + Logins_Obj.Password + "' WHERE (Email = '" + Logins_Obj.Email + "' or Mobile = '" + Logins_Obj.Email + "' )";

                //using (SqlDataAdapter da = new SqlDataAdapter(com))

                {
                    con.Open();
                    int result = com.ExecuteNonQuery();
                    con.Close();

                    if (result>0)
                    {
   
                        return "Updated";
                    }
                    else
                    {
                        return "Sorry! OTP does't matched.";

                    }

                }
            }



        }
    }
    }



    
    

    
