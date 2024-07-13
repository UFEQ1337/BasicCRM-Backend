using AutoMapper;
using BasicCRM.DTOs;
using BasicCRM.Models;
using BasicCRM.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicCRM.Services
{
    public class InteractionTypeService : IInteractionTypeService
    {
        private readonly IInteractionTypeRepository _repository;
        private readonly IMapper _mapper;

        public InteractionTypeService(IInteractionTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InteractionTypeDto>> GetAllAsync()
        {
            var interactionTypes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<InteractionTypeDto>>(interactionTypes);
        }

        public async Task<InteractionTypeDto> GetByInteractionTypeGuidAsync(Guid interactionTypeGuid)
        {
            var interactionType = await _repository.GetByInteractionTypeGuidAsync(interactionTypeGuid);
            return _mapper.Map<InteractionTypeDto>(interactionType);
        }

        public async Task<InteractionTypeDto> AddAsync(InteractionTypeDto interactionTypeDto)
        {
            var interactionType = _mapper.Map<InteractionType>(interactionTypeDto);
            await _repository.AddAsync(interactionType);
            return _mapper.Map<InteractionTypeDto>(interactionType);
        }

        public async Task UpdateAsync(InteractionTypeDto interactionTypeDto)
        {
            var interactionType = _mapper.Map<InteractionType>(interactionTypeDto);
            await _repository.UpdateAsync(interactionType);
        }

        public async Task DeleteAsync(Guid interactionTypeGuid)
        {
            await _repository.DeleteAsync(interactionTypeGuid);
        }
    }
}