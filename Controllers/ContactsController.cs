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
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var contacts = await _service.GetAllAsync();
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{contactGuid}")]
        public async Task<IActionResult> GetByContactGuid(Guid contactGuid)
        {
            try
            {
                var contact = await _service.GetByContactGuidAsync(contactGuid);
                if (contact == null) return NotFound();
                return Ok(contact);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _service.AddAsync(contactDto);
                return CreatedAtAction(nameof(GetByContactGuid), new { contactGuid = contactDto.ContactGuid }, contactDto);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{contactGuid}")]
        public async Task<IActionResult> Update(Guid contactGuid, [FromBody] ContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (contactGuid != contactDto.ContactGuid)
            {
                return BadRequest("Contact ID mismatch");
            }

            try
            {
                await _service.UpdateAsync(contactDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{contactGuid}")]
        public async Task<IActionResult> Delete(Guid contactGuid)
        {
            try
            {
                await _service.DeleteAsync(contactGuid);
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
