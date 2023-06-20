using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Transnational.Common;
using Transnational.Models.CRM;

namespace Transnational.Repository.CRM
{
    public class CRMRepository
    {
        public DataSet GetAllAppVersion(AppVersion AppVersionObj)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(AppVersionObj.CD);
            DataSet ds = new DataSet();
            SqlCommand com = new SqlCommand("[spGetAllAppVersion]", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@LanguageId", Countriesobj.@LanguageId);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        public DataSet GetAllEnquiryType(EnquiryTypes EnquiryTypesObj)
        {

            DataSet ds = new DataSet();

            CommonFuns commnfun = new CommonFuns();

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(EnquiryTypesObj.CD);
            SqlCommand com = new SqlCommand("[spGetAllEnquiryType]", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@EnquiryTypeId", EnquiryTypesObj.EnquiryTypeId);
            //com.Parameters.AddWithValue("@PostalCodeTo", obj.PostalCodeTo);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        public bool insertContactUs(ContactUs ContactUsObj)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(ContactUsObj.CD);


            SqlCommand com = new SqlCommand("[spInsertAllContactus]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EnquiryTypeId", (ContactUsObj.EnquiryTypeId));
            com.Parameters.AddWithValue("@ContactId", ContactUsObj.ContactId);
            com.Parameters.AddWithValue("@Details", ContactUsObj.Details);
            com.Parameters.AddWithValue("@Name", ContactUsObj.Name);
            com.Parameters.AddWithValue("@Email", ContactUsObj.Email);
            com.Parameters.AddWithValue("@OrderNo", ContactUsObj.OrderNo);

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
        public bool insertCallbackRequest(CallbackRequest CallbackRequestObj)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(CallbackRequestObj.CD);
            SqlCommand com = new SqlCommand("[spInsertCallbackRequest]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EnquiryTypeId", (CallbackRequestObj.EnquiryTypeId));
            com.Parameters.AddWithValue("@ContactId", CallbackRequestObj.ContactId);
            com.Parameters.AddWithValue("@Details", CallbackRequestObj.Details);
            com.Parameters.AddWithValue("@Name", CallbackRequestObj.Name);
            com.Parameters.AddWithValue("@Email", CallbackRequestObj.Email);
            com.Parameters.AddWithValue("@OrderNo", CallbackRequestObj.OrderNo);
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
        public bool InsertFeedbackByUser(FeedbackByUser FeedbackByUserObj)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(FeedbackByUserObj.CD);


            SqlCommand com = new SqlCommand("[spInsertFeedbackByUser]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Feedback", FeedbackByUserObj.Feedback);
            com.Parameters.AddWithValue("@Rating", FeedbackByUserObj.Rating);
            com.Parameters.AddWithValue("@ContactId", FeedbackByUserObj.ContactId);

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
        public DataSet GetScreenImage(ScreenImageConduction ScreenImageObj)
        {
            DataSet ds = new DataSet();

            CommonFuns commnfun = new CommonFuns();

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(ScreenImageObj.CD);
            SqlCommand com = new SqlCommand("[spGetScreenImage]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@PageName", ScreenImageObj.PageName);
            //com.Parameters.AddWithValue("@PostalCodeTo", obj.PostalCodeTo);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        public DataTable GetFAQ(FAQConduction FAQConductionObj)
        {

            DataSet ds = new DataSet();
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(FAQConductionObj.CD);
            DataTable dt = new DataTable("DataTable");
            dt.Columns.Add(new DataColumn("FAQId", typeof(int)));
            dt.Columns.Add(new DataColumn("FAQ", typeof(string)));
            dt.Columns.Add(new DataColumn("QquestionAns", typeof(DataSet)));
            SqlCommand com = new SqlCommand("[spGetFAQ]", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@FAQId", 0);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drFAQ in ds.Tables[0].Rows)
                    {
                        DataRow dr = dt.NewRow();
                        dr["FAQId"] = drFAQ["FAQId"];
                        dr["FAQ"] = drFAQ["FAQ"];
                        dr["QquestionAns"] = GetFAQquestionAns(FAQConductionObj.CD, (int)drFAQ["FAQId"]);
                        dt.Rows.Add(dr);
                    }
                    con.Close();
                }
                return dt;
            }
        }
        public DataSet GetFAQquestionAns(String CD, int FAQId)
        {
            DataSet ds = new DataSet();
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(CD);

            SqlCommand com = new SqlCommand("[spGetFAQquestionAns]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FAQId", FAQId);

            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);

                con.Close();
            }

            return ds;
        }
        public DataSet GetAllDeliveryoptions(DeliveryoptionsConduction DeliveryoptionsConductionObj)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(DeliveryoptionsConductionObj.CD);
            DataSet ds = new DataSet();
            SqlCommand com = new SqlCommand("spGetAllDeliveryoptions", con);
            com.CommandType = CommandType.StoredProcedure;

            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);


