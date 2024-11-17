using ASPNETCoreInvoice.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreInvoice.Models
{
    public class CustomerDbContext : DbContext 
    {
        
        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            :base(options) { 
        
        }
    }
}
