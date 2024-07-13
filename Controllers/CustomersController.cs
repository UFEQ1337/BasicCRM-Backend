using BasicCRM.DTOs;
using BasicCRM.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BasicCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var customers = await _service.GetAllAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{customerGuid}")]
        public async Task<IActionResult> GetByCustomerGuid(Guid customerGuid)
        {
            try
            {
                var customer = await _service.GetByCustomerGuidAsync(customerGuid);
                if (customer == null) return NotFound();
                return Ok(customer);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _service.AddAsync(customerDto);
                return CreatedAtAction(nameof(GetByCustomerGuid), new { customerGuid = customerDto.CustomerGuid }, customerDto);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{customerGuid}")]
        public async Task<IActionResult> Update(Guid customerGuid, [FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (customerGuid != customerDto.CustomerGuid)
            {
                return BadRequest("Customer ID mismatch");
            }

            try
            {
                await _service.UpdateAsync(customerDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{customerGuid}")]
        public async Task<IActionResult> Delete(Guid customerGuid)
        {
            try
            {
                await _service.DeleteAsync(customerGuid);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
