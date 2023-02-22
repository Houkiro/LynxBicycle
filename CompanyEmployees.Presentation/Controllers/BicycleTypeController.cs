using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.ComponentModel;
using System.Data;

namespace LynxBicycle.Presentation.Controllers
{
    [Route("api/types")]
    [ApiController]
    public class BicycleTypeController : ControllerBase
    {
        private readonly IServiceManager _service;
        public BicycleTypeController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllTypesAsync()
        {
            var types = await _service.TypeService.GetAllTypesAsync(trackChanges: false);
            return Ok(types);
        }
        [HttpGet("{ID:guid}", Name = "TypeByID")]
        public async Task<IActionResult> GetTypeAsync(Guid ID) 
        {
            var type = await _service.TypeService.GetTypeAsync(ID, trackChanges: false);
            return Ok(type);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateTypeAsync([FromBody] TypeForCreationDto type)
        {
            if (type is null)
                return BadRequest("TypeForCreationDto object is null");
            var createdType = await _service.TypeService.CreateTypeAsync(type);
            return CreatedAtRoute("TypeByID", new { ID = createdType.ID }, createdType);

        }
        [HttpDelete("typeID:guid")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteTypeAsync(Guid typeID) 
        {
            await _service.TypeService.DeleteTypeAsync(typeID, trackChanges: false);
            return NoContent();
        }
    }
}
