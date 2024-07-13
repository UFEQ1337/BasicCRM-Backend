using BasicCRM.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicCRM.Repositories
{
    public interface IInteractionRepository
    {
        Task<IEnumerable<Interaction>> GetAllAsync();
        Task<Interaction> GetByInteractionGuidAsync(Guid interactionGuid);
        Task AddAsync(Interaction interaction);
        Task UpdateAsync(Interaction interaction);
        Task DeleteAsync(Guid interactionGuid);
    }
}