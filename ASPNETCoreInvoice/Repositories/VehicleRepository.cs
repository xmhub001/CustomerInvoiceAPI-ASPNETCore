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
        public async Task AddAsync(Vehicle vehicle)
        {
            if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));
            await _context.Vehicles.AddAsync(vehicle);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int Id)
        {
            var vehicle = await _context.FindAsync<Vehicle>(Id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _context.Vehicles.ToListAsync<Vehicle>();
        }

        public async Task<Vehicle?> GetByIdAsync(int Id)
        {
            return await _context.Vehicles.FindAsync(Id);
        }

        public async Task UpdateAsync(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync(true);
        }
    }
}
