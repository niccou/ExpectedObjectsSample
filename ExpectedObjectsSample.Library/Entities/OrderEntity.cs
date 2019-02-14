using System;
using System.Collections.Generic;

namespace ExpectedObjectsSample.Library.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public IEnumerable<OrderDetailEntity> OrderDetails { get; set; }
    }
}