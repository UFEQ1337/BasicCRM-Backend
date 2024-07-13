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
    public class InteractionsController : ControllerBase
    {
        private readonly IInteractionService _service;

        public InteractionsController(IInteractionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var interactions = await _service.GetAllAsync();
                return Ok(interactions);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{interactionGuid}")]
        public async Task<IActionResult> GetByInteractionGuid(Guid interactionGuid)
        {
            try
            {
                var interaction = await _service.GetByInteractionGuidAsync(interactionGuid);
                if (interaction == null) return NotFound();
                return Ok(interaction);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InteractionDto interactionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdInteraction = await _service.AddAsync(interactionDto);
                return CreatedAtAction(nameof(GetByInteractionGuid), new { interactionGuid = createdInteraction.InteractionGuid }, createdInteraction);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{interactionGuid}")]
        public async Task<IActionResult> Update(Guid interactionGuid, [FromBody] InteractionDto interactionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (interactionGuid != interactionDto.InteractionGuid)
            {
                return BadRequest("Interaction ID mismatch");
            }

            try
            {
                await _service.UpdateAsync(interactionDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{interactionGuid}")]
        public async Task<IActionResult> Delete(Guid interactionGuid)
        {
            try
            {
                await _service.DeleteAsync(interactionGuid);
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
