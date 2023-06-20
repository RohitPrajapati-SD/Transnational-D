using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Transnational.Common;
using Transnational.Models.ServiceAndProduct;
using Transnational.VM;

namespace Transnational.Repository.ServiceAndProduct
{
    public class ServiceAndProductRepository
    {
        public DataSet GetBussinessLinebyContact(BusinesslineByContactConduction BusinesslineByContactConductionObj)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(BusinesslineByContactConductionObj.CD);
            DataSet ds = new DataSet();
            SqlCommand com = new SqlCommand("[spGetBussinessLinebyContact]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@LanguageId", BusinesslineByContactConductionObj.LanguageId);
            com.Parameters.AddWithValue("@CompanyId", BusinesslineByContactConductionObj.CompanyId);
            com.Parameters.AddWithValue("@ContactId", BusinesslineByContactConductionObj.ContactId);

            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();

            }
            return ds;
        }
        public DataSet GetContractByBusinessLineId_CompanyId(ContractByBusinessLineId_CompanyIdConduction ContractByBusinessLineId_CompanyIdConductionObj)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(ContractByBusinessLineId_CompanyIdConductionObj.CD);
            DataSet ds = new DataSet();
            SqlCommand com = new SqlCommand("[spGetContractByBusinessLineId_CompanyId]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@BusinessLineId", ContractByBusinessLineId_CompanyIdConductionObj.BusinessLineId);
            com.Parameters.AddWithValue("@ContactId", ContractByBusinessLineId_CompanyIdConductionObj.ContactId);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        public bool InsertBusinesslineSubcribion(InsertBusinesslineSubcribion InsertBusinesslineSubcribionObj)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(InsertBusinesslineSubcribionObj.CD);


            SqlCommand com = new SqlCommand("[spInsertBusinesslineSubcribion]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@BusinesslineId ", (InsertBusinesslineSubcribionObj.BusinessLineId));
            com.Parameters.AddWithValue("@ContactId", InsertBusinesslineSubcribionObj.ContactId);

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
        public DataSet GetServicesByContract(ServicesByContractConduction ServicesByContractConductionObj)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(ServicesByContractConductionObj.CD);
            DataSet ds = new DataSet();
            SqlCommand com = new SqlCommand("[spGetServicesByContract]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ContractId", ServicesByContractConductionObj.ContractId);
            com.Parameters.AddWithValue("@ServiceStartDate", ServicesByContractConductionObj.ServiceStartDate);
            com.Parameters.AddWithValue("@ServiceEndDate", ServicesByContractConductionObj.ServiceEndDate);
            com.Parameters.AddWithValue("@ContactId", ServicesByContractConductionObj.ContactId);
            com.Parameters.AddWithValue("@CityIdFrom", ServicesByContractConductionObj.CityIdFrom);
            com.Parameters.AddWithValue("@CityIdTo", ServicesByContractConductionObj.CityIdTo);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }

            return ds;
        }
        public DataSet GetAllProduct(ProductConduction ProductConductionObj, string SubBusinessLineId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(ProductConductionObj.CD);
            DataSet ds = new DataSet();
            if (ProductConductionObj.IsPublic == 1)
            {
                SqlCommand com = new SqlCommand("[spGetAllProductByContract]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@LevelId", ProductConductionObj.LevelId);
                com.Parameters.AddWithValue("@LanguageId", ProductConductionObj.LanguageId);
                com.Parameters.AddWithValue("@SubBusinessLineId", SubBusinessLineId);
                com.Parameters.AddWithValue("@CompanyId", ProductConductionObj.CompanyId);
                com.Parameters.AddWithValue("@ContactId", ProductConductionObj.ContactId);
                com.Parameters.AddWithValue("@RateFrom", ProductConductionObj.RateFrom);
                com.Parameters.AddWithValue("@RateTo", ProductConductionObj.RateTo);
                //SqlCommand com = new SqlCommand("[spGetAllProduct]", con);
                //com.CommandType = CommandType.StoredProcedure;
                //com.Parameters.AddWithValue("@LevelId", ProductConductionObj.LevelId);
                //com.Parameters.AddWithValue("@LanguageId", ProductConductionObj.LanguageId);
                //com.Parameters.AddWithValue("@SubBusinessLineId", SubBusinessLineId);
                using (SqlDataAdapter da = new SqlDataAdapter(com))
                {
                    con.Open();
                    da.Fill(ds);
                    con.Close();
                }
                return ds;

            }

             else
            {
                SqlCommand com = new SqlCommand("[spGetAllProductByContract]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@LevelId", ProductConductionObj.LevelId);
                com.Parameters.AddWithValue("@LanguageId", ProductConductionObj.LanguageId);
                com.Parameters.AddWithValue("@SubBusinessLineId", SubBusinessLineId);
                com.Parameters.AddWithValue("@CompanyId", ProductConductionObj.CompanyId);
                com.Parameters.AddWithValue("@ContactId", ProductConductionObj.ContactId);
                com.Parameters.AddWithValue("@RateFrom", ProductConductionObj.RateFrom);
                com.Parameters.AddWithValue("@RateTo", ProductConductionObj.RateTo);
                using (SqlDataAdapter da = new SqlDataAdapter(com))
                {
                    con.Open();
                    da.Fill(ds);


                    con.Close();
                }
                return ds;
            }
 

          

           
        }

        public int GetMyCartByProduct(AddtoMyCart InsertAddtoMyCartObj)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(InsertAddtoMyCartObj.CD);


            SqlCommand com = new SqlCommand("spGetMyCartByProduct", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@CartUserId", InsertAddtoMyCartObj.CartUserId);
            com.Parameters.AddWithValue("@ProductId", InsertAddtoMyCartObj.ProductId);


            {
                con.Open();
                var result = com.ExecuteScalar();
                con.Close();

                return (int)result;


            }
        }
        public bool InsertAddtoMyCart(AddtoMyCart InsertAddtoMyCartObj)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(InsertAddtoMyCartObj.CD);


            SqlCommand com = new SqlCommand("[spInsertAddtoMyCart]", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@CartUserId", InsertAddtoMyCartObj.CartUserId);
            com.Parameters.AddWithValue("@ProductId", InsertAddtoMyCartObj.ProductId);
            com.Parameters.AddWithValue("@Qty", InsertAddtoMyCartObj.Qty);
            com.Parameters.AddWithValue("@Rate", InsertAddtoMyCartObj.Rate);
            com.Parameters.AddWithValue("@Status", InsertAddtoMyCartObj.Status);
            com.Parameters.AddWithValue("@ContractId", InsertAddtoMyCartObj.ContractId);
            //com.Parameters.AddWithValue("@item_Mode", InsertAddtoMyCartObj.item_Mode);

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
        public bool DeleteMyCart(DeleteMyCart DeleteMyCartObj)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(DeleteMyCartObj.CD);


            SqlCommand com = new SqlCommand("spDeleteMyCart", con);
            com.CommandType = CommandType.StoredProcedure;


            com.Parameters.AddWithValue("@CartId", DeleteMyCartObj.CartId);
            //com.Parameters.AddWithValue("@item_Mode", InsertAddtoMyCartObj.item_Mode);

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
        public bool UpdateMyCart(AddtoMyCart InsertAddtoMyCartObj)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(InsertAddtoMyCartObj.CD);


            SqlCommand com = new SqlCommand("spUpdateMyCart", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@CartUserId", InsertAddtoMyCartObj.CartUserId);
            com.Parameters.AddWithValue("@ProductId", InsertAddtoMyCartObj.ProductId);
            com.Parameters.AddWithValue("@Qty", InsertAddtoMyCartObj.Qty);
            com.Parameters.AddWithValue("@Rate", InsertAddtoMyCartObj.Rate);

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
        public DataSet GetMyCartItem(MyCartItemConduction MyCartItemConductionObj)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(MyCartItemConductionObj.CD);
            DataSet ds = new DataSet();
            SqlCommand com = new SqlCommand("spGetMyCartItem", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CartUserId", MyCartItemConductionObj.CartUserId);
            //com.Parameters.AddWithValue("@LanguageId", ProductConductionObj.LanguageId);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);


                con.Close();
            }
            return ds;
        }

        public DataSet GetProductAnnouncement(ProductAnnouncementConduction ProductAnnouncementConductionObj)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(ProductAnnouncementConductionObj.CD);
            DataSet ds = new DataSet();
            SqlCommand com = new SqlCommand("spGetProductAnnouncement", con);
            com.CommandType = CommandType.StoredProcedure;


            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);


                con.Close();
            }
            return ds;
        }

        //---------------------------------------------GetProductRating-----------------------------------------//---------
        public DataSet GetProductRating(ProductRatingConduction ProductRatingConductionObj)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(ProductRatingConductionObj.CD);
            DataSet ds = new DataSet();
            SqlCommand com = new SqlCommand("spGetProductRating", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProductId", ProductRatingConductionObj.ProductId);

            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);


                con.Close();
            }
            return ds;
        }
        //-------------------------------------------------------GetSubBusinessLine----------------------------------------//--------------
        public DataSet GetSubBusinessLine(SubBusinessLineConduction SubBusinessLineConductionObj)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(SubBusinessLineConductionObj.CD);
            DataSet ds = new DataSet();
            SqlCommand com = new SqlCommand("spGetSubBusinessLine", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@LevelId", SubBusinessLineConductionObj.LevelId);
            com.Parameters.AddWithValue("@LanguageId", SubBusinessLineConductionObj.LanguageId);
            com.Parameters.AddWithValue("@ProductType", SubBusinessLineConductionObj.ProductType);


            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);


                con.Close();
            }
            return ds;


        }
        //-----------------------------------------------------GetSubBusinessLineEnd----------------------------------------//--------------
        public DataTable GetAllServices(AllServices AllServicesObj)
        {

            DataSet ds = new DataSet();
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(AllServicesObj.CD);
            DataTable dt = new DataTable("DataTable");
            dt.Columns.Add(new DataColumn("ServiceName", typeof(string)));
            dt.Columns.Add(new DataColumn("SeqNo", typeof(int)));

            SqlCommand com = new SqlCommand("[spGetAllServices]", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@FAQId", 0);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drSq in ds.Tables[0].Rows)
                    {
                        DataRow dr = dt.NewRow();
                        dr["ServiceName"] = drSq["ServiceName"];
                        dr["SeqNo"] = drSq["SeqNo"];
                        dt.Rows.Add(dr);
                    }
                    con.Close();
                }
                return dt;
            }
        }


        //-----------------------------------------------ServceDate--------------------------------------------------//-----------------
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            DateTime PickupdateTime;
//            int ddl = 0;
//            string ddlH1 = "";
//            string ddlM1 = "";
//            string ddlH2 = "";
//            string ddlM2 = "";
//            string ddlAM2 = "";
//            int ddlService = 0;
//            if ((ddlH1 != "HH") && (ddlM1 != "MM"))
//            {
//                PickupdateTime = DateTime.Now; // Changed for condition
//            }


