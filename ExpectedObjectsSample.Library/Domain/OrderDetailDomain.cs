namespace ExpectedObjectsSample.Library.Domain
{
    public class OrderDetailDomain
    {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
    }
}