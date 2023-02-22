using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.CreateDto;
using System.Data;

namespace LynxBicycle.Presentation.Controllers
{
    [Route("api/brends")]
    [ApiController]
    public class BrendController : ControllerBase
    {
        private readonly IServiceManager _service;
        public BrendController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetBrendsAsync()
        {
            var brends = await _service.BrendService.GetAllBrendsAsync(trackChanges: false);
            return Ok(brends);
        }
        [HttpGet("{ID:guid}", Name = "BrendByID")]
        public async Task<IActionResult> GetBrendAsync(Guid ID)
        {
            var brand = await _service.BrendService.GetBrendAsync(ID, trackChanges: false);
            return Ok(brand);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateBrendAsync([FromBody] BrendForCreationDto brend)
        {
            if (brend is null)
                return BadRequest("BrendForCreationDto object is null");
            var createdBrend = await _service.BrendService.CreateBrendAsync(brend);
            return CreatedAtRoute("BrendByID", new { ID = createdBrend.ID }, createdBrend);

        }

        [HttpDelete("{brendID:guid}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteBrendAsync(Guid brendID)
        {
            await _service.BrendService.DeleteBrendAsync(brendID, trackChanges: false);
            return NoContent();
        }
    }
}