//            if (ddl == 0)
//            {
//                ddlH2 = "HH";
//                ddlM2 = "MM";
//                ddlAM2 = "AM";
//            }
//            else
//            {
//                if ((ddlH1 == "HH") || (ddlM1 == "MM"))
//                {
//                    ddlService = 0;
//                    Script("Please select Collection Request Time");
//                }
//                else if (checkdateDayType(ddlService, "main", "col") == false)
//                {

//                }
//            }

//        }
//        public void Script(string Mesasage)
//        {
//            string popupScript = "<script language=JavaScript>";
//            popupScript += "alert('" + Mesasage + "');";
//            popupScript += "</";
//            popupScript += "script>";
//            Page.RegisterStartupScript("PopupScript", popupScript);
//        }
//        public SqlDataReader FillDataReader(string SqlSelect)
//        {
//           // SqlConnection Conn = new SqlConnection(ConfigurationSettings.AppSettings("DSN") + System.Convert.ToString(Session("DBName")));
//            DbConnections conobj = new DbConnections();
//            var con = conobj.connection();
//            SqlCommand ObjCmd = new SqlCommand();
//            SqlDataReader Rdr;
//            ObjCmd.CommandText = SqlSelect;
//            ObjCmd.Connection = con;
//            //try
//            //{
//                con.Open();
//                Rdr = ObjCmd.ExecuteReader(CommandBehavior.CloseConnection);
//            //}
//            //catch (Exception err)
//            //{
//            //    Response.write(err.Message);
//            //}
//            return Rdr;

