using System.Collections.Generic;

namespace ExpectedObjectsSample.Library.Domain
{
    public class UserDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public IEnumerable<OrderDomain> Orders { get; set; }
   }
}