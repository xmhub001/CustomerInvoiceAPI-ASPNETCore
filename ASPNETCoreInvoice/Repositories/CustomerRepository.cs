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
        async Task IRepository<Customer>.AddAsync(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            await _context.Customers.AddAsync(customer);
            _context.SaveChanges();
        }

        async Task IRepository<Customer>.DeleteAsync(int Id)
        {
            var customer = await _context.FindAsync<Customer>(Id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        async Task<IEnumerable<Customer>> IRepository<Customer>.GetAllAsync()
        {
            return await _context.Customers.ToListAsync<Customer>();
        }

        async Task<Customer?> IRepository<Customer>.GetByIdAsync(int Id)
        {
            return await _context.Customers.FindAsync(Id);
        }

        async Task IRepository<Customer>.UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync(true);
        }
    }
}