//        }
//        public bool checkdateDayType(int SeqNo, string serviceType, string chkColDly = "all")
//        {
//            //vks_dbLayer DataAccess = new vks_dbLayer(ConfigurationSettings.AppSettings("DSN") + System.Convert.ToString(Session("DBName")));
//            //CommFunction CommFunctionObj = new CommFunction(ConfigurationSettings.AppSettings("DSN") + System.Convert.ToString(Session("DBName")));
//            DbConnections conobj = new DbConnections();
//            var con = conobj.connection();
//            DateTime colPickupDateTime, ColDlydateTime, rtnPickupDateTime, rtnDlydateTime;
//            colPickupDateTime= DateTime.Now;   // Changed for condition
//            ColDlydateTime = DateTime.Now;   // Changed for condition
//            // 'Code for Calling Function
//            if (serviceType == "main")
//            {
//                if (chkColDly == "all" | chkColDly == "col")
//                    colPickupDateTime = getPickUpDate();
//                if (chkColDly == "all" | chkColDly == "dly")
//                    // ColDlydateTime = getColDlyDate(); // Changed for condition
//                    ColDlydateTime = DateTime.Now;
//            }
//            else
//            {
//                if (chkColDly == "all" | chkColDly == "col")
//                    // colPickupDateTime = getReturnPickUpDate();  // Changed for condition
//                    colPickupDateTime = DateTime.Now;
//                if (chkColDly == "all" | chkColDly == "dly")
//                    //ColDlydateTime = getReturnDlyDate();  // Changed for condition
//                    ColDlydateTime = DateTime.Now;
//            }

//            int BSID = 0;
//            // BSID = DataAccess.ExecuteScaler("select BusinessUnitId from tblCompany where CompanyId=" + System.Convert.ToString(ddlCompany.SelectedValue) + ""); // Changed for condition
//            BSID = Int16.Parse("select BusinessUnitId from tblCompany where CompanyId=" + System.Convert.ToString(5) + "");
//            using (SqlCommand command = new SqlCommand(BSID.ToString(), con))
//            {
//                string value = (string)command.ExecuteScalar();
//                BSID= 1;

//            }

//            string ErrorMSG = "";
//            bool Save, chkCondition;
//            Save = true;
//            chkCondition = false;
//            try
//            {
//                // 'Product attributes
//                string SqlSelect;
//                Boolean weekday, weekend, AfterOfzHour, PublicHoliday;
//                weekday = false; weekend = false; AfterOfzHour = false; PublicHoliday = false;
//                SqlDataReader rdr;
//                SqlSelect = "select SeqNo, ClientOrderScreen,InclusiveTax,";
//                SqlSelect += "  ApplyRateMatrix, PublicHoliday, weekday, weekend, AfterOfzHour";
//                SqlSelect += " from tblProductPrice where SeqNo = " + SeqNo + " and LanguageId = 1 ";
//                rdr = FillDataReader(SqlSelect);
//                while (rdr.Read())
//                {

//                    if ((rdr["weekday"]) != null)
//                        weekday = Convert.ToBoolean(rdr["weekday"]);
//                    if ((rdr["weekend"]) != null)
//                        weekend = Convert.ToBoolean(rdr["weekend"]);
//                    if ((rdr["AfterOfzHour"]) != null)
//                        AfterOfzHour = Convert.ToBoolean(rdr["AfterOfzHour"]);
//                    if ((rdr["PublicHoliday"]) != null)
//                        PublicHoliday = Convert.ToBoolean(rdr["PublicHoliday"]);
//                }

