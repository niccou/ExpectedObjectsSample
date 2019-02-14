using System.Collections.Generic;

namespace ExpectedObjectsSample.Library.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressEntity UserAddress { get; set; }
        public IEnumerable<OrderEntity> Orders { get; set; }
    }
}