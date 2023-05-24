using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transnational.Models.Order
{
    public class OrderEmail
    {
        public int OEmailId { get; set; }
        public int OrderId { get; set; }
        public string OEmail { get; set; }
        public string OAddressType { get; set; }
        public string CD { get; set; }
    }
}