//                if (PublicHoliday == true)
//                {
//                    // Collection day can be on the holiday dates and collection time can be any time (no validation for time)
//                    // AND/OR
//                    // Delivery day must be on the holiday dates and delivery time can be any time (no validation for time)
//                    if (chkColDly == "all")
//                    {
//                        if (chkServiceWithBranch(colPickupDateTime , BSID, "holiday") == true & chkServiceWithBranch(ColDlydateTime, BSID, "holiday") == true)
//                            chkCondition = true;
//                        else
//                        {
//                            if (weekday == true & AfterOfzHour == false)
//                            {
//                                // Collection day must be on a working day (ie:Monday to Friday) and collection time must be in the working hours range (working on Client logins
//                                // AND
//                                // Delivery day must be on a working day (ie:Monday to Friday) and delivery time must be in the working hours range 
//                                if (chkColDly == "all")
//                                {
//                                    if (chkServiceWithBranch(colPickupDateTime, BSID, "weekday") == true)
//                                    {
//                                        if (checkWorkingHour(colPickupDateTime, BSID) == true)
//                                        {
//                                            if (chkServiceWithBranch(ColDlydateTime, BSID, "weekday") == true)
//                                            {
//                                                if (checkWorkingHour(ColDlydateTime, BSID) == true)
//                                                    chkCondition = true;
//                                            }
//                                        }
//                                    }
//                                }
//                                if (chkColDly == "col")
//                                {
//                                    if (chkServiceWithBranch(colPickupDateTime, BSID, "weekday") == true)
//                                    {
//                                        if (checkWorkingHour(colPickupDateTime, BSID) == true)
//                                            chkCondition = true;
//                                        else
//                                        {
//                                            Save = false;
//                                            ErrorMSG = "collection time must be in the working hours range.";
//                                        }
//                                    }
//                                    else
//                                    {
//                                        Save = false;
//                                        ErrorMSG = "Collection day must be on a working day.";
//                                    }
//                                }
//                                if (chkColDly == "dly")
//                                {
//                                    if (chkServiceWithBranch(ColDlydateTime, BSID, "weekday") == true)
//                                    {
//                                        if (checkWorkingHour(ColDlydateTime, BSID) == true)
//                                            chkCondition = true;
//                                        else
//                                        {
//                                            Save = false;
//                                            ErrorMSG = "delivery time must be in the working hours range.";
//                                        }
//                                    }
//                                    else
//                                    {
//                                        Save = false;
//                                        ErrorMSG = "Delivery day must be on a working day.";
//                                    }
//                                }
//                            }
//                            if (weekday == true & AfterOfzHour == true)
//                            {
//                                // Collection day must be on a working day (ie:Monday to Friday) and collection time can be after the working hours range
//                                // AND/OR
//                                // Delivery day must be on a working day (ie:Monday to Friday) and delivery time can be after the working hours range
//                                if (chkColDly == "all")
//                                {
//                                    if (chkServiceWithBranch(colPickupDateTime, BSID, "weekday") == true & chkServiceWithBranch(ColDlydateTime, BSID, "weekday") == true)
//                                        chkCondition = true;
//                                }
//                                if (chkColDly == "col")
//                                {
//                                    if (chkServiceWithBranch(colPickupDateTime, BSID, "weekday") == true)
//                                        chkCondition = true;
//                                    else
//                                    {
//                                        Save = false;
//                                        ErrorMSG = "Collection day must be on a working day.";
//                                    }
//                                }
//                                if (chkColDly == "dly")
//                                {
//                                    if (chkServiceWithBranch(ColDlydateTime, BSID, "weekday") == true)
//                                        chkCondition = true;
//                                    else
//                                    {
//                                        Save = false;
//                                        ErrorMSG = "Delivery day must be on a working day.";
//                                    }
//                                }
//                            }

