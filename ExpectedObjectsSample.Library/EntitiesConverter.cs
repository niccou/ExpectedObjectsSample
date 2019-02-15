using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using ExpectedObjectsSample.Library.Domain;
using ExpectedObjectsSample.Library.Entities;
using System.Linq;

namespace ExpectedObjectsSample.Library
{
    public class EntitiesConverter
    {
        public static UserDomain Convert(UserEntity userEntity) => new UserDomain
        {
            Id = userEntity.Id,
            Name = userEntity.Name,
            Orders = Convert(userEntity.Orders).ToList(),
            Street = userEntity.UserAddress.Street,
            ZipCode = userEntity.UserAddress.ZipCode,
            City = userEntity.UserAddress.City
        };

        private static OrderDetailDomain Convert(OrderDetailEntity orderDetail) => new OrderDetailDomain
        {
            ProductName = orderDetail.ProductName,
            Quantity = orderDetail.Quantity,
            UnitPrice = orderDetail.UnitPrice,
            Total = orderDetail.Quantity * orderDetail.UnitPrice
        };

        private static IEnumerable<OrderDomain> Convert(IEnumerable<OrderEntity> orders) => orders?.Select(Convert).ToList();

        private static OrderDomain Convert(OrderEntity orderEntity) => orderEntity == null ? null : new OrderDomain
        {
            OrderNumber =  $"FA-{orderEntity.Id}",
            OrderDate = orderEntity.OrderDate,
            OrderDetails = orderEntity.OrderDetails?.Select(Convert).ToList()
        };
    }
}