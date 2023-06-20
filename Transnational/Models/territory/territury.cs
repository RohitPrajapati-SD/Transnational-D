using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transnational.Models.territory
{
    public class Countries
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CD { get; set; }

        public int LanguageId { get; set; }
        public string DDLCode { get; set; }

    }

    public class Address
    {
        public int ZoneId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PostalCode { get; set; }
        public string PostalCodeTo { get; set; }
        public string Latitude { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }

        public int CountryId { get; set; }
        public string CD { get; set; }
        public string Longitude { get; set; }


    }
    public class Cities
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public int LanguageId { get; set; }
        public string CD { get; set; }
    }
    public class DistrictCondition
    {
        public int CityId { get; set; }
        public string CD { get; set; }
    }
    public class District
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
    }
    public class ZoneCondition
    {
        public int DistinctId { get; set; }
        public string CD { get; set; }
    }
    public class Zone
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
    }
}