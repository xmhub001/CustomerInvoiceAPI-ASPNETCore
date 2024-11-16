using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreInvoice.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; } = string.Empty;
        public DateOnly InvoiceDate {  get; set; }
        public double InvoiceAmount { get; set; }
    }
}
