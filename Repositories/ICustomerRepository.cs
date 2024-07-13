using BasicCRM.Models;

namespace BasicCRM.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByCustomerGuidAsync(Guid customerGuid);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid customerGuid);
    }
}