//                            if (weekend == true)
//                            {
//                                // 'Collection day can be on the non-working day and collection time can be any time (no validation for time)
//                                // 'AND/OR
//                                // 'Delivery day must be on the non-working day and delivery time can be any time (no validation for time)
//                                if (chkColDly == "all")
//                                {
//                                    if (chkServiceWithBranch(colPickupDateTime, BSID, "weekweekend") == true & chkServiceWithBranch(ColDlydateTime, BSID, "weekend") == true)
//                                        chkCondition = true;
//                                }
//                                if (chkColDly == "col")
//                                {
//                                    if (chkServiceWithBranch(colPickupDateTime, BSID, "weekweekend") == true)
//                                        chkCondition = true;
//                                    else
//                                    {
//                                        Save = false;
//                                        ErrorMSG = "Collection day can be on the working or non-working day only.";
//                                    }
//                                }
//                                if (chkColDly == "dly")
//                                {
//                                    if (chkServiceWithBranch(ColDlydateTime, BSID, "weekend") == true)
//                                        chkCondition = true;
//                                    else
//                                    {
//                                        Save = false;
//                                        ErrorMSG = "Delivery day must be on the working or non-working day.";
//                                    }
//                                }
//                            }
//                        }
//                    }
//                    if (chkColDly == "col")
//                    {
//                        if (chkServiceWithBranch(colPickupDateTime, BSID, "holiday") == true)
//                            chkCondition = true;
//                        else
//                        {
//                            if (weekday == true & AfterOfzHour == false)
//                            {
//                                // Collection day must be on a working day (ie:Monday to Friday) and collection time must be in the working hours range (working on Client logins
//                                // AND
//                                // Delivery day must be on a working day (ie:Monday to Friday) and delivery time must be in the working hours range 
//                                if (chkColDly == "all")
//                                {
//                                    if (chkServiceWithBranch(colPickupDateTime, BSID, "weekday") == true)
//                                    {
//                                        if (checkWorkingHour(colPickupDateTime, BSID) == true)
//                                        {
//                                            if (chkServiceWithBranch(ColDlydateTime, BSID, "weekday") == true)
//                                            {
//                                                if (checkWorkingHour(ColDlydateTime, BSID) == true)
//                                                    chkCondition = true;
//                                            }
//                                        }
//                                    }
//                                }
//                                if (chkColDly == "col")
//                                {
//                                    if (chkServiceWithBranch(colPickupDateTime, BSID, "weekday") == true)
//                                    {
//                                        if (checkWorkingHour(colPickupDateTime, BSID) == true)
//                                            chkCondition = true;
//                                        else
//                                        {
//                                            Save = false;
//                                            ErrorMSG = "collection time must be in the working hours range.";
//                                        }
//                                    }
//                                    else
//                                    {
//                                        Save = false;
//                                        ErrorMSG = "Collection day must be on a working day.";
//                                    }
//                                }
//                                if (chkColDly == "dly")
//                                {
//                                    if (chkServiceWithBranch(ColDlydateTime, BSID, "weekday") == true)
//                                    {
//                                        if (checkWorkingHour(ColDlydateTime, BSID) == true)
//                                            chkCondition = true;
//                                        else
//                                        {
//                                            Save = false;
//                                            ErrorMSG = "delivery time must be in the working hours range.";
//                                        }
//                                    }
//                                    else
//                                    {
//                                        Save = false;
//                                        ErrorMSG = "Delivery day must be on a working day.";
//                                    }
//                                }
//                            }
//                            if (weekday == true & AfterOfzHour == true)
//                            {
//                                // Collection day must be on a working day (ie:Monday to Friday) and collection time can be after the working hours range
//                                // AND/OR
//                                // Delivery day must be on a working day (ie:Monday to Friday) and delivery time can be after the working hours range
//                                if (chkColDly == "all")
//                                {
//                                    if (chkServiceWithBranch(colPickupDateTime, BSID, "weekday") == true & chkServiceWithBranch(ColDlydateTime, BSID, "weekday") == true)
//                                        chkCondition = true;
//                                }
//                                if (chkColDly == "col")
//                                {
//                                    if (chkServiceWithBranch(colPickupDateTime, BSID, "weekday") == true)
//                                        chkCondition = true;
//                                    else
//                                    {
//                                        Save = false;
//                                        ErrorMSG = "Collection day must be on a working day.";
//                                    }
//                                }
//                                if (chkColDly == "dly")
//                                {
//                                    if (chkServiceWithBranch(ColDlydateTime, BSID, "weekday") == true)
//                                        chkCondition = true;
//                                    else
//                                    {
//                                        Save = false;
//                                        ErrorMSG = "Delivery day must be on a working day.";
//                                    }
//                                }
//                            }

//                            if (weekend == true)
//                            {
//                                // 'Collection day can be on the non-working day and collection time can be any time (no validation for time)
//                                // 'AND/OR
//                                // 'Delivery day must be on the non-working day and delivery time can be any time (no validation for time)
//                                if (chkColDly == "all")
//                                {
//                                    if (chkServiceWithBranch(colPickupDateTime, BSID, "weekweekend") == true & chkServiceWithBranch(ColDlydateTime, BSID, "weekend") == true)
//                                        chkCondition = true;
//                                }
//                                if (chkColDly == "col")
//                                {
//                                    if (chkServiceWithBranch(colPickupDateTime, BSID, "weekweekend") == true)
//                                        chkCondition = true;
//                                    else
//                                    {
//                                        Save = false;
//                                        ErrorMSG = "Collection day can be on the working or non-working day only.";
//                                    }
//                                }
//                                if (chkColDly == "dly")
//                                {
//                                    if (chkServiceWithBranch(ColDlydateTime, BSID, "weekend") == true)
//                                        chkCondition = true;
//                                    else
//                                    {
//                                        Save = false;
//                                        ErrorMSG = "Delivery day must be on the working or non-working day.";
//                                    }
//                                }
//                            }
//                        }
//                    }
//                    if (chkColDly == "dly")
//                    {
//                        if (chkServiceWithBranch(ColDlydateTime, BSID, "holiday") == true)
//                            chkCondition = true;
//                        else
//                        {
//                            if (weekday == true & AfterOfzHour == false)
//                            {
//                                // Collection day must be on a working day (ie:Monday to Friday) and collection time must be in the working hours range (working on Client logins
//                                // AND
//                                // Delivery day must be on a working day (ie:Monday to Friday) and delivery time must be in the working hours range 
//                                if (chkColDly == "all")
//                                {
//                                    if (chkServiceWithBranch(colPickupDateTime, BSID, "weekday") == true)
//                                    {
//                                        if (checkWorkingHour(colPickupDateTime, BSID) == true)
//                                        {
//                                            if (chkServiceWithBranch(ColDlydateTime, BSID, "weekday") == true)
//                                            {
//                                                if (checkWorkingHour(ColDlydateTime, BSID) == true)
//                                                    chkCondition = true;
//                                            }
//                                        }
//                                    }
//                                }
//                                if (chkColDly == "col")
//                                {
//                                    if (chkServiceWithBranch(colPickupDateTime, BSID, "weekday") == true)
//                                    {
//                                        if (checkWorkingHour(colPickupDateTime, BSID) == true)
//                                            chkCondition = true;
//                                        else
//                                        {
//                                            Save = false;
//                                            ErrorMSG = "collection time must be in the working hours range.";
//                                        }
//                                    }
//                                    else
//                                    {
//                                        Save = false;
//                                        ErrorMSG = "Collection day must be on a working day.";
//                                    }
//                                }
//                                if (chkColDly == "dly")
//                                {
//                                    if (chkServiceWithBranch(ColDlydateTime, BSID, "weekday") == true)
//                                    {
//                                        if (checkWorkingHour(ColDlydateTime, BSID) == true)
//                                            chkCondition = true;
//                                        else
//                                        {
//                                            Save = false;
//                                            ErrorMSG = "delivery time must be in the working hours range.";
//                                        }
//                                    }
//                                    else
//                                    {
//                                        Save = false;
//                                        ErrorMSG = "Delivery day must be on a working day.";
//                                    }
//                                }
//                            }
//                            if (weekday == true & AfterOfzHour == true)
//                            {
//                                // Collection day must be on a working day (ie:Monday to Friday) and collection time can be after the working hours range
//                                // AND/OR
//                                // Delivery day must be on a working day (ie:Monday to Friday) and delivery time can be after the working hours range
//                                if (chkColDly == "all")
//                                {
//                                    if (chkServiceWithBranch(colPickupDateTime, BSID, "weekday") == true & chkServiceWithBranch(ColDlydateTime, BSID, "weekday") == true)
//                                        chkCondition = true;
//                                }
//                                if (chkColDly == "col")
//                                {
//                                    if (chkServiceWithBranch(colPickupDateTime, BSID, "weekday") == true)
//                                        chkCondition = true;
//                                    else
//                                    {
//                                        Save = false;
//                                        ErrorMSG = "Collection day must be on a working day.";
//                                    }
//                                }
//                                if (chkColDly == "dly")
//                                {
//                                    if (chkServiceWithBranch(ColDlydateTime, BSID, "weekday") == true)
//                                        chkCondition = true;
//                                    else
//                                    {
//                                        Save = false;
//                                        ErrorMSG = "Delivery day must be on a working day.";
//                                    }
//                                }
//                            }

