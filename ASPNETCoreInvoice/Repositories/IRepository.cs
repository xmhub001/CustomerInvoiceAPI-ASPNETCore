using ASPNETCoreInvoice.Models;

namespace ASPNETCoreInvoice.Repositories
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public Task AddAsync(T employee);
        public Task UpdateAsync(T employee);
        public Task DeleteAsync(int id);
    }
}
