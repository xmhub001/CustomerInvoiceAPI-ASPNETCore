using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreInvoice.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public required int CustomerId { get; set; }
        public DateOnly InvoiceDate {  get; set; }
        public double InvoiceAmount { get; set; }
    }
}
