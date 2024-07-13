using AutoMapper;
using BasicCRM.DTOs;
using BasicCRM.Models;
using BasicCRM.Repositories;

namespace BasicCRM.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetByCustomerGuidAsync(Guid customerGuid)
        {
            var customer = await _repository.GetByCustomerGuidAsync(customerGuid);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task AddAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _repository.AddAsync(customer);
        }

        public async Task UpdateAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _repository.UpdateAsync(customer);
        }

        public async Task DeleteAsync(Guid customerGuid)
        {
            await _repository.DeleteAsync(customerGuid);
        }
    }

}
