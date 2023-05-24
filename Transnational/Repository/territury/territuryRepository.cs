using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Transnational.Common;
using Transnational.Models.territory;

namespace Transnational.Repository.territury
{
    public class territuryRepository
    {
        public DataSet GetCountry(Countries Countriesobj)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(Countriesobj.CD);
            DataSet ds = new DataSet();
            SqlCommand com = new SqlCommand("[spGetCountryName]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@LanguageId", Countriesobj.@LanguageId);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        public DataSet GetAddress(Address AddressObj)
        {

            DataSet ds = new DataSet();
            //DataSet ds = new DataSet();

            CommonFuns commnfun = new CommonFuns();

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(AddressObj.CD);
            SqlCommand com = new SqlCommand("spGetAddress", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@PostalCode", AddressObj.PostalCode);
            com.Parameters.AddWithValue("@PostalCodeTo", AddressObj.PostalCodeTo);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        public DataSet GetAllCity(Cities Citiesobj)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(Citiesobj.CD);
            DataSet ds = new DataSet();
            SqlCommand com = new SqlCommand("spGetCityByCountryId", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@LanguageId", Citiesobj.@LanguageId);
            com.Parameters.AddWithValue("@CountryId", Citiesobj.@CountryId);

            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        //-------------------------------------------------------GetDistinct------------------------------------------------------------------//-----------
        public DataSet GetDistrict(DistrictCondition DistrictConditionObj)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(DistrictConditionObj.CD);
            DataSet ds = new DataSet();
            SqlCommand com = new SqlCommand("spGetDistrict", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@LanguageId", DistinctConditionObj.@LanguageId);
            com.Parameters.AddWithValue("@CityId", DistrictConditionObj.CityId);

            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }

        //----------------------------------------GetZone---------------------------------------------------------------------------------//-------


        public DataSet GetZone(ZoneCondition ZoneConditionObj)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(ZoneConditionObj.CD);
            DataSet ds = new DataSet();
            SqlCommand com = new SqlCommand("[spGetZone]", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@LanguageId", DistinctConditionObj.@LanguageId);
            com.Parameters.AddWithValue("@DistinctId", ZoneConditionObj.DistinctId);

            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
    }
}
    
