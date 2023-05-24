using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Transnational.Models.ServiceAndProduct;

namespace Transnational.Models.Order
{
    public class Orders
    {

        // OrderDeliveryAddressObj, OrderAddress OrderAddressObj
        public OrderDeliveryAddress OrderDeliveryAddress { get; set; }
        public OrderAddress OrderAddress { get; set; }
        public GetOrderNo GetOrderNoObj { get; set; }



        public Nullable<int> OStatus { get; set; } 
        public Nullable<int> CompanyId { get; set; }
        public string CreatedByType { get; set; }
        public string SpecialInstructions { get; set; }
        public string OrderNo { get; set; }
        public Nullable<int> BillTo { get; set; }
        public Nullable<float> EstimatedCost { get; set; }
        public Nullable<float> Weight { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<float> Volume1 { get; set; }
        public Nullable<float> Volume2 { get; set; }
        public Nullable<float> Volume3 { get; set; }
        public Nullable<System.DateTime> PickupDate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string PickupTime { get; set; }
        public string DeliveryTime { get; set; }
        public Nullable<int> LanguageId { get; set; }
        public Nullable<int> InvoiceId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public string ContractCostCntrDprt { get; set; }
        public Nullable<int> QuantityUomId { get; set; }
        public string RequestorName { get; set; }
        public string AlternateRefNo { get; set; }
        public Nullable<int> CBranchId { get; set; }
        public string Status { get; set; }
        public Nullable<bool> ReturnService { get; set; }
        public string parentChild { get; set; }
        public Nullable<int> ServiceId { get; set; }
        public Nullable<int> ContractId { get; set; }
        public string BillToType { get; set; }
        public string approve { get; set; }
        public string RequestorContact { get; set; }
        public string OWeightUOM { get; set; }
        public string OVolumeUOM { get; set; }
        public string CD { get; set; }
        public string BillToVal { get; set; }
        public string Oemail { get; set; }
        public string Omobile { get; set; }
        public int DeliveryOptionId { get; set; }
        public string InvoiceType { get; set; }
        public Nullable<float> DeliveryOptionRate { get; set; }
        public Double GrandTotel { get; set; }
        public string BillingEmail { get; set; }
        public string BillingAddress { get; set; }


        public List<OrderEmail> OrderEmailObjList { get; set; }
        public List<OrderSms> OrderSmsObjList { get; set; }
        public List<InvoiceVolume> InvoiceVolumeObjList { get; set; }

        public List<AddtoMyCart> AddtoMyCartObjList { get; set; }
        public string CouponCode { get; set; }
        public float CouponAmount { get; set; }

        /* return service */
        public Nullable<int> ServiceId_Return { get; set; }
        public Nullable<System.DateTime> PickupDate_Return { get; set; }
        public Nullable<System.DateTime> DeliveryDate_Return { get; set; }
        public string PickupTime_Return { get; set; }
        public string DeliveryTime_Return { get; set; }
        public Boolean rtrnTrip { get; set; }

      //  public int ReturnOrderId { get; set; }

    }


    public class AllOrdersConduction
    {
        public string CD { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public string CreatedByType { get; set; }
        public string Status { get; set; }
        public string RecentOrder { get; set; }
        
        public List<OrderStatus> OrderStatusObjList { get; set; }

    }

    public class AllOrders
    {
        public int InvoiceId { get; set; }
        public string CompanyId { get; set; }
        public int CBranchId { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> PickupDate { get; set; }

        public string PickupTime { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }
        public string OrderNo { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string collectionAddress { get; set; }
        public string CollectionBranchName { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryBranchName { get; set; }
        public string ServiceName { get; set; }
        public Nullable<int> ContractId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public string CreatedByType { get; set; }
        public int ServiceId { get; set; }
        public double DeliveryOptionFees { get; set; }
        public Double GrandTotel { get; set; }
        public Double EstimatedCost { get; set; }





    }
    public class GetOrderByOrderIdConduction
    {
        public string CD { get; set; }
    }
    public class GetOrderByOrderId
    {
        public Nullable<int> InvoiceId { get; set; }
        public string CD { get; set; }



    }
    public class InvoiceVolume
    {

        public int InvoiceId { get; set; }
        public Double Weight { get; set; }
        public string OWeightUOM { get; set; }
        public int Quantity { get; set; }
        public string QuantityUomId { get; set; }
        public Double Volume1 { get; set; }
        public Double Volume2 { get; set; }
        public Double Volume3 { get; set; }
        public string OVolumeUOM { get; set; }
        public string VolumeType { get; set; }
        public string CD { get; set; }

    }
    public class UpdateInvoiceStatus
    {

        public int InvoiceId { get; set; }
        public int CancelledById { get; set; }
        public string CancelledByType { get; set; }
        public string RequestFrom { get; set; }
        public string Status { get; set; }
        public string CD { get; set; }

    }
    public class OrderStatus
    {
        public string Status { get; set; }


    }
    //--------------------------------------InsertOrderProductRating------------------------------------------//----
    public class OrderProductRating
    {
        public int CartId { get; set; }
        public int RatingUserId { get; set; }
        public string Feedback { get; set; }
        public Double Rating { get; set; }
        public string CD { get; set; }




    }
    //---------------------------------------//GetOrderProductByInoviceId//-------------------------------------//
    public class OrderProductConduction
    {
        public int InvoiceId { get; set; }

        public string CD { get; set; }
    }
    public class OrderProduct
    {
        public int CartId { get; set; }
        
        public int ProductId { get; set; }
        public Double Rate { get; set; }
        public Double Qty { get; set; }
        public String ServiceName { get; set; }
        public String ServiceImage { get; set; }

    }

    public class GetOrderNo
    {
        public string CD { get; set; }
        public string LoginType { get; set; }
        

        public int ContactId { get; set; }
        public int CreatedById { get; set; }
        public int CreatedByType { get; set; }

        public int LanguageId { get; set; }

    }

   public class TrackOrderStatus
         {
        public int InvoiceId { get; set; }

        public string CD { get; set; }
     

         }
   public class TrackOrder
   {
       public Object OrderDeliveryDate { get; set; }
       public Object OrderLastUpdateDate { get; set; }
       public Nullable<System.DateTime> OrderTime { get; set; }

       public String UpdatedStatus { get; set; }
        public String OrderStatus { get; set; }
        public String OrderNo { get; set; }
        public Object Index_Row { get; set; }
        public int OrderStatusId_Tracking { get; set; }
        public string Remark { get; set; }



    }
    public class OrderVolumeDetels
    {
        public string CD { get; set; }
    }

    public class SendEmail
    {
        public string CD { get; set; }


    }

}

