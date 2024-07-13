using BasicCRM.DTOs;
using BasicCRM.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BasicCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InteractionTypesController : ControllerBase
    {
        private readonly IInteractionTypeService _service;

        public InteractionTypesController(IInteractionTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var interactionTypes = await _service.GetAllAsync();
                return Ok(interactionTypes);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{interactionTypeGuid}")]
        public async Task<IActionResult> GetByInteractionTypeGuid(Guid interactionTypeGuid)
        {
            try
            {
                var interactionType = await _service.GetByInteractionTypeGuidAsync(interactionTypeGuid);
                if (interactionType == null) return NotFound();
                return Ok(interactionType);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InteractionTypeDto interactionTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdInteractionType = await _service.AddAsync(interactionTypeDto);
                return CreatedAtAction(nameof(GetByInteractionTypeGuid), new { interactionTypeGuid = createdInteractionType.InteractionTypeGuid }, createdInteractionType);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{interactionTypeGuid}")]
        public async Task<IActionResult> Update(Guid interactionTypeGuid, [FromBody] InteractionTypeDto interactionTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (interactionTypeGuid != interactionTypeDto.InteractionTypeGuid)
            {
                return BadRequest("Interaction Type ID mismatch");
            }

            try
            {
                await _service.UpdateAsync(interactionTypeDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{interactionTypeGuid}")]
        public async Task<IActionResult> Delete(Guid interactionTypeGuid)
        {
            try
            {
                await _service.DeleteAsync(interactionTypeGuid);
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
