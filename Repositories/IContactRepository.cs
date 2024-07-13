using System.Collections.Generic;
using System.Threading.Tasks;
using BasicCRM.Models;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllAsync();
    Task<Contact> GetByContactGuidAsync(Guid contactGuid);
    Task AddAsync(Contact contact);
    Task UpdateAsync(Contact contact);
    Task DeleteAsync(Guid contactGuid);
}