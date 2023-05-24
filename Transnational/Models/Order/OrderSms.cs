using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transnational.Models.Order
{
    public class OrderSms
    {
        public int SMSId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public string Mobile { get; set; }
        public string SAddressType { get; set; }
        public string CD { get; set; }
    }
}