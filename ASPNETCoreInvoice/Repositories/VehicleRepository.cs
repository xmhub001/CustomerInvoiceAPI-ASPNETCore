using ASPNETCoreInvoice.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreInvoice.Repositories
{
    public class VehicleRepository : IRepository<Vehicle>
    {
        private CustomerDbContext _context;
        public VehicleRepository(CustomerDbContext context)
        {
            _context = context;
        }
        async Task IRepository<Vehicle>.AddAsync(Vehicle vehicle)
        {
            if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));
            await _context.Vehicles.AddAsync(vehicle);
            _context.SaveChanges();
        }

        async Task IRepository<Vehicle>.DeleteAsync(int Id)
        {
            var vehicle = await _context.FindAsync<Vehicle>(Id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
            }
        }

        async Task<IEnumerable<Vehicle>> IRepository<Vehicle>.GetAllAsync()
        {
            return await _context.Vehicles.ToListAsync<Vehicle>();
        }

        async Task<Vehicle?> IRepository<Vehicle>.GetByIdAsync(int Id)
        {
            return await _context.Vehicles.FindAsync(Id);
        }

        async Task IRepository<Vehicle>.UpdateAsync(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync(true);
        }
    }
}
