using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transnational.Models.VM
{
    public class Logins
    {
        public string LoginId { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
  
        public string OTP { set; get; }
        public string FirstName { set; get; }
        //public DateTime OTPReceviers { set; get; }
        public int ContactId { set; get; }

        public string CD { set; get; }
        public string ImageString { set; get; }
        public string Address { set; get; }
        public string Address2 { set; get; }

        public string Address3 { set; get; }
        public string Address4 { set; get; }
        public string Pincode { set; get; }
        public int CountryId { set; get; }
        public int CityId { set; get; }
        public int DistrictId { set; get; }
        public int Zoneid { set; get; }
        public int Mobile { set; get; }
    }

    public class ForgotPass

    {
        public string LoginId { set; get; }
        public string OTP { set; get; }
    }
}