using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpectedObjectsSample.Library.Domain
{
    public class OrderDomain
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public IEnumerable<OrderDetailDomain> OrderDetails { get; set; }
        public double Total { get; set; }
    }
}