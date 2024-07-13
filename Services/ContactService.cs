using AutoMapper;
using BasicCRM.DTOs;
using BasicCRM.Models;

namespace BasicCRM.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactDto>> GetAllAsync()
        {
            var contacts = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ContactDto>>(contacts);
        }

        public async Task<ContactDto> GetByContactGuidAsync(Guid contactGuid)
        {
            var contact = await _repository.GetByContactGuidAsync(contactGuid);
            return _mapper.Map<ContactDto>(contact);
        }

        public async Task AddAsync(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            await _repository.AddAsync(contact);
        }

        public async Task UpdateAsync(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            await _repository.UpdateAsync(contact);
        }

        public async Task DeleteAsync(Guid contactGuid)
        {
            await _repository.DeleteAsync(contactGuid);
        }
    }
}
