using BasicCRM.DTOs;

namespace BasicCRM.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerDto> GetByCustomerGuidAsync(Guid customerGuid);
        Task AddAsync(CustomerDto customerDto);
        Task UpdateAsync(CustomerDto customerDto);
        Task DeleteAsync(Guid customerGuid);
    }

}
