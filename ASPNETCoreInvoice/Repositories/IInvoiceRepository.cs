using ASPNETCoreInvoice.Models;

namespace ASPNETCoreInvoice.Repositories
{
    public interface IInvoiceRepository
    {
        public Task<IEnumerable<Invoice>> GetAllInvoicesAsync();
        public Task<Invoice?> GetInvoiceByIdAsync(int Id);
        public Task AddInvoiceAsync(Invoice invoice);
        public Task UpdateInvoiceAsync(Invoice invoice);
        public Task DeleteInvoiceAsync(int Id);
    }
}
