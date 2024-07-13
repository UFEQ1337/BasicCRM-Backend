using BasicCRM.DTOs;

namespace BasicCRM.Services
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>> GetAllAsync();
        Task<ContactDto> GetByContactGuidAsync(Guid contactGuid);
        Task AddAsync(ContactDto contactDto);
        Task UpdateAsync(ContactDto contactDto);
        Task DeleteAsync(Guid contactGuid);
    }
}
