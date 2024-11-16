using ASPNETCoreInvoice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ASPNETCoreInvoice.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private CustomerDbContext _context;
        public InvoiceRepository(CustomerDbContext context)
        {
            _context = context;
        }
        public async Task AddInvoiceAsync(Invoice invoice)
        {
            if (invoice == null) throw new ArgumentNullException(nameof(invoice));
            await _context.Invoices.AddAsync(invoice);
            _context.SaveChanges();
        }

        public async Task DeleteInvoiceAsync(int Id)
        {
            var invoice = await _context.FindAsync<Invoice>(Id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
        {
            return await _context.Invoices.ToListAsync<Invoice>();
        }

        public async Task<Invoice?> GetInvoiceByIdAsync(int Id)
        {
            return await _context.Invoices.FindAsync(Id);
            //if(Id < 0) throw new ArgumentOutOfRangeException(nameof(Id));
            //var invoice  =  _context.Invoices.FindAsync(Id);
            //return Task.FromResult(invoice);
        }

        public Task UpdateInvoiceAsync(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
