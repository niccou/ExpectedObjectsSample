using System;
using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;
using ExpectedObjectsSample.Library;
using ExpectedObjectsSample.Library.Domain;
using ExpectedObjectsSample.Library.Entities;
using Xunit;

namespace ExpectedObjectsSample.UnitTests
{
    public class EntitiesConverterShould
    {
        private readonly UserEntity _userEntity;

        public EntitiesConverterShould()
        {
            _userEntity = new UserEntity
            {
                Id = 1,
                Name = "Customer",
                UserAddress = new AddressEntity{
                    Street = "My street",
                    ZipCode = "ZipCode",
                    City = "City"
                },
                Orders = new List<OrderEntity>
                {
                    new OrderEntity
                    {
                        Id = 10,
                        OrderDate = new DateTime(2017,5,2),
                        OrderDetails = new List<OrderDetailEntity>
                        {
                            new OrderDetailEntity
                            {
                                Id = 100,
                                ProductName = "Product 1",
                                Quantity = 5,
                                UnitPrice = 12.5
                            },
                            new OrderDetailEntity
                            {
                                Id = 200,
                                ProductName = "Product 2",
                                Quantity = 10,
                                UnitPrice = 5.2
                            }
                        }
                    }
                }
            };
        }

        [Fact]
        public void ConvertUserEntityToUserDomainVerifiedByClassicAssertions()
        {
            //Given
            var expectedUserDomain = new UserDomain
            {
                Id = 1,
                Name = "Customer",
                Street = "My street",
                ZipCode = "ZipCode",
                City = "City",
                Orders = new OrderDomain[]
                {
                    new OrderDomain
                    {
                        OrderNumber = "FA-10",
                        OrderDate = new DateTime(2017,5,2),
                        OrderDetails = new List<OrderDetailDomain>
                        {
                            new OrderDetailDomain
                            {
                                ProductName = "Product 1",
                                Quantity = 5,
                                UnitPrice = 12.5,
                                Total = 65.5
                            },
                            new OrderDetailDomain
                            {
                                ProductName = "Product 2",
                                Quantity = 10,
                                UnitPrice = 5.2,
                                Total = 52.0
                            }
                        },
                        Total = 117.5
                    }
                }
            };

            //When
            UserDomain convertedUser = EntitiesConverter.Convert(_userEntity);

            //Then
            Assert.Equal(expectedUserDomain.Id, convertedUser.Id);
            Assert.Equal(expectedUserDomain.Name, convertedUser.Name);
            
            Assert.Equal(expectedUserDomain.Street, convertedUser.Street);
            Assert.Equal(expectedUserDomain.ZipCode, convertedUser.ZipCode);
            Assert.Equal(expectedUserDomain.City, convertedUser.City);

            Assert.Equal(expectedUserDomain.Orders.Count(), convertedUser.Orders.Count());

            var orderEntity = expectedUserDomain.Orders.First();
            var orderDomain = convertedUser.Orders.First();

            Assert.Equal(orderEntity.OrderNumber, orderDomain.OrderNumber);
            Assert.Equal(orderEntity.OrderDate, orderDomain.OrderDate);
            Assert.Equal(orderEntity.OrderDetails.Count(), orderDomain.OrderDetails.Count());

            var orderDetailEntity = orderEntity.OrderDetails.First();
            var orderDetailDomain = orderDomain.OrderDetails.First();

            Assert.Equal(orderDetailEntity.ProductName, orderDetailDomain.ProductName);
            Assert.Equal(orderDetailEntity.Quantity, orderDetailDomain.Quantity);
            Assert.Equal(orderDetailEntity.UnitPrice, orderDetailDomain.UnitPrice);
        }

        [Fact]
        public void ConvertUserEntityToUserDomainVerifiedByExpectedObjects()
        {
            //Given
            var expectedUserDomain = new UserDomain
            {
                Id = 1,
                Name = "Customer",
                Street = "My street",
                ZipCode = "ZipCode",
                City = "City",
                Orders = new List<OrderDomain>
                {
                    new OrderDomain
                    {
                        OrderNumber = "FA-10",
                        OrderDate = new DateTime(2017,5,2),
                        OrderDetails = new List<OrderDetailDomain>
                        {
                            new OrderDetailDomain
                            {
                                ProductName = "Product 1",
                                Quantity = 5,
                                UnitPrice = 12.5,
                                Total = 62.5
                            },
                            new OrderDetailDomain
                            {
                                ProductName = "Product 2",
                                Quantity = 10,
                                UnitPrice = 5.2,
                                Total = 52.0
                            }
                        }
                    }
                }
            }.ToExpectedObject();

            //When
            UserDomain convertedUser = EntitiesConverter.Convert(_userEntity);

            //Then
            expectedUserDomain.ShouldEqual(convertedUser);
        }
    }
}