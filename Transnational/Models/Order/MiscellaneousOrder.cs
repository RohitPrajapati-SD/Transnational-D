using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transnational.Models.Order
{
    public class MiscellaneousOrder
    {
        public int MiscellaneousOrderId { get; set; }
        public Nullable<int> MId { get; set; }
        public Nullable<int> InvoiceId { get; set; }
    }
}