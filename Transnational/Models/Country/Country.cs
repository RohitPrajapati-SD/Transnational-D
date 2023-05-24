using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transnational.Models.Country
{
    public class Countrys
    {

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CD { get; set; }

        public int LanguageId { get; set; }
        //public string ContractNo { get; set; }

        //public string BillingCycle { get; set; }

        //public string Address1 { get; set; }

    }
    //================================================================================================================================
    public class Citys
    {
        public int StateId { get; set; }

        public string StateName { get; set; }

        public string Title { get; set; }



    }
    //=====================================================================================
    public class Districts
    {
        public int ZoneId { get; set; }

        public string ZoneName { get; set; }


    }
    //===================================================================================

    public class Zones
    {
        internal string Address1;

        public int CityId { get; set; }

        public string CityName { get; set; }

    }
    public partial class DistrictPostalCodes
    {
        public int DistrictPostalCodeId { get; set; }
        public string PostalCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public int LanguageId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<int> ZoneId { get; set; }
        public string PostalCodeTo { get; set; }
        public string Latitude { get; set; }

        public int count { get; set; }
    }
    public partial class DemoGraphicalTags
    {
        public int DemographicalId { get; set; }
        public Nullable<int> LevelId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> ZoneId { get; set; }
        public Nullable<int> regionid { get; set; }
        public Nullable<int> StateNewId { get; set; }
    }
}











