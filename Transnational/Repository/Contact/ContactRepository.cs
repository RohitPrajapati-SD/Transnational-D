using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EnDecryptDLL;
using Transnational.Common;
using Transnational.Models.Contact;
using Transnational.Models.VM;

namespace Transnational.Repository.OTPRepository
{
    public class ContactRepository
    {
        public DataSet reciveOTP(string dbParam, string UserType, ForgotPass Loginsobj)
        {



            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            //DataSet ds = new DataSet();
            DataSet ds = new DataSet();
            DataSet tblds = new DataSet();
            int ContactId = 0;
            //int ContactId;

            DataTable dt = new DataTable("DataTable");
            dt.Columns.Add(new DataColumn("DatabaseName", typeof(string)));
            dt.Columns.Add(new DataColumn("Message", typeof(string)));
            dt.Columns.Add(new DataColumn("Status", typeof(string)));
            dt.Columns.Add(new DataColumn("ContactId", typeof(int)));


            SqlCommand com = new SqlCommand("spUpdateOTPRecever", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@OTP", Loginsobj.OTP);
            com.Parameters.AddWithValue("@EmailMobile", Loginsobj.LoginId);


            {

                using (SqlDataAdapter da = new SqlDataAdapter(com))
                {
                    con.Open();
                    da.Fill(tblds);
                    if (tblds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow result in tblds.Tables[0].Rows)
                        {
                            ContactId = (int)result["ContactId"];


                        }
                        DataRow dr = dt.NewRow();
                        dr["DatabaseName"] = dbParam;
                        dr["Status"] = "Success";
                        dr["Message"] = "OTP updated successfully!";
                        dr["ContactId"] = ContactId;

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


        }
     
        public DataSet getLoginLocation(string dbParam, ForgotPass login)
        {
            // string dbName = "Teamwork-SG-v2UAT";

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            //Security encObj = new Security();
            // string dbName = "Teamwork-SG-v2UAT";
            DataSet ds = new DataSet();
            SqlCommand com = new SqlCommand("spGetLoginById", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmailId", login.LoginId);


            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {

                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;
            }


        }


        public bool UpdatePassward(Logins obj)
        {


            Security SecurityObj = new Security();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(obj.CD);


            SqlCommand com = new SqlCommand("spUpdatePassword", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@OTP", obj.OTP);

            com.Parameters.AddWithValue("@Password", SecurityObj.enCrypt(obj.Password));
            com.Parameters.AddWithValue("@ContactId", obj.ContactId);
            {
                con.Open();
                var result = com.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public bool UpdateContactDP(Logins obj)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(obj.CD);
            SqlCommand com = new SqlCommand("spUpdateContactDP", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ContactId", obj.ContactId);
            com.Parameters.AddWithValue("@ImageString", obj.ImageString);

            //com.Parameters.AddWithValue("@Email", obj.Email);

            //using (SqlDataAdapter da = new SqlDataAdapter(com))
            {

                con.Open();
                var result = com.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public bool ContactAddress(Logins obj)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(obj.CD);
            SqlCommand com = new SqlCommand("spUpdateContactAddressByContactId", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ContactId", obj.ContactId);
            com.Parameters.AddWithValue("@Address", obj.Address);
            com.Parameters.AddWithValue("@Address2", obj.Address2);
            com.Parameters.AddWithValue("@Address3", obj.Address3);
            com.Parameters.AddWithValue("@Address4", obj.Address4);
            com.Parameters.AddWithValue("@Pincode", obj.Pincode);
            com.Parameters.AddWithValue("@CountryId", obj.CountryId);
            com.Parameters.AddWithValue("@CityId", obj.CityId);
            com.Parameters.AddWithValue("@DistrictId", obj.DistrictId);
            com.Parameters.AddWithValue("@Zoneid", obj.Zoneid);

            {

                con.Open();
                var result = com.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public bool SavecontactAddress(ContactAddress ContactAddressObj)
        {

            if (ContactAddressObj.DefaultAddress.ToLower() == "yes")
            {
                UpdateContactAddressDeafultAddressNo(ContactAddressObj);
            }

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(ContactAddressObj.CD);
            SqlCommand com = new SqlCommand("spInsertSaveContactAddress", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@PostalCode", ContactAddressObj.PostalCode);
            com.Parameters.AddWithValue("@Address1", ContactAddressObj.Address1);
            com.Parameters.AddWithValue("@Address2", ContactAddressObj.Address2);
            com.Parameters.AddWithValue("@Address3", ContactAddressObj.Address3);
            com.Parameters.AddWithValue("@Address4", ContactAddressObj.Address4);
            com.Parameters.AddWithValue("@Countryid", ContactAddressObj.Countryid);
            com.Parameters.AddWithValue("@Zoneid", ContactAddressObj.Zoneid);
            com.Parameters.AddWithValue("@Cityid", ContactAddressObj.Cityid);
            com.Parameters.AddWithValue("@DistrictId", ContactAddressObj.Districtid);

            com.Parameters.AddWithValue("@ContactId", ContactAddressObj.ContactId);
            com.Parameters.AddWithValue("@ALatitude", ContactAddressObj.ALatitude);
            com.Parameters.AddWithValue("@ALongitude", ContactAddressObj.ALongitude);
            com.Parameters.AddWithValue("@Collection", ContactAddressObj.Collection);
            com.Parameters.AddWithValue("@Delivery", ContactAddressObj.Delivery);
            com.Parameters.AddWithValue("@CostCenterName", ContactAddressObj.CostCenterName);
            com.Parameters.AddWithValue("@ContactNumber1", ContactAddressObj.ContactNumber1);
            com.Parameters.AddWithValue("@AddressName", ContactAddressObj.AddressName);
            com.Parameters.AddWithValue("@DefaultAddress", ContactAddressObj.DefaultAddress);
            com.Parameters.AddWithValue("@DefaultShipping", ContactAddressObj.DefaultShipping);
            com.Parameters.AddWithValue("@DefaultBilling", ContactAddressObj.DefaultBilling);
            com.Parameters.AddWithValue("@CustomerId", ContactAddressObj.CustomerId);


            {
                con.Open();
                var result = com.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }
        public bool UpdateContactAddressDeafultAddressNo(ContactAddress ContactAddressObj)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(ContactAddressObj.CD);
            SqlCommand com = new SqlCommand("spUpdateContactAddress", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ContactId", ContactAddressObj.ContactId);





            {
                con.Open();
                var result = com.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        //------------------------------------UpdatecontactAddress----------------------------------------------//---
        public bool UpdateContactAddress(ContactAddress ContactAddressObj)
        {



            DbConnections conobj = new DbConnections();
            var con = conobj.connection(ContactAddressObj.CD);
            SqlCommand com = new SqlCommand("spUpdateContactAddressByCABid", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@PostalCode", ContactAddressObj.PostalCode);
            com.Parameters.AddWithValue("@Address1", ContactAddressObj.Address1);
            com.Parameters.AddWithValue("@Address2", ContactAddressObj.Address2);
            com.Parameters.AddWithValue("@Address3", ContactAddressObj.Address3);
            com.Parameters.AddWithValue("@Address4", ContactAddressObj.Address4);
            com.Parameters.AddWithValue("@Countryid", ContactAddressObj.Countryid);
            com.Parameters.AddWithValue("@Zoneid", ContactAddressObj.Zoneid);
            com.Parameters.AddWithValue("@Cityid", ContactAddressObj.Cityid);
            com.Parameters.AddWithValue("@DistrictId", ContactAddressObj.Districtid);

            //com.Parameters.AddWithValue("@ContactId", ContactAddressObj.ContactId);
            com.Parameters.AddWithValue("@ALatitude", ContactAddressObj.ALatitude);
            com.Parameters.AddWithValue("@ALongitude", ContactAddressObj.ALongitude);
            com.Parameters.AddWithValue("@Collection", ContactAddressObj.Collection);
            com.Parameters.AddWithValue("@Delivery", ContactAddressObj.Delivery);
            com.Parameters.AddWithValue("@CostCenterName", ContactAddressObj.CostCenterName);
            com.Parameters.AddWithValue("@ContactNumber1", ContactAddressObj.ContactNumber1);
            com.Parameters.AddWithValue("@AddressName", ContactAddressObj.AddressName);
            com.Parameters.AddWithValue("@DefaultAddress", ContactAddressObj.DefaultAddress);
            com.Parameters.AddWithValue("@DefaultShipping", ContactAddressObj.DefaultShipping);
            com.Parameters.AddWithValue("@DefaultBilling", ContactAddressObj.DefaultBilling);


            com.Parameters.AddWithValue("@CABid", ContactAddressObj.CABid);

            {
                con.Open();
                var result = com.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }
        public DataSet GetContactAddress(ContactAddressConduction ContactAddressConductionObj)
        {

            DataSet ds = new DataSet();

            CommonFuns commnfun = new CommonFuns();
            //if(defaltAddress=! null)
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(ContactAddressConductionObj.CD);
            SqlCommand com = new SqlCommand("[spGetContactAddressByContactId]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ContactId", ContactAddressConductionObj.ContactId);
            if (ContactAddressConductionObj.DefaultAddress != null)
            {
                com.Parameters.AddWithValue("@DefaultAddress", ContactAddressConductionObj.DefaultAddress);
            }
            if (ContactAddressConductionObj.CompanyAddressBookId != 0)
            {
                com.Parameters.AddWithValue("@CompanyAddressBookId", ContactAddressConductionObj.CompanyAddressBookId);
            }


            //com.Parameters.AddWithValue("@PostalCodeTo", obj.PostalCodeTo);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }

        public DataSet GetOldpasswordbyContactId(OldpasswordbyContactIdConduction OldpasswordbyContactIdObj)
        {

            DataSet ds = new DataSet();

            CommonFuns commnfun = new CommonFuns();

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(OldpasswordbyContactIdObj.CD);
            SqlCommand com = new SqlCommand("spGetoldPasswordbyContactId", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ContactId", OldpasswordbyContactIdObj.ContactId);
            //com.Parameters.AddWithValue("@PostalCodeTo", obj.PostalCodeTo);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        public bool UpdateOldPasswordbyContactId(UpdateOldpasswordbyContactId UpdateOldpasswordbyContactId)
        {


            Security SecurityObj = new Security();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(UpdateOldpasswordbyContactId.CD);


            SqlCommand com = new SqlCommand("spUpdateoldPasswordbyContactId", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CPassword", SecurityObj.enCrypt(UpdateOldpasswordbyContactId.CPassword));
            com.Parameters.AddWithValue("@ContactId", UpdateOldpasswordbyContactId.ContactId);
            {
                con.Open();
                var result = com.ExecuteNonQuery();
                con.Close();


                if (result > 0)
                {
                    return true;
                }


                else
                {

                    return false;
                }

            }
        }

        public bool UpdateContactprofilebycontactId(ContactProfileByContactId ContactProfileByContactIdObj)
        {


            Security SecurityObj = new Security();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(ContactProfileByContactIdObj.CD);


            SqlCommand com = new SqlCommand("spUpdateContactProfileByContactId", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@Salutation", (ContactProfileByContactIdObj.Salutation));
            com.Parameters.AddWithValue("@FirstName", ContactProfileByContactIdObj.FirstName);
            /* com.Parameters.AddWithValue("@MiddleName", ContactProfileByContactIdObj.MiddleName)*/
            ;
            //com.Parameters.AddWithValue("@LastName", ContactProfileByContactIdObj.LastName);
            com.Parameters.AddWithValue("@PinCode", ContactProfileByContactIdObj.PinCode);
            com.Parameters.AddWithValue("@Address", ContactProfileByContactIdObj.Address);
            com.Parameters.AddWithValue("@Address2", ContactProfileByContactIdObj.Address2);
            com.Parameters.AddWithValue("@Address3", ContactProfileByContactIdObj.Address3);
            com.Parameters.AddWithValue("@Address4", ContactProfileByContactIdObj.Address4);
            com.Parameters.AddWithValue("@CountryId", ContactProfileByContactIdObj.CountryId);
            com.Parameters.AddWithValue("@Cityid", ContactProfileByContactIdObj.Cityid);
            com.Parameters.AddWithValue("@Email", ContactProfileByContactIdObj.Email);
            com.Parameters.AddWithValue("@Mobile", ContactProfileByContactIdObj.Mobile);
            com.Parameters.AddWithValue("@ContactId", ContactProfileByContactIdObj.ContactId);
            com.Parameters.AddWithValue("@DistrictId", ContactProfileByContactIdObj.DistrictId);
            com.Parameters.AddWithValue("@Zoneid", ContactProfileByContactIdObj.Zoneid);
            com.Parameters.AddWithValue("@StateId", ContactProfileByContactIdObj.StateId);
            //com.Parameters.AddWithValue("@CompanyName", ContactProfileByContactIdObj.CompanyName);
           

            {
                {
                    con.Open();
                    var result = com.ExecuteNonQuery();
                    con.Close();


                    if (result > 0)
                    {
                        return true;
                    }


                    else
                    {

                        return false;
                    }

                }
            }
        }
        public DataSet GetContactprofilebycontactId(ContactProfileByContactId ContactProfileByContactId)
        {

            DataSet ds = new DataSet();

            CommonFuns commnfun = new CommonFuns();

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(ContactProfileByContactId.CD);
            SqlCommand com = new SqlCommand("[spGetContactProfileByContactId]", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@EnquiryTypeId", EnquiryTypesObj.EnquiryTypeId);
            com.Parameters.AddWithValue("@ContactId", ContactProfileByContactId.ContactId);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        //--------------------------------------------------------------------------------------//----
        public bool UpdateContactDefaultAddressMode(ContactDefaultAddressMode ContactDefaultAddressModeObj)
        {


            Security SecurityObj = new Security();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(ContactDefaultAddressModeObj.CD);


            SqlCommand com = new SqlCommand("spUpdateContactDefaultAddressMode", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DefaultAddress", ContactDefaultAddressModeObj.DefaultAddress);

            com.Parameters.AddWithValue("@CABid", ContactDefaultAddressModeObj.CABid);
            {
                con.Open();
                var result = com.ExecuteNonQuery();
                con.Close();


                if (result > 0)
                {
                    return true;
                }


                else
                {

                    return false;
                }

            }
        }

        //----------------------------------------------------InsertContactRegistration----------------------------------------------//--
        public bool InsertContactRegistration(ContactRegistration ContactRegistrationObj)
        {

            Security SecurityObj = new Security();
            DbConnections conobj = new DbConnections();
            string db = "";
            if (ContactRegistrationObj.CountryId == 6)
            {
                //db = "Teamwork-SG-v2UAT";
                db = "Teamwork_CRM_UAT";
            }
            else if (ContactRegistrationObj.CountryId == 1)
            {
                db = "Teamwork-SG-v2UAT1";
            }

            else if (ContactRegistrationObj.CountryId == 75)
            {
               // db = "Teamwork-SG-v2UAT";
                db = "Teamwork_CRM_UAT";
            }

            var con = conobj.connection(db);


            SqlCommand com = new SqlCommand("[spInsertContactRegistration]", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@CountryId", ContactRegistrationObj.CountryId);

            com.Parameters.AddWithValue("@Mobile", ContactRegistrationObj.Mobile);

            com.Parameters.AddWithValue("@Email", ContactRegistrationObj.Email);
            com.Parameters.AddWithValue("@FirstName", ContactRegistrationObj.FirstName);
            com.Parameters.AddWithValue("@CPassword", SecurityObj.enCrypt(ContactRegistrationObj.CPassword));
            //com.Parameters.AddWithValue("@ContactId", ContactRegistrationObj.ContactId);
            SqlParameter RuturnValue = new SqlParameter("@ContactId", SqlDbType.Int);
            RuturnValue.Direction = ParameterDirection.Output;
            com.Parameters.Add(RuturnValue);
            {
                con.Open();
                int i = com.ExecuteNonQuery();
                var ContactId = (int)com.Parameters["@ContactId"].Value;
                con.Close();

                InsertLogin(ContactRegistrationObj, ContactId);

                if (ContactId > 0)
                {
                    return true;
                }


                else
                {

                    return false;
                }

            }
        }
        public bool InsertLogin(ContactRegistration ContactRegistrationObj, int ContactId)
        {

            Security SecurityObj = new Security();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection("trConnection");


            SqlCommand com = new SqlCommand("[spInsertLogin]", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@EmailId", ContactRegistrationObj.Email);

            com.Parameters.AddWithValue("@MobileNo", ContactRegistrationObj.Mobile);
            com.Parameters.AddWithValue("@UserId", ContactId);

            com.Parameters.AddWithValue("DatabaseName", ContactRegistrationObj.CD);

            {
                con.Open();
                var result = com.ExecuteNonQuery();
                con.Close();


                if (result > 0)
                {
                    return true;
                }


                else
                {

                    return false;
                }




            }

        }
        //-----------------------------------------------GetContactprofilebycontactId_Pic--------------------------------------//---------------

        public DataSet GetContactprofilebycontactId_Pic(ContactprofilebycontactId_Pic_Conduction ContactprofilebycontactId_Pic_ConditionObj)
        {

            DataSet ds = new DataSet();

            CommonFuns commnfun = new CommonFuns();

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(ContactprofilebycontactId_Pic_ConditionObj.CD);
            SqlCommand com = new SqlCommand("spGetContactProfileByContactId_Pic", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@EnquiryTypeId", EnquiryTypesObj.EnquiryTypeId);
            com.Parameters.AddWithValue("@ContactId", ContactprofilebycontactId_Pic_ConditionObj.ContactId);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }

        //---------------------------------------GetPaymentOption---------------------------------------//-------//------
        public DataSet GetPaymentMethod(PaymentMethodConduction PaymentMethodConductionObj)
        {

            DataSet ds = new DataSet();

            CommonFuns commnfun = new CommonFuns();

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(PaymentMethodConductionObj.CD);
            SqlCommand com = new SqlCommand("spGetPaymentMethod", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@ContactId", PaymentMethodConductionObj.ContactId);
            com.Parameters.AddWithValue("@ContractId", PaymentMethodConductionObj.ContractId);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        //---------------------------------------insertPaymentOption---------------------------------------//-------//------
        public bool InsertPaymentmethod(PaymentMethod PaymentMethodObj)
        {
            if (PaymentMethodObj.DefaultPaymentMethod.ToLower() == "yes")
            {
                UpdateDefaultPaymentMethod(PaymentMethodObj);
            }
            //Security SecurityObj = new Security();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(PaymentMethodObj.CD);
            SqlCommand com = new SqlCommand("spInsertPaymentMethod", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@PaymentMethodId", PaymentMethodObj.PaymentMethodId);
            com.Parameters.AddWithValue("@ContactId", PaymentMethodObj.ContactId);
            com.Parameters.AddWithValue("@CardHolderName", PaymentMethodObj.CardHolderName);
            com.Parameters.AddWithValue("@CardNumber", PaymentMethodObj.CardNumber);
            com.Parameters.AddWithValue("@Month", PaymentMethodObj.Month);
            com.Parameters.AddWithValue("@Year", PaymentMethodObj.Year);
            com.Parameters.AddWithValue("@DefaultPaymentMethod", PaymentMethodObj.DefaultPaymentMethod);
            {
                con.Open();
                var result = com.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
        }
        public bool UpdateDefaultPaymentMethod(PaymentMethod PaymentMethodObj)
        {

            Security SecurityObj = new Security();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(PaymentMethodObj.CD);


            SqlCommand com = new SqlCommand("spUpdateDefaultPaymentMethod", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@DefaultPaymentMethod", PaymentMethodObj.DefaultPaymentMethod);

            com.Parameters.AddWithValue("@ContactId", PaymentMethodObj.ContactId);
            {
                con.Open();
                var result = com.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //-------------------------------------GetContactPaymentMethod-------------------------------------------//----------------//
        public DataSet GetContactPaymentMethod(ContactPaymentMethodConduction ContactPaymentMethodConductionObj)
        {

            DataSet ds = new DataSet();

            CommonFuns commnfun = new CommonFuns();

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(ContactPaymentMethodConductionObj.CD);
            SqlCommand com = new SqlCommand("spGetContactPaymentMethod", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ContactId", ContactPaymentMethodConductionObj.ContactId);
            //com.Parameters.AddWithValue("@ContractId", PaymentMethodConductionObj.ContractId);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        //------------------------------------------DeleteContactMethod-----------------------------------------------//----
        public bool DeleteContactPaymentMethod(PaymentMethod PaymentMethodObj)
        {

            //Security SecurityObj = new Security();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(PaymentMethodObj.CD);

            SqlCommand com = new SqlCommand("spDeleteContactPaymentMethod", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ContactPaymentMethodId", PaymentMethodObj.ContactPaymentMethodId);

            {
                con.Open();
                var result = com.ExecuteNonQuery();
                con.Close();


                if (result > 0)
                {
                    return true;
                }

                else
                {

                    return false;
                }
            }

        }
        public bool DeleteContactAddressBook(ContactAddressBookDelete ContactAddressConductionObj)
        {

            //Security SecurityObj = new Security();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(ContactAddressConductionObj.CD);

            SqlCommand com = new SqlCommand("spDeleteContactAddressBook", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CABId", ContactAddressConductionObj.CABId);

            {
                con.Open();
                var result = com.ExecuteNonQuery();
                con.Close();


                if (result > 0)
                {
                    return true;
                }

                else
                {

                    return false;
                }
            }

        }
        public int GetOTPVerification(EmailVerifications EmailVerificationObj)
        {

            //Security SecurityObj = new Security();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(EmailVerificationObj.CD);

            SqlCommand com = new SqlCommand("spGetEmailVerifications", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Email", EmailVerificationObj.Email);
            //com.Parameters.AddWithValue("@isPublic", EmailVerificationObj.isPublic);
            {
                con.Open();
                var value = (int)com.ExecuteScalar();
                con.Close();
                return value;

            }

        }
        public DataTable GetAllPaymentMethod(PaymentMethod PaymentMethodObj)
        {

            DataSet ds = new DataSet();
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(PaymentMethodObj.CD);
            DataTable dt = new DataTable("DataTable");
            dt.Columns.Add(new DataColumn("PaymentMethodId", typeof(int)));
            dt.Columns.Add(new DataColumn("PaymentMethodName", typeof(string)));
            dt.Columns.Add(new DataColumn("PaymentMethodImage", typeof(string)));
            dt.Columns.Add(new DataColumn("CountryId", typeof(int)));
            dt.Columns.Add(new DataColumn("Status", typeof(string)));
            SqlCommand com = new SqlCommand("[spGetAllPaymentMethod]", con);
            com.CommandType = CommandType.StoredProcedure;
           
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drtbl in ds.Tables[0].Rows)
                    {
                        DataRow dr = dt.NewRow();
                        dr["PaymentMethodId"] = drtbl["PaymentMethodId"];
                        dr["PaymentMethodName"] = drtbl["PaymentMethodName"];
                        dr["PaymentMethodImage"] = drtbl["PaymentMethodImage"];
                        dr["CountryId"] = drtbl["CountryId"];
                        dr["Status"] = drtbl["Status"];
                        dt.Rows.Add(dr);
                    }
                    con.Close();
                }
                return dt;
            }
        }
    }
}



    


   

        
    


        
        




    




    

    

    
