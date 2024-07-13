using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasicCRM.DTOs;

namespace BasicCRM.Services
{
    public interface IInteractionService
    {
        Task<IEnumerable<InteractionDto>> GetAllAsync();
        Task<InteractionDto> GetByInteractionGuidAsync(Guid interactionGuid);
        Task<InteractionDto> AddAsync(InteractionDto interactionDto);
        Task UpdateAsync(InteractionDto interactionDto);
        Task DeleteAsync(Guid interactionGuid);
    }
}