using ASPNETCoreInvoice.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreInvoice.Models
{
    public class CustomerDbContext : DbContext 
    {
        
        public DbSet<Invoice> Invoices { get; set; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            :base(options) { 
        
        }
    }
}
