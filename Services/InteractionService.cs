using AutoMapper;
using BasicCRM.DTOs;
using BasicCRM.Models;
using BasicCRM.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicCRM.Services
{
    public class InteractionService : IInteractionService
    {
        private readonly IInteractionRepository _repository;
        private readonly IMapper _mapper;

        public InteractionService(IInteractionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InteractionDto>> GetAllAsync()
        {
            var interactions = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<InteractionDto>>(interactions);
        }

        public async Task<InteractionDto> GetByInteractionGuidAsync(Guid interactionGuid)
        {
            var interaction = await _repository.GetByInteractionGuidAsync(interactionGuid);
            return _mapper.Map<InteractionDto>(interaction);
        }

        public async Task<InteractionDto> AddAsync(InteractionDto interactionDto)
        {
            var interaction = _mapper.Map<Interaction>(interactionDto);
            await _repository.AddAsync(interaction);
            return _mapper.Map<InteractionDto>(interaction);
        }

        public async Task UpdateAsync(InteractionDto interactionDto)
        {
            var interaction = _mapper.Map<Interaction>(interactionDto);
            await _repository.UpdateAsync(interaction);
        }

        public async Task DeleteAsync(Guid interactionGuid)
        {
            await _repository.DeleteAsync(interactionGuid);
        }
    }
}