                con.Close();
            }
            return ds;
        }
        public DataSet GetAlertMaster(AlertMasterCondition AlertMasterConditionObj)
        {
            DataSet ds = new DataSet();
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(AlertMasterConditionObj.CD);

            SqlCommand com = new SqlCommand("spGetAlertMaster", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@FAQId", AlertMasterConditionObj.FAQId);

            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);

                con.Close();
            }

            return ds;
        }
        public bool InsertNotification(SaveNotification NotificationObj)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(NotificationObj.CD);


            SqlCommand com = new SqlCommand("spInsertNotification", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@NotificationDate", (NotificationObj.NotificationDate));
            com.Parameters.AddWithValue("@NotificationTitle", NotificationObj.NotificationTitle);
            com.Parameters.AddWithValue("@NotificationMessage", NotificationObj.NotificationMessage);
            com.Parameters.AddWithValue("@DeviceId", NotificationObj.DeviceId);
            com.Parameters.AddWithValue("@Status", NotificationObj.Status);
            com.Parameters.AddWithValue("@ContactId", NotificationObj.ContactId);
            {
                con.Open();
                var result = com.ExecuteNonQuery();
                con.Close();

                return true;
                //if (result > 0)
                //{
                //    return true;
                //}


                //else
                //{

                //    return false;
                //}

            }
        }
        //--------------------------------------------------InsertUserDevice---------------------------------------------------//---------
        public bool InsertUserDevice(UserDevice UserDeviceObj)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(UserDeviceObj.CD);
            SqlCommand com = new SqlCommand("spInsertUserDevice", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmailId", UserDeviceObj.EmailId);
            com.Parameters.AddWithValue("@DeviceId", UserDeviceObj.DeviceId);
            com.Parameters.AddWithValue("@ContactId", UserDeviceObj.ContactId);
            com.Parameters.AddWithValue("@CD", UserDeviceObj.CD);

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
        public bool DeleteUserDevice(UserDevice UserDeviceObj)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(UserDeviceObj.CD);
            SqlCommand com = new SqlCommand("spDeleteUserDevice", con);
            com.CommandType = CommandType.StoredProcedure;
            // com.Parameters.AddWithValue("@EmailId", UserDeviceObj.EmailId);
            com.Parameters.AddWithValue("@DeviceId", UserDeviceObj.DeviceId);
            //com.Parameters.AddWithValue("@ContactId", UserDeviceObj.ContactId);

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

        public DataTable GetStatusMaster(StatusMaster StatusMasterObj)
        {

            DataSet ds = new DataSet();
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(StatusMasterObj.CD);
            DataTable dt = new DataTable("DataTable");
            dt.Columns.Add(new DataColumn("OrderStatusId", typeof(int)));
            dt.Columns.Add(new DataColumn("OrderStatus", typeof(string)));

            SqlCommand com = new SqlCommand("[spGetStatusMaster]", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@FAQId", 0);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drSt in ds.Tables[0].Rows)
                    {
                        DataRow dr = dt.NewRow();
                        dr["OrderStatusId"] = drSt["OrderStatusId"];
                        dr["OrderStatus"] = drSt["OrderStatus"];
                        dt.Rows.Add(dr);
                    }
                    con.Close();
                }
                return dt;
            }
        }
        public DataTable GetCouponCodeDetail(CouponMasterParameter CouponMasterParameterObj)
        {

            DataSet ds = new DataSet();
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(CouponMasterParameterObj.CD);
            DataTable dt = new DataTable("DataTable");
            dt.Columns.Add(new DataColumn("CouponCode", typeof(string)));
            dt.Columns.Add(new DataColumn("Amount", typeof(float)));

            SqlCommand com = new SqlCommand("[spGetCouponCodeDetail]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CouponCode", CouponMasterParameterObj.CouponCode);



            //com.Parameters.AddWithValue("@FAQId", 0);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drSt in ds.Tables[0].Rows)
                    {
                        DataRow dr = dt.NewRow();
                        dr["CouponCode"] = drSt["CouponCode"];
                        dr["Amount"] = drSt["Amount"];
                        dt.Rows.Add(dr);
                    }
                    con.Close();
                    return dt;

                }
                else
                {
                    return null;
                }
            }
        }
        //--------------------------------------------------GetAllCouponList---------------------------------------------------//---------
        public DataSet GetAllCouponList(CouponlistDetail CouponlistDetailObj)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(CouponlistDetailObj.CD);
            DataSet ds = new DataSet();
            SqlCommand com = new SqlCommand("[spGetAllCouponList]", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@LanguageId", Countriesobj.@LanguageId);
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