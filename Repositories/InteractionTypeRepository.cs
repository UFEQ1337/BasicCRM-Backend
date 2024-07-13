using BasicCRM.Data;
using BasicCRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicCRM.Repositories
{
    public class InteractionTypeRepository : IInteractionTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public InteractionTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InteractionType>> GetAllAsync()
        {
            return await _context.InteractionTypes.ToListAsync();
        }

        public async Task<InteractionType> GetByInteractionTypeGuidAsync(Guid interactionTypeGuid)
        {
            return await _context.InteractionTypes.FindAsync(interactionTypeGuid);
        }

        public async Task AddAsync(InteractionType interactionType)
        {
            await _context.InteractionTypes.AddAsync(interactionType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(InteractionType interactionType)
        {
            _context.InteractionTypes.Update(interactionType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid interactionTypeGuid)
        {
            var interactionType = await _context.InteractionTypes.FindAsync(interactionTypeGuid);
            if (interactionType != null)
            {
                _context.InteractionTypes.Remove(interactionType);
                await _context.SaveChangesAsync();
            }
        }
    }
}