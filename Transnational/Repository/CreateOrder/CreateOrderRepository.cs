using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Transnational.Common;
using Transnational.Models.Order;
using Transnational.Models.ServiceAndProduct;

namespace Transnational.Repository.CreateOrder
{
    public class CreateOrderRepository
    {
        private string finalOrderNo;
        private SqlCommand com;
        public int AddNewOrder(Orders OrderObj, OrderDeliveryAddress OrderDeliveryAddressObj, OrderAddress OrderAddressObj )
        {
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(OrderObj.CD);
            com = new SqlCommand("spInsertCreateNewOrder", con);
            con.Open();
            OrderObj.OrderNo = GenRatetOrderNo("CO", (int)OrderObj.CreatedBy, con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CompanyId", commnfun.SafeDbObject(OrderObj.CompanyId));
            com.Parameters.AddWithValue("@ContractId", commnfun.SafeDbObject(OrderObj.ContractId));
            com.Parameters.AddWithValue("@CBranchId", commnfun.SafeDbObject(OrderObj.CBranchId));
            com.Parameters.AddWithValue("@RequestorName", commnfun.SafeDbObject(OrderObj.RequestorName));
            com.Parameters.AddWithValue("@ContractCostCntrDprt", commnfun.SafeDbObject(OrderObj.ContractCostCntrDprt));
            com.Parameters.AddWithValue("@RequestorContact", commnfun.SafeDbObject(OrderObj.RequestorContact));
            com.Parameters.AddWithValue("@ServiceId", commnfun.SafeDbObject(OrderObj.ServiceId));
            com.Parameters.AddWithValue("@Quantity", commnfun.SafeDbObject(OrderObj.Quantity));
            com.Parameters.AddWithValue("@Volume1", commnfun.SafeDbObject(OrderObj.Volume1));
            com.Parameters.AddWithValue("@Volume2", commnfun.SafeDbObject(OrderObj.Volume2));
            com.Parameters.AddWithValue("@Volume3", commnfun.SafeDbObject(OrderObj.Volume3));
            com.Parameters.AddWithValue("@PickupDate", commnfun.SafeDbObject(OrderObj.PickupDate));
            com.Parameters.AddWithValue("@DeliveryDate", commnfun.SafeDbObject(OrderObj.DeliveryDate));
            com.Parameters.AddWithValue("@PickupTime", commnfun.SafeDbObject(OrderObj.PickupTime));
            com.Parameters.AddWithValue("@DeliveryTime", commnfun.SafeDbObject(OrderObj.DeliveryTime));
            com.Parameters.AddWithValue("@EstimatedCost", commnfun.SafeDbObject(OrderObj.EstimatedCost));
            com.Parameters.AddWithValue("@DeliveryOptionRate", commnfun.SafeDbObject(OrderObj.DeliveryOptionRate));
            com.Parameters.AddWithValue("@BillTo", commnfun.SafeDbObject(OrderObj.BillTo));
            com.Parameters.AddWithValue("@BillToVal", commnfun.SafeDbObject(OrderObj.BillToVal));
            com.Parameters.AddWithValue("@AlternateRefNo", commnfun.SafeDbObject(OrderObj.AlternateRefNo));
            com.Parameters.AddWithValue("@SpecialInstructions", commnfun.SafeDbObject(OrderObj.SpecialInstructions));
            com.Parameters.AddWithValue("@Oemail", commnfun.SafeDbObject(OrderObj.Oemail));
            com.Parameters.AddWithValue("@Omobile", commnfun.SafeDbObject(OrderObj.Omobile));
            com.Parameters.AddWithValue("@Weight", commnfun.SafeDbObject(OrderObj.Weight));
            com.Parameters.AddWithValue("@OWeightUOM", commnfun.SafeDbObject(OrderObj.OWeightUOM));
            com.Parameters.AddWithValue("@QuantityUomId", commnfun.SafeDbObject(OrderObj.QuantityUomId));
            com.Parameters.AddWithValue("@OVolumeUOM", commnfun.SafeDbObject(OrderObj.OVolumeUOM));
            com.Parameters.AddWithValue("@DeliveryOptionId", commnfun.SafeDbObject(OrderObj.DeliveryOptionId));
            com.Parameters.AddWithValue("@CreatedBy", commnfun.SafeDbObject(OrderObj.CreatedBy));
            com.Parameters.AddWithValue("@CreatedByType", commnfun.SafeDbObject(OrderObj.CreatedByType));
            com.Parameters.AddWithValue("@InvoiceType", commnfun.SafeDbObject(OrderObj.InvoiceType));
            com.Parameters.AddWithValue("@OrderNo", commnfun.SafeDbObject(OrderObj.OrderNo));
            com.Parameters.AddWithValue("@BillingEmail", commnfun.SafeDbObject(OrderObj.BillingEmail));
            com.Parameters.AddWithValue("@BillingAddress", commnfun.SafeDbObject(OrderObj.BillingAddress));
            com.Parameters.AddWithValue("@CouponCode", commnfun.SafeDbObject(OrderObj.CouponCode));
            com.Parameters.AddWithValue("@CouponAmount", commnfun.SafeDbObject(OrderObj.CouponAmount));
            com.Parameters.AddWithValue("@rtrnTrip", commnfun.SafeDbObject(OrderObj.rtrnTrip)); //
            
            SqlParameter RuturnValue = new SqlParameter("@InvoiceId", SqlDbType.Int);
            RuturnValue.Direction = ParameterDirection.Output;
            com.Parameters.Add(RuturnValue);
          
            int i = com.ExecuteNonQuery();
            var InvoiceId = (int)com.Parameters["@InvoiceId"].Value;
            // con.Close();
            if (InvoiceId >= 0)
            {
                OrderCollectionAddress(OrderAddressObj, InvoiceId, con);
                OrderDelleveryAddress(OrderDeliveryAddressObj, InvoiceId, con);
                if ( OrderObj.parentChild != "child")
                {
                    foreach (var InvoiceVolumeObj in OrderObj.InvoiceVolumeObjList)
                    {
                        AddOrderVolume(InvoiceVolumeObj, InvoiceId, OrderObj.CD, con);
                    }

                    foreach (var MyCartObj in OrderObj.AddtoMyCartObjList)
                    {
                        AddOrderMyCart(MyCartObj, InvoiceId, OrderObj.CD, con);
                    }
                    foreach (var item in OrderObj.OrderEmailObjList)
                    {
                        AddOrderEmail(item.OEmail, item.OAddressType, InvoiceId, OrderObj.CD, con);
                    }
                    foreach (var item in OrderObj.OrderSmsObjList)
                    {
                        AddOrderSms(item.Mobile, item.SAddressType, InvoiceId, OrderObj.CD, con);
                    }
                }
                con.Close();
                return InvoiceId;
            }
            else
            {
                con.Close();
                return 0;
            }

        }
        public int OrderCollectionAddress(OrderAddress OrderAddressObj, int InvoiceId, SqlConnection con)
        {

            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            //  var con = conobj.connection(OrderAddressObj.CD);
            com = new SqlCommand("spInsertCreateCollectionAddress", con);
            com.CommandType = CommandType.StoredProcedure;
            //---------------------------//-----------------------------///////----------------------------
            com.Parameters.AddWithValue("@CollectionNRICno", commnfun.SafeDbObject(OrderAddressObj.CollectionNRICno));
            com.Parameters.AddWithValue("@BranchName", commnfun.SafeDbObject(OrderAddressObj.BranchName));
            com.Parameters.AddWithValue("@PostalCode", commnfun.SafeDbObject(OrderAddressObj.PostalCode));
            com.Parameters.AddWithValue("@Address", commnfun.SafeDbObject(OrderAddressObj.Address));
            com.Parameters.AddWithValue("@Address2", commnfun.SafeDbObject(OrderAddressObj.Address2));
            com.Parameters.AddWithValue("@Address3", commnfun.SafeDbObject(OrderAddressObj.Address3));
            com.Parameters.AddWithValue("@Address4", commnfun.SafeDbObject(OrderAddressObj.Address4));
            com.Parameters.AddWithValue("@CountryId", commnfun.SafeDbObject(OrderAddressObj.CountryId));
            com.Parameters.AddWithValue("@StateId", commnfun.SafeDbObject(OrderAddressObj.StateId));
            com.Parameters.AddWithValue("@DistrictId", commnfun.SafeDbObject(OrderAddressObj.DistrictId));
            com.Parameters.AddWithValue("@CityId", commnfun.SafeDbObject(OrderAddressObj.CityId));
            com.Parameters.AddWithValue("@lat", commnfun.SafeDbObject(OrderAddressObj.lat));
            com.Parameters.AddWithValue("@lon", commnfun.SafeDbObject(OrderAddressObj.lon));
            com.Parameters.AddWithValue("@ContactName", commnfun.SafeDbObject(OrderAddressObj.ContactName));
            com.Parameters.AddWithValue("@Department", commnfun.SafeDbObject(OrderAddressObj.Department));
            com.Parameters.AddWithValue("@Phone", commnfun.SafeDbObject(OrderAddressObj.Phone));
            com.Parameters.AddWithValue("@Phone1", commnfun.SafeDbObject(OrderAddressObj.Phone1));
            com.Parameters.AddWithValue("@Extension1", commnfun.SafeDbObject(OrderAddressObj.Extension1));
            com.Parameters.AddWithValue("@Extension2", commnfun.SafeDbObject(OrderAddressObj.Extension2));
            com.Parameters.AddWithValue("@SpecialInstruction", commnfun.SafeDbObject(OrderAddressObj.SpecialInstruction));
            com.Parameters.AddWithValue("@InvoiceId", InvoiceId);
            com.Parameters.AddWithValue("@AddressType", commnfun.SafeDbObject(OrderAddressObj.AddressType));
            SqlParameter RuturnValue = new SqlParameter("@InvoiceAddressId", SqlDbType.Int);
            RuturnValue.Direction = ParameterDirection.Output;
            com.Parameters.Add(RuturnValue);
            // con.Open();
            int i = com.ExecuteNonQuery();
            var InvoiceAddressId = (int)com.Parameters["@InvoiceAddressId"].Value;
            //  con.Close();
            if (InvoiceAddressId >= 0)
            {

                return InvoiceAddressId;
            }
            else
            {
                return 0;
            }
        }
        public int OrderDelleveryAddress(OrderDeliveryAddress OrderDeliveryAddressObj, int InvoiceId, SqlConnection con)
        {
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            // var con = conobj.connection(OrderDeliveryAddressObj.CD);
            com = new SqlCommand("spInsertCreateInvoiceDeliveryAddress", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DeliveryNRICno", commnfun.SafeDbObject(OrderDeliveryAddressObj.DeliveryNRICno));
            com.Parameters.AddWithValue("@BranchName", commnfun.SafeDbObject(OrderDeliveryAddressObj.BranchName));
            com.Parameters.AddWithValue("@PostalCode", commnfun.SafeDbObject(OrderDeliveryAddressObj.PostalCode));
            com.Parameters.AddWithValue("@Address", commnfun.SafeDbObject(OrderDeliveryAddressObj.Address));
            com.Parameters.AddWithValue("@Address2", commnfun.SafeDbObject(OrderDeliveryAddressObj.Address2));
            com.Parameters.AddWithValue("@Address3", commnfun.SafeDbObject(OrderDeliveryAddressObj.Address3));
            com.Parameters.AddWithValue("@Address4", commnfun.SafeDbObject(OrderDeliveryAddressObj.Address4));
            com.Parameters.AddWithValue("@CountryId", commnfun.SafeDbObject(OrderDeliveryAddressObj.CountryId));
            com.Parameters.AddWithValue("@StateId", commnfun.SafeDbObject(OrderDeliveryAddressObj.StateId));
            com.Parameters.AddWithValue("@DistrictId", commnfun.SafeDbObject(OrderDeliveryAddressObj.DistrictId));
            com.Parameters.AddWithValue("@CityId", commnfun.SafeDbObject(OrderDeliveryAddressObj.CityId));
            com.Parameters.AddWithValue("@Dlat", commnfun.SafeDbObject(OrderDeliveryAddressObj.Dlat));
            com.Parameters.AddWithValue("@Dlon", commnfun.SafeDbObject(OrderDeliveryAddressObj.Dlon));
            com.Parameters.AddWithValue("@ContactName", commnfun.SafeDbObject(OrderDeliveryAddressObj.ContactName));
            com.Parameters.AddWithValue("@Department", commnfun.SafeDbObject(OrderDeliveryAddressObj.Department));
            com.Parameters.AddWithValue("@Phone", commnfun.SafeDbObject(OrderDeliveryAddressObj.Phone));
            com.Parameters.AddWithValue("@Phone1", commnfun.SafeDbObject(OrderDeliveryAddressObj.Phone1));
            com.Parameters.AddWithValue("@Extension1", commnfun.SafeDbObject(OrderDeliveryAddressObj.Extension1));
            com.Parameters.AddWithValue("@Extension2", commnfun.SafeDbObject(OrderDeliveryAddressObj.Extension2));
            com.Parameters.AddWithValue("@SpecialInstruction", commnfun.SafeDbObject(OrderDeliveryAddressObj.SpecialInstruction));
            com.Parameters.AddWithValue("@InvoiceId", InvoiceId);
            com.Parameters.AddWithValue("@AddressType", commnfun.SafeDbObject(OrderDeliveryAddressObj.AddressType));


            SqlParameter RuturnValue = new SqlParameter("@InvoiceDeliveryAddressId", SqlDbType.Int);
            RuturnValue.Direction = ParameterDirection.Output;
            com.Parameters.Add(RuturnValue);
            // con.Open();
            int i = com.ExecuteNonQuery();
            var InvoiceDeliveryAddressId = (int)com.Parameters["@InvoiceDeliveryAddressId"].Value;
            // con.Close();
            if (InvoiceDeliveryAddressId >= 0)
            {
                return InvoiceDeliveryAddressId;
            }
            else
            {
                return 0;
            }
        }


        public int OrderCollectionAddress_return(OrderDeliveryAddress OrderAddressObj, int InvoiceId, SqlConnection con)
        {

            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            //  var con = conobj.connection(OrderAddressObj.CD);
            com = new SqlCommand("spInsertCreateCollectionAddress", con);
            com.CommandType = CommandType.StoredProcedure;
            //---------------------------//-----------------------------///////----------------------------
            com.Parameters.AddWithValue("@CollectionNRICno", commnfun.SafeDbObject(OrderAddressObj.DeliveryNRICno));
            com.Parameters.AddWithValue("@BranchName", commnfun.SafeDbObject(OrderAddressObj.BranchName));
            com.Parameters.AddWithValue("@PostalCode", commnfun.SafeDbObject(OrderAddressObj.PostalCode));
            com.Parameters.AddWithValue("@Address", commnfun.SafeDbObject(OrderAddressObj.Address));
            com.Parameters.AddWithValue("@Address2", commnfun.SafeDbObject(OrderAddressObj.Address2));
            com.Parameters.AddWithValue("@Address3", commnfun.SafeDbObject(OrderAddressObj.Address3));
            com.Parameters.AddWithValue("@Address4", commnfun.SafeDbObject(OrderAddressObj.Address4));
            com.Parameters.AddWithValue("@CountryId", commnfun.SafeDbObject(OrderAddressObj.CountryId));
            com.Parameters.AddWithValue("@StateId", commnfun.SafeDbObject(OrderAddressObj.StateId));
            com.Parameters.AddWithValue("@DistrictId", commnfun.SafeDbObject(OrderAddressObj.DistrictId));
            com.Parameters.AddWithValue("@CityId", commnfun.SafeDbObject(OrderAddressObj.CityId));
            com.Parameters.AddWithValue("@lat", commnfun.SafeDbObject(OrderAddressObj.Dlat));
            com.Parameters.AddWithValue("@lon", commnfun.SafeDbObject(OrderAddressObj.Dlon));
            com.Parameters.AddWithValue("@ContactName", commnfun.SafeDbObject(OrderAddressObj.ContactName));
            com.Parameters.AddWithValue("@Department", commnfun.SafeDbObject(OrderAddressObj.Department));
            com.Parameters.AddWithValue("@Phone", commnfun.SafeDbObject(OrderAddressObj.Phone));
            com.Parameters.AddWithValue("@Phone1", commnfun.SafeDbObject(OrderAddressObj.Phone1));
            com.Parameters.AddWithValue("@Extension1", commnfun.SafeDbObject(OrderAddressObj.Extension1));
            com.Parameters.AddWithValue("@Extension2", commnfun.SafeDbObject(OrderAddressObj.Extension2));
            com.Parameters.AddWithValue("@SpecialInstruction", commnfun.SafeDbObject(OrderAddressObj.SpecialInstruction));
            com.Parameters.AddWithValue("@InvoiceId", InvoiceId);
            com.Parameters.AddWithValue("@AddressType", commnfun.SafeDbObject(OrderAddressObj.AddressType));
            SqlParameter RuturnValue = new SqlParameter("@InvoiceAddressId", SqlDbType.Int);
            RuturnValue.Direction = ParameterDirection.Output;
            com.Parameters.Add(RuturnValue);
            // con.Open();
            int i = com.ExecuteNonQuery();
            var InvoiceAddressId = (int)com.Parameters["@InvoiceAddressId"].Value;
            //  con.Close();
            if (InvoiceAddressId >= 0)
            {

                return InvoiceAddressId;
            }
            else
            {
                return 0;
            }
        }
        public int OrderDelleveryAddress_return(OrderAddress OrderDeliveryAddressObj, int InvoiceId, SqlConnection con)
        {
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            // var con = conobj.connection(OrderDeliveryAddressObj.CD);
            com = new SqlCommand("spInsertCreateInvoiceDeliveryAddress", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DeliveryNRICno", commnfun.SafeDbObject(OrderDeliveryAddressObj.CollectionNRICno));
            com.Parameters.AddWithValue("@BranchName", commnfun.SafeDbObject(OrderDeliveryAddressObj.BranchName));
            com.Parameters.AddWithValue("@PostalCode", commnfun.SafeDbObject(OrderDeliveryAddressObj.PostalCode));
            com.Parameters.AddWithValue("@Address", commnfun.SafeDbObject(OrderDeliveryAddressObj.Address));
            com.Parameters.AddWithValue("@Address2", commnfun.SafeDbObject(OrderDeliveryAddressObj.Address2));
            com.Parameters.AddWithValue("@Address3", commnfun.SafeDbObject(OrderDeliveryAddressObj.Address3));
            com.Parameters.AddWithValue("@Address4", commnfun.SafeDbObject(OrderDeliveryAddressObj.Address4));
            com.Parameters.AddWithValue("@CountryId", commnfun.SafeDbObject(OrderDeliveryAddressObj.CountryId));
            com.Parameters.AddWithValue("@StateId", commnfun.SafeDbObject(OrderDeliveryAddressObj.StateId));
            com.Parameters.AddWithValue("@DistrictId", commnfun.SafeDbObject(OrderDeliveryAddressObj.DistrictId));
            com.Parameters.AddWithValue("@CityId", commnfun.SafeDbObject(OrderDeliveryAddressObj.CityId));
            com.Parameters.AddWithValue("@Dlat", commnfun.SafeDbObject(OrderDeliveryAddressObj.lat));
            com.Parameters.AddWithValue("@Dlon", commnfun.SafeDbObject(OrderDeliveryAddressObj.lon));
            com.Parameters.AddWithValue("@ContactName", commnfun.SafeDbObject(OrderDeliveryAddressObj.ContactName));
            com.Parameters.AddWithValue("@Department", commnfun.SafeDbObject(OrderDeliveryAddressObj.Department));
            com.Parameters.AddWithValue("@Phone", commnfun.SafeDbObject(OrderDeliveryAddressObj.Phone));
            com.Parameters.AddWithValue("@Phone1", commnfun.SafeDbObject(OrderDeliveryAddressObj.Phone1));
            com.Parameters.AddWithValue("@Extension1", commnfun.SafeDbObject(OrderDeliveryAddressObj.Extension1));
            com.Parameters.AddWithValue("@Extension2", commnfun.SafeDbObject(OrderDeliveryAddressObj.Extension2));
            com.Parameters.AddWithValue("@SpecialInstruction", commnfun.SafeDbObject(OrderDeliveryAddressObj.SpecialInstruction));
            com.Parameters.AddWithValue("@InvoiceId", InvoiceId);
            com.Parameters.AddWithValue("@AddressType", commnfun.SafeDbObject(OrderDeliveryAddressObj.AddressType));


            SqlParameter RuturnValue = new SqlParameter("@InvoiceDeliveryAddressId", SqlDbType.Int);
            RuturnValue.Direction = ParameterDirection.Output;
            com.Parameters.Add(RuturnValue);
            // con.Open();
            int i = com.ExecuteNonQuery();
            var InvoiceDeliveryAddressId = (int)com.Parameters["@InvoiceDeliveryAddressId"].Value;
            // con.Close();
            if (InvoiceDeliveryAddressId >= 0)
            {
                return InvoiceDeliveryAddressId;
            }
            else
            {
                return 0;
            }
        }

        public int AddOrderVolume(InvoiceVolume InvoiceVolumeObj, int InvoiceId, string CD, SqlConnection con)
        {
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            //  var con = conobj.connection(CD);
            com = new SqlCommand("[spInsertOrderVolume]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@InvoiceId", commnfun.SafeDbObject(InvoiceId));
            com.Parameters.AddWithValue("@Quantity", commnfun.SafeDbObject(InvoiceVolumeObj.Quantity));
            com.Parameters.AddWithValue("@QuantityUomId", commnfun.SafeDbObject(InvoiceVolumeObj.QuantityUomId));
            com.Parameters.AddWithValue("@Weight", commnfun.SafeDbObject(InvoiceVolumeObj.Weight));
            com.Parameters.AddWithValue("@OWeightUOM", commnfun.SafeDbObject(InvoiceVolumeObj.OWeightUOM));
            com.Parameters.AddWithValue("@Volume1", commnfun.SafeDbObject(InvoiceVolumeObj.Volume1));
            com.Parameters.AddWithValue("@Volume2", commnfun.SafeDbObject(InvoiceVolumeObj.Volume2));
            com.Parameters.AddWithValue("@Volume3", commnfun.SafeDbObject(InvoiceVolumeObj.Volume3));
            com.Parameters.AddWithValue("@OVolumeUOM", commnfun.SafeDbObject(InvoiceVolumeObj.OVolumeUOM));
            com.Parameters.AddWithValue("@VolumeType", commnfun.SafeDbObject(InvoiceVolumeObj.VolumeType));
            SqlParameter RuturnValue = new SqlParameter("@InvoiceVolumeId", SqlDbType.Int);
            RuturnValue.Direction = ParameterDirection.Output;
            com.Parameters.Add(RuturnValue);
            //con.Open();
            int i = com.ExecuteNonQuery();
            var InvoiceVolumeId = (int)com.Parameters["@InvoiceVolumeId"].Value;
            // con.Close();
            return InvoiceVolumeId;
        }


        public int AddNewOrder_Return(Orders OrderObj, OrderDeliveryAddress OrderDeliveryAddressObj, OrderAddress OrderAddressObj, int InvoiceId_parent)
        {
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(OrderObj.CD);
            com = new SqlCommand("spInsertCreateNewOrder", con);
            con.Open();
            OrderObj.OrderNo = GenRatetOrderNo("CO", (int)OrderObj.CreatedBy, con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CompanyId", commnfun.SafeDbObject(OrderObj.CompanyId));
            com.Parameters.AddWithValue("@ContractId", commnfun.SafeDbObject(OrderObj.ContractId));
            com.Parameters.AddWithValue("@CBranchId", commnfun.SafeDbObject(OrderObj.CBranchId));
            com.Parameters.AddWithValue("@RequestorName", commnfun.SafeDbObject(OrderObj.RequestorName));
            com.Parameters.AddWithValue("@ContractCostCntrDprt", commnfun.SafeDbObject(OrderObj.ContractCostCntrDprt));
            com.Parameters.AddWithValue("@RequestorContact", commnfun.SafeDbObject(OrderObj.RequestorContact));
            com.Parameters.AddWithValue("@ServiceId", commnfun.SafeDbObject(OrderObj.ServiceId_Return));
            com.Parameters.AddWithValue("@Quantity", commnfun.SafeDbObject(OrderObj.Quantity));
            com.Parameters.AddWithValue("@Volume1", commnfun.SafeDbObject(OrderObj.Volume1));
            com.Parameters.AddWithValue("@Volume2", commnfun.SafeDbObject(OrderObj.Volume2));
            com.Parameters.AddWithValue("@Volume3", commnfun.SafeDbObject(OrderObj.Volume3));
            com.Parameters.AddWithValue("@PickupDate", commnfun.SafeDbObject(OrderObj.PickupDate_Return));
            com.Parameters.AddWithValue("@DeliveryDate", commnfun.SafeDbObject(OrderObj.DeliveryDate_Return));
            com.Parameters.AddWithValue("@PickupTime", commnfun.SafeDbObject(OrderObj.PickupTime_Return));
            com.Parameters.AddWithValue("@DeliveryTime", commnfun.SafeDbObject(OrderObj.DeliveryTime_Return));
            com.Parameters.AddWithValue("@EstimatedCost", commnfun.SafeDbObject(OrderObj.EstimatedCost));
            com.Parameters.AddWithValue("@DeliveryOptionRate", commnfun.SafeDbObject(OrderObj.DeliveryOptionRate));
            com.Parameters.AddWithValue("@BillTo", commnfun.SafeDbObject(OrderObj.BillTo));
            com.Parameters.AddWithValue("@BillToVal", commnfun.SafeDbObject(OrderObj.BillToVal));
            com.Parameters.AddWithValue("@AlternateRefNo", commnfun.SafeDbObject(OrderObj.AlternateRefNo));
            com.Parameters.AddWithValue("@SpecialInstructions", commnfun.SafeDbObject(OrderObj.SpecialInstructions));
            com.Parameters.AddWithValue("@Oemail", commnfun.SafeDbObject(OrderObj.Oemail));
            com.Parameters.AddWithValue("@Omobile", commnfun.SafeDbObject(OrderObj.Omobile));
            com.Parameters.AddWithValue("@Weight", commnfun.SafeDbObject(OrderObj.Weight));
            com.Parameters.AddWithValue("@OWeightUOM", commnfun.SafeDbObject(OrderObj.OWeightUOM));
            com.Parameters.AddWithValue("@QuantityUomId", commnfun.SafeDbObject(OrderObj.QuantityUomId));
            com.Parameters.AddWithValue("@OVolumeUOM", commnfun.SafeDbObject(OrderObj.OVolumeUOM));
            com.Parameters.AddWithValue("@DeliveryOptionId", commnfun.SafeDbObject(OrderObj.DeliveryOptionId));
            com.Parameters.AddWithValue("@CreatedBy", commnfun.SafeDbObject(OrderObj.CreatedBy));
            com.Parameters.AddWithValue("@CreatedByType", commnfun.SafeDbObject(OrderObj.CreatedByType));
            com.Parameters.AddWithValue("@InvoiceType", commnfun.SafeDbObject(OrderObj.InvoiceType));
            com.Parameters.AddWithValue("@OrderNo", commnfun.SafeDbObject(OrderObj.OrderNo));
            com.Parameters.AddWithValue("@BillingEmail", commnfun.SafeDbObject(OrderObj.BillingEmail));
            com.Parameters.AddWithValue("@BillingAddress", commnfun.SafeDbObject(OrderObj.BillingAddress));
            com.Parameters.AddWithValue("@CouponCode", commnfun.SafeDbObject(OrderObj.CouponCode));
            com.Parameters.AddWithValue("@CouponAmount", commnfun.SafeDbObject(OrderObj.CouponAmount));
            SqlParameter RuturnValue = new SqlParameter("@InvoiceId", SqlDbType.Int);
            RuturnValue.Direction = ParameterDirection.Output;
            com.Parameters.Add(RuturnValue);

            int i = com.ExecuteNonQuery();
            var InvoiceId = (int)com.Parameters["@InvoiceId"].Value;
            // con.Close();
            if (InvoiceId >= 0)
            {
                OrderCollectionAddress_return(OrderDeliveryAddressObj, InvoiceId, con);
                OrderDelleveryAddress_return(OrderAddressObj, InvoiceId, con);
                UpdateReturnOrderToParen(InvoiceId_parent, InvoiceId, OrderObj.CD, con );
                con.Close();

                return InvoiceId;
            }
            else
            {
                con.Close();
                return 0;
            }

        }

        public int UpdateReturnOrderToParen(int InvoiceId, int ReturnOrderId, string CD, SqlConnection con)
        {
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            //  var con = conobj.connection(CD);
            com = new SqlCommand("spUpdateReturnOrderToParent", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@InvoiceId", commnfun.SafeDbObject(InvoiceId));
            com.Parameters.AddWithValue("@ReturnOrderId", commnfun.SafeDbObject(ReturnOrderId));
            //  con.Open();
            int i = com.ExecuteNonQuery();
            //  con.Close();
            return 1;
        }


        public int AddOrderMyCart(AddtoMyCart AddtoMyCartObj, int InvoiceId, string CD, SqlConnection con)
        {
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            //  var con = conobj.connection(CD);
            com = new SqlCommand("spUpdateOrderMyCart", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@InvoiceId", commnfun.SafeDbObject(InvoiceId));
            com.Parameters.AddWithValue("@CartId", commnfun.SafeDbObject(AddtoMyCartObj.CartId));
            com.Parameters.AddWithValue("@Qty", commnfun.SafeDbObject(AddtoMyCartObj.Qty));
            com.Parameters.AddWithValue("@Rate", commnfun.SafeDbObject(AddtoMyCartObj.Rate));
            com.Parameters.AddWithValue("@Status", commnfun.SafeDbObject(AddtoMyCartObj.Status));
            //  con.Open();
            int i = com.ExecuteNonQuery();
            //  con.Close();
            return 1;
        }
        public int AddOrderEmail(string OEmail, string OAddressType, int InvoiceId, string CD, SqlConnection con)
        {
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            // var con = conobj.connection(CD);
            com = new SqlCommand("[spInsertOrderEmail]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@OEmail", commnfun.SafeDbObject(OEmail));
            com.Parameters.AddWithValue("@OAddressType", commnfun.SafeDbObject(OAddressType));
            com.Parameters.AddWithValue("@OrderId", commnfun.SafeDbObject(InvoiceId));
            SqlParameter RuturnValue = new SqlParameter("@OEmailId", SqlDbType.Int);
            RuturnValue.Direction = ParameterDirection.Output;
            com.Parameters.Add(RuturnValue);
            // con.Open();
            int i = com.ExecuteNonQuery();
            var OEmailId = (int)com.Parameters["@OEmailId"].Value;
            //  con.Close();
            if (OEmailId >= 0)
            {
                return OEmailId;
            }
            else
            {
                return 0;
            }
        }
        public int AddOrderSms(string Mobile, string SAddressType, int InvoiceId, string CD, SqlConnection con)
        {
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            // var con = conobj.connection(CD);
            com = new SqlCommand("spInsertOrderSMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Mobile", Mobile);
            com.Parameters.AddWithValue("@SAddressType", SAddressType);
            com.Parameters.AddWithValue("@OrderId", InvoiceId);
            SqlParameter RuturnValue = new SqlParameter("@SMSId", SqlDbType.Int);
            RuturnValue.Direction = ParameterDirection.Output;
            com.Parameters.Add(RuturnValue);
            //  con.Open();
            int i = com.ExecuteNonQuery();
            var SMSId = (int)com.Parameters["@SMSId"].Value;
            //  con.Close();
            if (SMSId >= 0)
            {
                return SMSId;
            }
            else
            {
                return 0;
            }
        }


        //---------------------------------------OrderNoObj---------------------------------------------------//
        public string GenRatetOrderNo( string LoginType  ,int CreatedById, SqlConnection con)

        {
         
            string LastOrderNo, str, str2, str4;
            int CountCurrentMonthOrder = 0;
            try
            {

                string InitialString;


                if (LoginType == "CO")
                    InitialString = " select Initial + cast(RIGHT(YEAR(getdate()), 2)  as varchar) + cast(RIGHT('0' + RTRIM(MONTH(GETDATE ())), 2) as varchar) from tblBranch,tblContacts,tblCompany where tblBranch.BranchId=tblCompany.BusinessUnitId and tblCompany.CompanyId = tblContacts.CompanyId and tblContacts.ContactId= " + CreatedById + " and tblBranch.LanguageId = 1";
                else
                    InitialString = " select Initial + cast(RIGHT(YEAR(getdate()), 2)  as varchar) + cast(RIGHT('0' + RTRIM(MONTH(GETDATE ())), 2) as varchar) from tblBranch,tblUser where tblBranch.BranchId=tblUser.BranchId and tblUser.UserId= " + CreatedById + " and tblBranch.LanguageId = 1";
                
                using (SqlCommand command = new SqlCommand(InitialString, con))
                {
                    string value = (string)command.ExecuteScalar();
                    finalOrderNo = value;

                }


                bool passFound;
                passFound = false;
                int Count = 0;
                while (passFound == false)
                {
                    Count = Count + 1;
                    string localOrderNo; int OrderNo;
                    localOrderNo = "";

                    string sqlString = " select  top 1  OrderNo from tblInvoiceHeader where InvoiceId in";
                    sqlString += " (select max(InvoiceId) from tblInvoiceHeader ";
                    sqlString += " where Convert(Datetime,tblInvoiceHeader.CreatedDate,101) >=Convert(Datetime,(SELECT DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)),101) AND Convert(Datetime,tblInvoiceHeader.CreatedDate,101) <= Convert(Datetime,(Convert(NVarchar(11),(Select DATEADD (dd, -1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0))),101)+' 23:59:59.000'),101))";
                    SqlCommand command = new SqlCommand(sqlString, con);
                    LastOrderNo = (string)command.ExecuteScalar().ToString();



                    string sqlStringC = " select Count(InvoiceId) as total from tblInvoiceHeader where InvoiceId in";
                    sqlStringC += " (select max(InvoiceId) from tblInvoiceHeader ";
                    sqlStringC += " where Convert(Datetime,tblInvoiceHeader.CreatedDate,101) >=Convert(Datetime,(SELECT DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)),101) AND Convert(Datetime,tblInvoiceHeader.CreatedDate,101) <= Convert(Datetime,(Convert(NVarchar(11),(Select DATEADD (dd, -1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0))),101)+' 23:59:59.000'),101))";
                    SqlCommand command1 = new SqlCommand(sqlStringC, con);
                    CountCurrentMonthOrder = (int)command1.ExecuteScalar();

                    if (CountCurrentMonthOrder > 0)
                    {

                        if (LastOrderNo.ToString().Length == 12)
                        {
                            str = ("select reverse ( substring ( reverse (  cast('" + Convert.ToInt64(LastOrderNo) + "' as varchar(100))  ) , 1 , 6 ) )");
                            SqlCommand command2 = new SqlCommand(str, con);

                            string value2 = (String)command2.ExecuteScalar();
                            OrderNo = Int16.Parse(value2);

                            OrderNo = OrderNo + 1;
                            str2 = (" select REPLICATE('0',6-LEN(RTRIM(cast('" + Convert.ToInt64(OrderNo) + "' as varchar(100))))) + RTRIM(cast('" + Convert.ToInt64(OrderNo) + "' as varchar(100)))");

                            SqlCommand command3 = new SqlCommand(str2, con);

                            String value3 = (String)command3.ExecuteScalar().ToString();
                            localOrderNo = value3;

                        }

                        else
                            finalOrderNo = "error";
                    }
                    else
                    {
                        OrderNo = 1;
                        str2 = (" select REPLICATE('0',6-LEN(RTRIM(cast('" + Convert.ToInt64(OrderNo) + "' as varchar(100))))) + RTRIM(cast('" + Convert.ToInt64(OrderNo) + "' as varchar(100)))");
                        SqlCommand command4 = new SqlCommand(str2, con);

                        localOrderNo = (String)command4.ExecuteScalar().ToString();

                    }



                    if (finalOrderNo == "error")
                        break;
                    else
                    {

                        //---- checking availability
                        str4 = "select count(InvoiceId)  from tblInvoiceHeader where OrderNo = '" + finalOrderNo + localOrderNo + "'";
                        SqlCommand command5 = new SqlCommand(str4, con);
                        int value5 = (int)command5.ExecuteScalar();
                        if (value5 > 0)
                            passFound = false;
                        else
                            passFound = true;
                        //---- END checking availability  

                        if (passFound == true)
                        {
                            finalOrderNo = finalOrderNo + localOrderNo;
                            break;
                        }

                    }
                    if (Count == 4)
                        break;
                } // while 
                
                return finalOrderNo;

            } // try 

            catch (Exception ex)
            {
                return finalOrderNo;
            }


        } //END GenRatetOrderNo

        //---------------------------GetAllOrdersFilter------------------------------------//
        public DataSet GetAllOrders(AllOrdersConduction AllOrdersConductionObj, String Status)
        {

            DataSet ds = new DataSet();

            CommonFuns commnfun = new CommonFuns();

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(AllOrdersConductionObj.CD);
            SqlCommand com = new SqlCommand("spGetAllOrder", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CreatedBy", AllOrdersConductionObj.CreatedBy);
            com.Parameters.AddWithValue("@CreatedByType", AllOrdersConductionObj.CreatedByType);
            com.Parameters.AddWithValue("@RecentOrder", AllOrdersConductionObj.RecentOrder);
            com.Parameters.AddWithValue("@Status", Status);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        //---------------------------GetAllOrdersFilter End------------------------------------//

        public DataTable GetOrderByOrderId(GetOrderByOrderId GetOrderByOrderIdObj)
        {
            DataSet ds = new DataSet();
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(GetOrderByOrderIdObj.CD);
            //DataSet ds = new DataSet();
            //DataSet tblds = new DataSet();
            DataTable dt = new DataTable("DataTable");
            dt.Columns.Add(new DataColumn("Order", typeof(DataSet)));
            dt.Columns.Add(new DataColumn("OrderValume", typeof(DataSet)));
            dt.Columns.Add(new DataColumn("OrderProduct", typeof(DataSet)));

            SqlCommand com = new SqlCommand("[spGetOrderByOrderId]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@InvoiceId", GetOrderByOrderIdObj.InvoiceId);
            //com.Parameters.AddWithValue("@CreatedByType", AllOrdersConductionObj.CreatedByType);

            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Order"] = ds;
                    dr["OrderValume"] = GetOrderVolumeByOrderId(GetOrderByOrderIdObj.CD, (int)GetOrderByOrderIdObj.InvoiceId);
                    dr["OrderProduct"] = GetMyCartByInvoiceId(GetOrderByOrderIdObj.CD, (int)GetOrderByOrderIdObj.InvoiceId);


                    dt.Rows.Add(dr);
                    // ds.Tables.Add(dt);
                    con.Close();
                    return dt;
                }
                con.Close();
                return null;

            }
        }
        public DataSet GetOrderVolumeByOrderId(String CD, int InvoiceId)
        {
            DataSet ds = new DataSet();

            CommonFuns commnfun = new CommonFuns();

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(CD);
            SqlCommand com = new SqlCommand("[spGetOrderVolumeByOrderId]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@InvoiceId", InvoiceId);
            //com.Parameters.AddWithValue("@CreatedByType", AllOrdersConductionObj.CreatedByType);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);


                con.Close();
            }
            return ds;
        }
        public DataSet GetMyCartByInvoiceId(String CD, int InvoiceId)
        {
            DataSet ds = new DataSet();

            CommonFuns commnfun = new CommonFuns();

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(CD);
            SqlCommand com = new SqlCommand("spGetMyCartByInvoiceId", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@InvoiceId", InvoiceId);
            com.Parameters.AddWithValue("@LanguageId", 1);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                con.Open();
                da.Fill(ds);


                con.Close();
            }
            return ds;
        }

        //--------------------------------------CancelledOrder API-----------------------------------------------//

        public int UpdateInvoiceStatus(UpdateInvoiceStatus UpdateInvoiceStatusObj)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(UpdateInvoiceStatusObj.CD);
            SqlCommand com = new SqlCommand("spUpdateInvoiceStatus", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CancelledById", UpdateInvoiceStatusObj.CancelledById);
            com.Parameters.AddWithValue("@CancelledByType", UpdateInvoiceStatusObj.CancelledByType);
            com.Parameters.AddWithValue("@RequestFrom ", UpdateInvoiceStatusObj.RequestFrom);
            com.Parameters.AddWithValue("@Status", UpdateInvoiceStatusObj.Status);
            com.Parameters.AddWithValue("@InvoiceId", UpdateInvoiceStatusObj.InvoiceId);

            {

                con.Open();
                var result = com.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }


            }
        }
        //-----------------------------------InsertOrderProductRating-------------------------------------------//--
        public int InsertOrderProductRating(OrderProductRating OrderProductRatingObj)
        {

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(OrderProductRatingObj.CD);
            SqlCommand com = new SqlCommand("spInsertOrderProductRating", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CartId", OrderProductRatingObj.CartId);
            com.Parameters.AddWithValue("@RatingUserId", OrderProductRatingObj.RatingUserId);
            com.Parameters.AddWithValue("@Feedback ", OrderProductRatingObj.Feedback);
            com.Parameters.AddWithValue("@Rating", OrderProductRatingObj.Rating);
            {
                con.Open();
                var result = com.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }


            }
        }
        //---------------------------------------//GetOrderProductByInoviceId//-------------------------------------//
        public DataSet GetOrderProductByInoviceId(OrderProductConduction OrderProductConductionObj)
        {
            DataSet ds = new DataSet();

            CommonFuns commnfun = new CommonFuns();

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(OrderProductConductionObj.CD);
            SqlCommand com = new SqlCommand("spGetMyCartByInvoiceId", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@InvoiceId", OrderProductConductionObj.InvoiceId);
            com.Parameters.AddWithValue("@LanguageId", 1);
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        //----------------------------------GetOrderStatusByOrderId------------------------------------------------//-----------


        public DataSet GetOrderStatusByOrderId(TrackOrderStatus TrackOrderStatusObj)
        {
            DataSet ds = new DataSet();

            CommonFuns commnfun = new CommonFuns();

            DbConnections conobj = new DbConnections();
            var con = conobj.connection(TrackOrderStatusObj.CD);
            SqlCommand com = new SqlCommand("spGetOrderStatusByOrderId", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@OrderId", TrackOrderStatusObj.InvoiceId);
            
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {

                con.Open();
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        public DataTable GetOrderVolumeDetels(OrderVolumeDetels OrderVolumeDetelsObj)
        {

            DataSet ds = new DataSet();
            CommonFuns commnfun = new CommonFuns();
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(OrderVolumeDetelsObj.CD);
            DataTable dt = new DataTable("DataTable");
            dt.Columns.Add(new DataColumn("Weight", typeof(string)));
            dt.Columns.Add(new DataColumn("Length", typeof(string)));
            dt.Columns.Add(new DataColumn("Width", typeof(string)));
            dt.Columns.Add(new DataColumn("Height", typeof(string)));
            dt.Columns.Add(new DataColumn("Type", typeof(string)));
            dt.Columns.Add(new DataColumn("WeightUOM", typeof(string)));
            dt.Columns.Add(new DataColumn("VolumeUOM", typeof(string)));
  

            SqlCommand com = new SqlCommand("[spGetOrderVolumeDetails]", con);
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
                        dr["Weight"] = drSq["Weight"];
                        dr["Length"] = drSq["Length"];
                        dr["Width"] = drSq["Width"];
                        dr["Height"] = drSq["Height"];
                        dr["Type"] = drSq["Type"];
                        dr["WeightUOM"] = drSq["WeightUOM"];
                        dr["VolumeUOM"] = drSq["VolumeUOM"];
                        dt.Rows.Add(dr);
                    }
                    con.Close();
                }
                return dt;
            }
        }
    }
}


      









