using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasicCRM.DTOs;

namespace BasicCRM.Services
{
    public interface IInteractionTypeService
    {
        Task<IEnumerable<InteractionTypeDto>> GetAllAsync();
        Task<InteractionTypeDto> GetByInteractionTypeGuidAsync(Guid interactionTypeGuid);
        Task<InteractionTypeDto> AddAsync(InteractionTypeDto interactionTypeDto);
        Task UpdateAsync(InteractionTypeDto interactionTypeDto);
        Task DeleteAsync(Guid interactionTypeGuid);
    }
}