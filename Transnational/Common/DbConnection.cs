using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Configuration;

namespace Transnational.Common
{
    public class DbConnections
    {
        private SqlConnection con;
        public SqlConnection connection([Optional] string dbName)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["Entities"].ToString();
                //string constr = "";
                //string DSN = WebConfigurationManager.AppSettings["DSN"];

                //constr = @""+ DSN + "" +
                //            "Initial Catalog=" + dbName + ";" +
                //            "Integrated Security=SSPI;" +
                //            "MultipleActiveResultSets=True;" +
                //            "App=EntityFramework;";


                //--------------------------------------------//--------------------------------------------------------//
                // offline Database Connection
                //constr = @"Data Source=DESKTOP-E470R35\SQLEXPRESS;" +
                //            "Initial Catalog=" + dbName + ";" +
                //            "integrated security=True;" +
                //            "MultipleActiveResultSets=True;" +
                //            "App=EntityFramework;";

                constr = constr + dbName;
                con = new SqlConnection(constr);

                return con;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }
    }
}