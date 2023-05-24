using System.Configuration;
using System.Data.SqlClient;
using Transnational.Models.VM;
using Transnational.Common;
using System.Data;
using System;
using Transnational.Models.Country;

namespace Transnational.Repository.Country
{
    public class CountryRepository
    {

        public DataSet GetCountry(string dbParam, int LanguageId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            //int ContactId = 8;
            //int CompanyId = 9;
            string query = "";
            query = "Select * from tbCountry where LanguageId=" + LanguageId + " order by CountryName";

            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;

            }
        }
        ///===================================================================================================================================
        ///public DataSet GetCountry(int LanguageId)
        //public DataSet GetCity(int CountryId, string LanguageId)
        //{
        //    DbConnections conobj = new DbConnections();
        //    var con = conobj.connection();
        //    DataSet ds = new DataSet();
        //    //int ContactId = 8;
        //    //int CompanyId = 9;
        //    string query = "";
        //    query = "select distinct tblStateMaster.* from tblStateMaster , tblDemoGraphicalTag";
        //    query += " where  tblStateMaster.StateId = tblDemoGraphicalTag.StateId  and CountryId = " + CountryId + " and CountryId <> 0  and LanguageId =" + LanguageId + "";


        //    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
        //    {
        //        con.Open();
        //        da.Fill(ds);
        //        con.Close();
        //        return ds;




        //    }
        //}

        public DataSet GetCity(string dbParam, int CountryId, int LanguageId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            //int ContactId = 8;
            //int CompanyId = 9;
            string query = "";
            query = "select distinct tblStateMaster.* from tblStateMaster , tblDemoGraphicalTag";
            query += " where  tblStateMaster.StateId = tblDemoGraphicalTag.StateId  and CountryId = " + CountryId + " and CountryId <> 0  and LanguageId =" + LanguageId + "";


            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;




            }
            //=========================================================================================


        }
        public DataSet GetDistrict(string dbParam,int StateID, int LanguageId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            //int ContactId = 8;
            //int CompanyId = 9;
            string query = "";
            query = "select distinct tblZoneMaster.ZoneId , coalesce(tblZoneMaster.ZoneName,'') +'-'+ coalesce(tblZoneMaster.Description,'') as ZoneName  from tblZoneMaster , tblDemoGraphicalTag ";
            query += "where  tblZoneMaster.ZoneId = tblDemoGraphicalTag.ZoneId  and tblDemoGraphicalTag.CityId  in (select distinct tblCityMaster.CityId from tblCityMaster , tblDemoGraphicalTag ";
            query += "where  tblCityMaster.CityId = tblDemoGraphicalTag.CityId  and tblDemoGraphicalTag.StateID = " + StateID + " and tblDemoGraphicalTag.StateID <> 0  and LanguageId =" + LanguageId + ") ";
            query += "And tblDemoGraphicalTag.CityId <> 0 And LanguageId = " + LanguageId + " ";

            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;



            }
        }
        //===============================================================================
        public DataSet GetZone(string dbParam ,int ZoneId, int LanguageId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            //int ContactId = 8;
            //int CompanyId = 9;
            string query = "";
            query = "select distinct tblCityMaster.CityId  , coalesce(tblCityMaster.CityName,'') +'-'+ coalesce(tblCityMaster.Description,'') as CityName  from tblCityMaster , tblDemoGraphicalTag where  tblCityMaster.CityId = tblDemoGraphicalTag.CityId and tblDemoGraphicalTag.StateID <> 0 and tblCityMaster.CityId in(select distinct CityId from tblDemoGraphicalTag where ZoneId = " + ZoneId + ")  and LanguageId = " + LanguageId + "";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;




            }
        }
        //==========================================//navdeep//============================//=======================================================//===============
        public DataSet GetDistrictCountPostalCode(string dbParam, int ZoneId, int LanguageId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            //int ContactId = 8;
            //int CompanyId = 9;
            string query = "";

           // query = "Select count(*) as Count From tblDistrictPostalCode where PostalCode<='" + PostalCode + "' And PostalCodeTo >='" + PostalCode + "' And LanguageId='" + LanguageId + "'";


            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;

            }
        }
        public DataSet GetDemoGraphicalTag(string dbParam,int DistrictId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();

            string query = "";
            query = "select * from tblDemoGraphicalTag where ZoneId =" + DistrictId + " ";

            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;


            }
        }
        public DataSet GetDistrictPostalCode(string dbParam,int LanguageId )
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            //int ContactId = 8;
            //int CompanyId = 9;
            string query = "";

            //query = "Select count(*) as Count From tblDistrictPostalCode where PostalCode<='" + PostalCode + "' And PostalCodeTo >='" + PostalCode + "' And LanguageId='" + LanguageId + "'";
           // query = "Select top 1 Coalesce(Latitude,'0') as record   From tblDistrictPostalCode  where PostalCode<='" + PostalCode + "' And PostalCodeTo >='" + PostalCode + "' And LanguageId='" + LanguageId + "'";


            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;
            }
        }

    }
}

