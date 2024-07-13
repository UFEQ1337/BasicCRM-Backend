using BasicCRM.Data;
using BasicCRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicCRM.Repositories
{
    public class InteractionRepository : IInteractionRepository
    {
        private readonly ApplicationDbContext _context;

        public InteractionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Interaction>> GetAllAsync()
        {
            return await _context.Interactions.Include(i => i.InteractionType).ToListAsync();
        }

        public async Task<Interaction> GetByInteractionGuidAsync(Guid interactionGuid)
        {
            return await _context.Interactions.Include(i => i.InteractionType).FirstOrDefaultAsync(i => i.InteractionGuid == interactionGuid);
        }

        public async Task AddAsync(Interaction interaction)
        {
            await _context.Interactions.AddAsync(interaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Interaction interaction)
        {
            _context.Interactions.Update(interaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid interactionGuid)
        {
            var interaction = await _context.Interactions.FindAsync(interactionGuid);
            if (interaction != null)
            {
                _context.Interactions.Remove(interaction);
                await _context.SaveChangesAsync();
            }
        }
    }
}