using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Data;

namespace LynxBicycle.Presentation.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ItemController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetItemsAsync()
        {
            var items = await _service.ItemService.GetAllItemsAsync(trackChanges: false);
            return Ok(items);
        }

        [HttpGet("{ID:guid}", Name = "GetItem")]
        public async Task<IActionResult> GetItemAsync(Guid ID)
        {
            var item = await _service.ItemService.GetItemAsync(ID, trackChanges: false);
            return Ok(item);
        }

        [HttpGet("api/brends/{brendID:guid}/items", Name = "AllBrendItemsID")]
        public async Task<IActionResult> GetAllItemsForBrendAsync(Guid brendID)
        {
            var item = await _service.ItemService.GetAllItemsForBrendAsync(brendID, trackChanges: false);
            return Ok(item);
        }

        [HttpGet("api/types/{typeID:guid}/items", Name = "AllTypeItemsID")]
        public async Task<IActionResult> GetAllItemsForTypeAsync(Guid typeID)
        {
            var item = await _service.ItemService.GetAllItemsForTypeAsync(typeID, trackChanges: false);
            return Ok(item);
        }

        [HttpPost("api/items/{brendID:guid}/{typeID:guid}", Name = "CreateItem")]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateItemAsync(Guid brendID, Guid typeID, [FromBody] ItemForCreationDto item)
        {
            if (item is null)
                return BadRequest("ItemForCreationDto object is null");
            var itemToReturn = await _service.ItemService.CreateItemAsync(brendID, typeID, item, trackChanges: false);

            return CreatedAtRoute("GetItem", new { brendID, typeID, ID = itemToReturn.ID }, itemToReturn);
        }

        [HttpDelete("{itemID:guid}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteItemAsync(Guid itemID) 
        {
            await _service.ItemService.DeleteItemAsync(itemID, trackChanges: false);
            return NoContent();
        }
    }
}