//                            if (weekend == true)
//                            {
//                                // 'Collection day can be on the non-working day and collection time can be any time (no validation for time)
//                                // 'AND/OR
//                                // 'Delivery day must be on the non-working day and delivery time can be any time (no validation for time)
//                                if (chkColDly == "all")
//                                {
//                                    if (chkServiceWithBranch(colPickupDateTime, BSID, "weekweekend") == true & chkServiceWithBranch(ColDlydateTime, BSID, "weekend") == true)
//                                        chkCondition = true;
//                                }
//                                if (chkColDly == "col")
//                                {
//                                    if (chkServiceWithBranch(colPickupDateTime, BSID, "weekweekend") == true)
//                                        chkCondition = true;
//                                    else
//                                    {
//                                        Save = false;
//                                        ErrorMSG = "Collection day can be on the working or non-working day only.";
//                                    }
//                                }
//                                if (chkColDly == "dly")
//                                {
//                                    if (chkServiceWithBranch(ColDlydateTime, BSID, "weekend") == true)
//                                        chkCondition = true;
//                                    else
//                                    {
//                                        Save = false;
//                                        ErrorMSG = "Delivery day must be on the working or non-working day.";
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//                else
//                {
//                    if (weekday == true & AfterOfzHour == false)
//                    {
//                        // Collection day must be on a working day (ie:Monday to Friday) and collection time must be in the working hours range (working on Client logins
//                        // AND
//                        // Delivery day must be on a working day (ie:Monday to Friday) and delivery time must be in the working hours range 
//                        if (chkColDly == "all")
//                        {
//                            if (chkServiceWithBranch(colPickupDateTime, BSID, "weekday") == true)
//                            {
//                                if (checkWorkingHour(colPickupDateTime, BSID) == true)
//                                {
//                                    if (chkServiceWithBranch(ColDlydateTime, BSID, "weekday") == true)
//                                    {
//                                        if (checkWorkingHour(ColDlydateTime, BSID) == true)
//                                            chkCondition = true;
//                                    }
//                                }
//                            }
//                        }
//                        if (chkColDly == "col")
//                        {
//                            if (chkServiceWithBranch(colPickupDateTime, BSID, "weekday") == true)
//                            {
//                                if (checkWorkingHour(colPickupDateTime, BSID) == true)
//                                    chkCondition = true;
//                                else
//                                {
//                                    Save = false;
//                                    ErrorMSG = "collection time must be in the working hours range.";
//                                }
//                            }
//                            else
//                            {
//                                Save = false;
//                                ErrorMSG = "Collection day must be on a working day.";
//                            }
//                        }
//                        if (chkColDly == "dly")
//                        {
//                            if (chkServiceWithBranch(ColDlydateTime, BSID, "weekday") == true)
//                            {
//                                if (checkWorkingHour(ColDlydateTime, BSID) == true)
//                                    chkCondition = true;
//                                else
//                                {
//                                    Save = false;
//                                    ErrorMSG = "delivery time must be in the working hours range.";
//                                }
//                            }
//                            else
//                            {
//                                Save = false;
//                                ErrorMSG = "Delivery day must be on a working day.";
//                            }
//                        }
//                    }
//                    if (weekday == true & AfterOfzHour == true)
//                    {
//                        // Collection day must be on a working day (ie:Monday to Friday) and collection time can be after the working hours range
//                        // AND/OR
//                        // Delivery day must be on a working day (ie:Monday to Friday) and delivery time can be after the working hours range
//                        if (chkColDly == "all")
//                        {
//                            if (chkServiceWithBranch(colPickupDateTime, BSID, "weekday") == true & chkServiceWithBranch(ColDlydateTime, BSID, "weekday") == true)
//                                chkCondition = true;
//                        }
//                        if (chkColDly == "col")
//                        {
//                            if (chkServiceWithBranch(colPickupDateTime, BSID, "weekday") == true)
//                                chkCondition = true;
//                            else
//                            {
//                                Save = false;
//                                ErrorMSG = "Collection day must be on a working day.";
//                            }
//                        }
//                        if (chkColDly == "dly")
//                        {
//                            if (chkServiceWithBranch(ColDlydateTime, BSID, "weekday") == true)
//                                chkCondition = true;
//                            else
//                            {
//                                Save = false;
//                                ErrorMSG = "Delivery day must be on a working day.";
//                            }
//                        }
//                    }

