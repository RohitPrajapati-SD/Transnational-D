using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Transnational.Common;
using Transnational.Models.Order;

namespace Transnational.Repository.Order
{
    public class OrderRepository
    {
        
        private SqlCommand com;

      

        public int AddNewOrder(Orders ord, string dbParam)
        {
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            com = new SqlCommand("spInsertNewOrder", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@OStatus", commnfun.SafeDbObject(ord.OStatus));
            com.Parameters.AddWithValue("@CompanyId", commnfun.SafeDbObject(ord.CompanyId));
            com.Parameters.AddWithValue("@CreatedByType", commnfun.SafeDbObject(ord.CreatedByType));
            com.Parameters.AddWithValue("@SpecialInstructions", commnfun.SafeDbObject(ord.SpecialInstructions));
            com.Parameters.AddWithValue("@OrderNo", commnfun.SafeDbObject(ord.OrderNo));
            com.Parameters.AddWithValue("@BillTo", commnfun.SafeDbObject(ord.BillTo));
            com.Parameters.AddWithValue("@EstimatedCost", commnfun.SafeDbObject(ord.EstimatedCost));
            com.Parameters.AddWithValue("@Weight", commnfun.SafeDbObject(ord.Weight));
            com.Parameters.AddWithValue("@Quantity", commnfun.SafeDbObject(ord.Quantity));
            com.Parameters.AddWithValue("@Volume1", commnfun.SafeDbObject(ord.Volume1));
            com.Parameters.AddWithValue("@Volume2", commnfun.SafeDbObject(ord.Volume2));
            com.Parameters.AddWithValue("@Volume3", commnfun.SafeDbObject(ord.Volume3));
            com.Parameters.AddWithValue("@PickupDate", commnfun.SafeDbObject(ord.PickupDate));
            com.Parameters.AddWithValue("@DeliveryDate", commnfun.SafeDbObject(ord.DeliveryDate));
            com.Parameters.AddWithValue("@PickupTime", commnfun.SafeDbObject(ord.PickupTime));
            com.Parameters.AddWithValue("@DeliveryTime", commnfun.SafeDbObject(ord.DeliveryTime));
            com.Parameters.AddWithValue("@LanguageId", commnfun.SafeDbObject(ord.LanguageId));
            com.Parameters.AddWithValue("@CreatedBy", commnfun.SafeDbObject(ord.CreatedBy));
            com.Parameters.AddWithValue("@UpdatedBy", commnfun.SafeDbObject(ord.UpdatedBy));
            com.Parameters.AddWithValue("@CreatedDate", commnfun.SafeDbObject(ord.CreatedDate));
            com.Parameters.AddWithValue("@LastUpdatedDate", commnfun.SafeDbObject(ord.LastUpdatedDate));
            com.Parameters.AddWithValue("@ContractCostCntrDprt", commnfun.SafeDbObject(ord.ContractCostCntrDprt));
            com.Parameters.AddWithValue("@QuantityUomId", commnfun.SafeDbObject(ord.QuantityUomId));
            com.Parameters.AddWithValue("@RequestorName", commnfun.SafeDbObject(ord.RequestorName));
            com.Parameters.AddWithValue("@AlternateRefNo", commnfun.SafeDbObject(ord.AlternateRefNo));
            com.Parameters.AddWithValue("@CBranchId", commnfun.SafeDbObject(ord.CBranchId));
            com.Parameters.AddWithValue("@Status", commnfun.SafeDbObject(ord.Status));
            com.Parameters.AddWithValue("@ReturnService", commnfun.SafeDbObject(ord.ReturnService));
            com.Parameters.AddWithValue("@parentChild", commnfun.SafeDbObject(ord.parentChild));
            com.Parameters.AddWithValue("@ServiceId", commnfun.SafeDbObject(ord.ServiceId));
            com.Parameters.AddWithValue("@ContractId", commnfun.SafeDbObject(ord.ContractId));
            com.Parameters.AddWithValue("@BillToType", commnfun.SafeDbObject(ord.BillToType));
            com.Parameters.AddWithValue("@approve", commnfun.SafeDbObject(ord.approve));
            SqlParameter RuturnValue = new SqlParameter("@InvoiceId", SqlDbType.Int);
            RuturnValue.Direction = ParameterDirection.Output;
            com.Parameters.Add(RuturnValue);
            con.Open();
            int i = com.ExecuteNonQuery();
            var InvoiceId = (int)com.Parameters["@InvoiceId"].Value;
            con.Close();
            if (InvoiceId >= 0)
            {
                return InvoiceId;
            }
            else
            {
                return 0;
            }
        }


        public int AddOrderAddress(OrderAddress OrdAdd, string dbParam)
        {
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            com = new SqlCommand("spInsertInvoiceAddress", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@InvoiceId", commnfun.SafeDbObject(OrdAdd.InvoiceId));
            com.Parameters.AddWithValue("@AddressType", commnfun.SafeDbObject(OrdAdd.AddressType));
            com.Parameters.AddWithValue("@Address", commnfun.SafeDbObject(OrdAdd.Address));
            com.Parameters.AddWithValue("@Address2", commnfun.SafeDbObject(OrdAdd.Address2));
            com.Parameters.AddWithValue("@Address3", commnfun.SafeDbObject(OrdAdd.Address3));
            com.Parameters.AddWithValue("@Address4", commnfun.SafeDbObject(OrdAdd.Address4));
            com.Parameters.AddWithValue("@CountryId", commnfun.SafeDbObject(OrdAdd.CountryId));
            com.Parameters.AddWithValue("@CityId", commnfun.SafeDbObject(OrdAdd.CityId));
            com.Parameters.AddWithValue("@StateId", commnfun.SafeDbObject(OrdAdd.StateId));
            com.Parameters.AddWithValue("@DistrictId", commnfun.SafeDbObject(OrdAdd.DistrictId));
            com.Parameters.AddWithValue("@SpecialInstruction", commnfun.SafeDbObject(OrdAdd.SpecialInstruction));
            com.Parameters.AddWithValue("@Phone", commnfun.SafeDbObject(OrdAdd.Phone));
            com.Parameters.AddWithValue("@Phone1", commnfun.SafeDbObject(OrdAdd.Phone1));
            com.Parameters.AddWithValue("@Extension1", commnfun.SafeDbObject(OrdAdd.Extension1));
            com.Parameters.AddWithValue("@Extension2", commnfun.SafeDbObject(OrdAdd.Extension2));
            com.Parameters.AddWithValue("@PostalCode", commnfun.SafeDbObject(OrdAdd.PostalCode));
            com.Parameters.AddWithValue("@BranchName", commnfun.SafeDbObject(OrdAdd.BranchName));
            com.Parameters.AddWithValue("@ContactName", commnfun.SafeDbObject(OrdAdd.ContactName));
            com.Parameters.AddWithValue("@Department", commnfun.SafeDbObject(OrdAdd.Department));

            SqlParameter RuturnValue = new SqlParameter("@invoiceaddressid", SqlDbType.Int);
            RuturnValue.Direction = ParameterDirection.Output;
            com.Parameters.Add(RuturnValue);
            con.Open();
            int i = com.ExecuteNonQuery();
            var invoiceaddressid = (int)com.Parameters["@invoiceaddressid"].Value;
            con.Close();
            if (invoiceaddressid >= 0)
            {
                return invoiceaddressid;
            }
            else
            {
                return 0;
            }
        }


        public int AddOrderDeliveryAddress(OrderDeliveryAddress DelAdd, string dbParam)
        {
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            com = new SqlCommand("spInsertInvoiceDeliveryAddress", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@InvoiceId", commnfun.SafeDbObject(DelAdd.InvoiceId));
            com.Parameters.AddWithValue("@AddressType", commnfun.SafeDbObject(DelAdd.AddressType));
            com.Parameters.AddWithValue("@Address", commnfun.SafeDbObject(DelAdd.Address));
            com.Parameters.AddWithValue("@Address2", commnfun.SafeDbObject(DelAdd.Address2));
            com.Parameters.AddWithValue("@Address3", commnfun.SafeDbObject(DelAdd.Address3));
            com.Parameters.AddWithValue("@Address4", commnfun.SafeDbObject(DelAdd.Address4));
            com.Parameters.AddWithValue("@CountryId", commnfun.SafeDbObject(DelAdd.CountryId));
            com.Parameters.AddWithValue("@CityId", commnfun.SafeDbObject(DelAdd.CityId));
            com.Parameters.AddWithValue("@StateId", commnfun.SafeDbObject(DelAdd.StateId));
            com.Parameters.AddWithValue("@DistrictId", commnfun.SafeDbObject(DelAdd.DistrictId));
            com.Parameters.AddWithValue("@SpecialInstruction", commnfun.SafeDbObject(DelAdd.SpecialInstruction));
            com.Parameters.AddWithValue("@Phone", commnfun.SafeDbObject(DelAdd.Phone));
            com.Parameters.AddWithValue("@Phone1", commnfun.SafeDbObject(DelAdd.Phone1));
            com.Parameters.AddWithValue("@Extension1", commnfun.SafeDbObject(DelAdd.Extension1));
            com.Parameters.AddWithValue("@Extension2", commnfun.SafeDbObject(DelAdd.Extension2));
            com.Parameters.AddWithValue("@PostalCode", commnfun.SafeDbObject(DelAdd.PostalCode));
            com.Parameters.AddWithValue("@BranchName", commnfun.SafeDbObject(DelAdd.BranchName));
            com.Parameters.AddWithValue("@ContactName", commnfun.SafeDbObject(DelAdd.ContactName));
            com.Parameters.AddWithValue("@Department", commnfun.SafeDbObject(DelAdd.Department));

            SqlParameter RuturnValue = new SqlParameter("@invoiceDeliveryaddressid", SqlDbType.Int);
            RuturnValue.Direction = ParameterDirection.Output;
            com.Parameters.Add(RuturnValue);
            con.Open();
            int i = com.ExecuteNonQuery();
            var invoiceDeliveryaddressid = (int)com.Parameters["@invoiceDeliveryaddressid"].Value;
            con.Close();
            if (invoiceDeliveryaddressid >= 0)
            {
                return invoiceDeliveryaddressid;
            }
            else
            {
                return 0;
            }
        }


        public string SaveOrderSMS(OrderSms Ordsms, string dbParam)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            string query = "";

            query = "Insert into tblOrderSMS(OrderId,Mobile,SAddressType) Values('" + Ordsms.OrderId + "','" + Ordsms.SMSId + "','C');";



            using (SqlCommand command = new SqlCommand(query, con))
            {
                con.Open();
                var result = command.ExecuteScalar();
                //var Id = result.GetHashCode();
                if (result != null)
                {
                    return "Success";
                }
                else
                {

                    return "Fail";
                }
            }
        }



        public string SaveOrderEmail(OrderEmail Ordemail, string dbParam)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            string query = "";

            query = "Insert into tblOrderEmail(OrderId,OEmail,OAddressType) Values('" + Ordemail.OrderId + "','" + Ordemail.OEmail + "','D');";



            using (SqlCommand command = new SqlCommand(query, con))
            {
                con.Open();
                var result = command.ExecuteScalar();
                //var Id = result.GetHashCode();
                if (result != null)
                {
                    return "Success";
                }
                else
                {

                    return "Fail";
                }
            }
        }
        public string saveOrderMiscServiceReturn(MiscellaneousOrder OrdMiscel, string dbParam)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            string query = "";

            query = "Insert Into tblMiscellaneousOrder(MId,InvoiceId) Values(" + OrdMiscel.MId + "," + OrdMiscel.InvoiceId + "));";



            using (SqlCommand command = new SqlCommand(query, con))
            {
                con.Open();
                var result = command.ExecuteScalar();
                //var Id = result.GetHashCode();
                if (result != null)
                {
                    return "Success";
                }
                else
                {

                    return "Fail";
                }
            }
        }




        internal object AddEmployees(object emp)
        {
            throw new NotImplementedException();
        }
    }
}