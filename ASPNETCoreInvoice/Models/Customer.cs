using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreInvoice.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Customer Name is required")]
        public required string CustomerName { get; set; }
        [Required(ErrorMessage = "Customer Address is required")] 
        public string? CustomerAddress { get; set; }
        [Required(ErrorMessage = "Customer Email is required")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        [Length(5,200, ErrorMessage ="Email Min / Max Length is 5 / 200")]
        public string CustomerEmail { get; set; } = string.Empty;
        [Required(ErrorMessage = "Customer Phone is required")] 
        public string? CustomerPhone { get; set; }
        [Required(ErrorMessage = "Customer City is required")] 
        public string? CustomerCity { get; set; }
        [Required(ErrorMessage = "Customer State is required")] 
        public string? CustomerState { get; set; }
        [Required(ErrorMessage = "Customer Region is required")] 
        public string? CustomerRegion { get; set; }
        [Required(ErrorMessage = "Customer Postal Code is required")] 
        public string? CustomerPostalCode { get; set; }
    }
}