//                    if (weekend == true)
//                    {
//                        // 'Collection day can be on the non-working day and collection time can be any time (no validation for time)
//                        // 'AND/OR
//                        // 'Delivery day must be on the non-working day and delivery time can be any time (no validation for time)
//                        if (chkColDly == "all")
//                        {
//                            if (chkServiceWithBranch(colPickupDateTime, BSID, "weekweekend") == true & chkServiceWithBranch(ColDlydateTime, BSID, "weekend") == true)
//                                chkCondition = true;
//                        }
//                        if (chkColDly == "col")
//                        {
//                            if (chkServiceWithBranch(colPickupDateTime, BSID, "weekweekend") == true)
//                                chkCondition = true;
//                            else
//                            {
//                                Save = false;
//                                ErrorMSG = "Collection day can be on the working or non-working day only.";
//                            }
//                        }
//                        if (chkColDly == "dly")
//                        {
//                            if (chkServiceWithBranch(ColDlydateTime, BSID, "weekend") == true)
//                                chkCondition = true;
//                            else
//                            {
//                                Save = false;
//                                ErrorMSG = "Delivery day must be on the working or non-working day.";
//                            }
//                        }
//                    }
//                }
//                //  Changed for condition
//                //if (chkCondition == false)
//                //{
//                //    // If Save = True Then
//                //    // Else
//                //    if (serviceType != "main")
//                //        Session("errormsg") = "Return invalid selection ! Please call Customer Service for assistant";
//                //    else
//                //        Session("errormsg") = "Invalid selection ! Please call Customer Service for assistant";
//                //}
               
//            }
//            catch (Exception ex)
//            {
//                Script("Failed! unable to get Contract Services.");
//            }
//            return chkCondition;
//        }
//        public bool chkServiceWithBranch(DateTime checkingDate, int BSID, string ChkType)
//        {
//            DbConnections conobj = new DbConnections();
//            var con = conobj.connection();
//            bool returnBool = false;
//            DateTime PickupdateTime = checkingDate;
//            string todayday = PickupdateTime.ToString("dddd");
//            string pickUpTime;
//            pickUpTime = Strings.Format(PickupdateTime, "HH:mm:ss") + ":000";


//            if (ChkType == "weekday")
//            {
//                if (DataAccess.ExecuteScaler("select count(*) from tblBusinessUnitTiming where HDay='" + todayday + "' and BranchId=" + BSID + "") > 0)
//                    returnBool = true;
//            }
//            if (ChkType == "weekdayNHD")
//            {
//                if (DataAccess.ExecuteScaler("select count(*) from tblBusinessUnitTiming where HDay='" + todayday + "' and BranchId=" + BSID + "") > 0)
//                    returnBool = true;

//                //if (DataAccess.ExecuteScaler("select count(*) from tblBusinessUnitHoliday BUH,tblHoliday HD where BUH.HolidayId = HD.HolidayId and HolidayDate = '" + Strings.Format(PickupdateTime, "MM/dd/yyyy") + "' and BUH.BranchId=" + BSID + "") > 0)   // Changed for condition
//                if (DataAccess.ExecuteScaler("select count(*) from tblBusinessUnitHoliday BUH,tblHoliday HD where BUH.HolidayId = HD.HolidayId and HolidayDate = '2013-02-04 11:40:44.000' and BUH.BranchId=" + BSID + "") > 0)
//                    returnBool = false;
//            }

