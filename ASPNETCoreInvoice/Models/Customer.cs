namespace ASPNETCoreInvoice.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public required string CustomerName { get; set; }
        public string? CustomerAddress { get; set; } 
        public string CustomerEmail { get; set; } = string.Empty;
        public string? CustomerPhone { get; set; }
        public string? CustomerCity { get; set; }
        public string? CustomerState { get; set; }
        public string? CustomerRegion { get; set; }
        public string? CustomerPostalCode { get; set; }
    }
}
