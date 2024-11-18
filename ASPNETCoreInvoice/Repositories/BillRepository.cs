using ASPNETCoreInvoice.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreInvoice.Repositories
{
    public class BillRepository : IRepository<Bill>
    {
        private CustomerDbContext _context;
        public BillRepository(CustomerDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Bill bill)
        {
            if (bill == null) throw new ArgumentNullException(nameof(bill));
            await _context.Bills.AddAsync(bill);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int Id)
        {
            var bill = await _context.FindAsync<Bill>(Id);
            if (bill != null)
            {
                _context.Bills.Remove(bill);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Bill>> GetAllAsync()
        {
            return await _context.Bills.ToListAsync<Bill>();
        }

        public async Task<Bill?> GetByIdAsync(int Id)
        {
            return await _context.Bills.FindAsync(Id);
        }

        public async Task UpdateAsync(Bill bill)
        {
            _context.Bills.Update(bill);
            await _context.SaveChangesAsync(true);
        }
    }
}
