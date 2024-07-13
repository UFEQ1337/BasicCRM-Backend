using BasicCRM.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicCRM.Repositories
{
    public interface IInteractionTypeRepository
    {
        Task<IEnumerable<InteractionType>> GetAllAsync();
        Task<InteractionType> GetByInteractionTypeGuidAsync(Guid interactionTypeGuid);
        Task AddAsync(InteractionType interactionType);
        Task UpdateAsync(InteractionType interactionType);
        Task DeleteAsync(Guid interactionTypeGuid);
    }
}