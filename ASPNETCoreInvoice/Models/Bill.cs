namespace ASPNETCoreInvoice.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string? BillCycle { get; set; }
        public double[]? BillInvoiceId { get; set; }
        public DateOnly BillDate { get; set; }

        public double BillAmount { get; set; }
    }
}
