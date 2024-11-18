using ASPNETCoreInvoice.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreInvoice.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private CustomerDbContext _context;
        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            await _context.Customers.AddAsync(customer);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int Id)
        {
            var customer = await _context.FindAsync<Customer>(Id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync<Customer>();
        }

        public async Task<Customer?> GetByIdAsync(int Id)
        {
            return await _context.Customers.FindAsync(Id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync(true);
        }
    }
}