//            if (ChkType == "weekend")
//            {
//                //if (DataAccess.ExecuteScalerString("select Weekend  from tblProductPrice where SeqNo = " + ddlService.SelectedValue + " and LanguageId = 1") == "True")  // Changed for condition
//                if (DataAccess.ExecuteScalerString("select Weekend  from tblProductPrice where SeqNo = 1 and LanguageId = 1") == "True")
//                    returnBool = true;
//            }
//            if (ChkType == "weekendNHD")
//            {
//                if (DataAccess.ExecuteScaler("select count(*) from tblBusinessUnitTiming where HDay='" + todayday + "' and BranchId=" + BSID + "") > 0)
//                    returnBool = true;
//                //if (DataAccess.ExecuteScaler("select count(*) from tblBusinessUnitHoliday BUH,tblHoliday HD where BUH.HolidayId = HD.HolidayId and HolidayDate = '" + Strings.Format(PickupdateTime, "MM/dd/yyyy") + "' and BUH.BranchId=" + BSID + "") > 0)   // Changed for condition
//                if (DataAccess.ExecuteScaler("select count(*) from tblBusinessUnitHoliday BUH,tblHoliday HD where BUH.HolidayId = HD.HolidayId and HolidayDate = '2013-02-04 11:40:44.000' and BUH.BranchId=" + BSID + "") > 0)
//                    returnBool = false;
//            }
//            if (ChkType == "holiday")
//            {
//                //if (DataAccess.ExecuteScaler("select count(*) from tblBusinessUnitHoliday BUH,tblHoliday HD where BUH.HolidayId = HD.HolidayId and HolidayDate = '" + Strings.Format(PickupdateTime, "MM/dd/yyyy") + "' and BUH.BranchId=" + BSID + "") > 0)  // Changed for condition
//                if (DataAccess.ExecuteScaler("select count(*) from tblBusinessUnitHoliday BUH,tblHoliday HD where BUH.HolidayId = HD.HolidayId and HolidayDate = '" + Strings.Format(PickupdateTime, "MM/dd/yyyy") + "' and BUH.BranchId=" + BSID + "") > 0)
//                    returnBool = true;
//            }
//            if (ChkType == "weekweekend")
//            {
//                // if (DataAccess.ExecuteScalerString("select Weekend  from tblProductPrice where SeqNo = " + ddlService.SelectedValue + " and LanguageId = 1") == "True")   // Changed for condition
//                if (DataAccess.ExecuteScalerString("select Weekend  from tblProductPrice where SeqNo = 1 and LanguageId = 1") == "True")
//                    returnBool = true;
//            }
//            if (ChkType == "weekweekendNHD")
//            {
//                if (DataAccess.ExecuteScaler("select count(*) from tblBusinessUnitTiming where HDay='" + todayday + "' and BranchId=" + BSID + "") > 0)
//                    returnBool = true;
//                if (DataAccess.ExecuteScaler("select count(*) from tblBusinessUnitTiming where HDay='" + todayday + "' and BranchId=" + BSID + "") > 0)
//                    returnBool = true;
//                //if (DataAccess.ExecuteScaler("select count(*) from tblBusinessUnitHoliday BUH,tblHoliday HD where BUH.HolidayId = HD.HolidayId and HolidayDate = '" + Strings.Format(PickupdateTime, "MM/dd/yyyy") + "' and BUH.BranchId=" + BSID + "") > 0)    // Changed for condition
//                if (DataAccess.ExecuteScaler("select count(*) from tblBusinessUnitHoliday BUH,tblHoliday HD where BUH.HolidayId = HD.HolidayId and HolidayDate = '2013-02-04 11:40:44.000' and BUH.BranchId=" + BSID + "") > 0)
//                    returnBool = false;
//            }
//            if (ChkType == "any")
//            {
//                if (DataAccess.ExecuteScaler("select count(*) from tblBusinessUnitTiming where HDay='" + todayday + "' and BranchId=" + BSID + "") > 0)
//                    returnBool = true;
//                if (DataAccess.ExecuteScaler("select count(*) from tblBusinessUnitTiming where HDay='" + todayday + "' and BranchId=" + BSID + "") > 0)
//                    returnBool = true;
//                //if (DataAccess.ExecuteScaler("select count(*) from tblBusinessUnitHoliday BUH,tblHoliday HD where BUH.HolidayId = HD.HolidayId and HolidayDate = '" + Strings.Format(PickupdateTime, "MM/dd/yyyy") + "' and BUH.BranchId=" + BSID + "") > 0)
//                if (DataAccess.ExecuteScaler("select count(*) from tblBusinessUnitHoliday BUH,tblHoliday HD where BUH.HolidayId = HD.HolidayId and HolidayDate = '2013-02-04 11:40:44.000' and BUH.BranchId=" + BSID + "") > 0)

//                    returnBool = true;
//            }

//            return returnBool;
//        }
//        public bool checkWorkingHour(DateTime chkDateTime, int BSID)
//        {
//            CommFunction CommFunctionObj = new CommFunction(ConfigurationSettings.AppSettings("DSN") + System.Convert.ToString(Session("DBName")));
//            vks_dbLayer DataAccess = new vks_dbLayer(ConfigurationSettings.AppSettings("DSN") + System.Convert.ToString(Session("DBName")));
//            string todayday = chkDateTime.ToString("dddd");
//            string timeTomatch;
//            timeTomatch = Strings.Format(chkDateTime, "HH:mm:ss") + ":000";
//            if (CommFunctionObj.getServiceProperties(ddlService.SelectedValue, "AfterOfzHour") == false)
//            {
//                if (DataAccess.ExecuteScaler("select count(*)  from tblBusinessUnitTiming where branchId='" + BSID + "' and HDay='" + todayday + "'  and  '" + timeTomatch + "'  between Convert(varchar,TimeFrom,14) and Convert(varchar,TimeTo,14) ") > 0)
//                    return true;
//                else
//                    return false;
//            }
//            else
//                return true;
//        }

//        public DateTime getPickUpDate()
//        {
//            string[] dateStr;
//            var DateString;
//            DateString = txtPickupp.Value.ToString();
//            dateStr = DateString.Split("/");
//            DateString = dateStr[1] + "/" + dateStr[0] + "/" + dateStr[2];
//            string PickupdT = DateString + " " + ddlH1.Text + ":" + ddlM1.Text + ":00 " + ddlAM1.Text;
//            DateTime PickupdateTime = Strings.Format((DateTime)PickupdT, "MM/dd/yyyy hh:mm:ss tt");
//            return PickupdateTime;
//        }

//        //public DateTime getPickUpDate()
//        //{
//        //    string[] dateStr;
//        //    var DateString;
//        //    DateString = txtPickupp.Value.ToString();
//        //    dateStr = DateString.Split("/");
//        //    DateString = dateStr[1] + "/" + dateStr[0] + "/" + dateStr[2];
//        //    string PickupdT = DateString + " " + ddlH1.Text + ":" + ddlM1.Text + ":00 " + ddlAM1.Text;
//        //    DateTime PickupdateTime = Strings.Format((DateTime)PickupdT, "MM/dd/yyyy hh:mm:ss tt");
//        //    return PickupdateTime;
//        //}

//    }
//}
    }
}
