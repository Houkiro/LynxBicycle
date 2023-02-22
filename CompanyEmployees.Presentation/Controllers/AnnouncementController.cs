using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Data;

namespace LynxBicycle.Presentation.Controllers
{
    [Route("api/announcements")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AnnouncementController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllAnnouncementsAsync()
        {
            var announcements = await _service.AnnouncementService.GetAllAnnouncementsAsync(trackChanges: false);
            return Ok(announcements);
        }

        [HttpGet("{ID:guid}", Name = "GetAnnouncement")]
        public async Task<IActionResult> GetAnnouncementAsync(Guid ID, string userId)
        {
            var announcement = await _service.AnnouncementService.GetAnnouncementAsync(userId, ID, trackChanges: false);

            return Ok(announcement);
        }

        [HttpGet("{userProfileID:guid}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAllAnnouncementsForUserProfileAsync(string userId)
        {
            var announcements = await _service.AnnouncementService.GetAllAnnouncementsForUserProfileAsync(userId, trackChanges: false);
            return Ok(announcements);
        }

        [HttpPost]
        //[Authorize(Roles = "User, Administrator")]
        public async Task<IActionResult> CreateAnnouncementAsync(string userId, Guid itemID, [FromBody] AnnouncementForCreationDto announcement)
        {
            if (announcement is null)
                return BadRequest("AnnouncementForCreationDto object is null");
            var announcementToReturn = await _service.AnnouncementService.CreateAnnouncementAsync(userId, itemID, announcement, trackChanges: false);

            return CreatedAtRoute("GetAnnouncement", new { userId, itemID, ID = announcementToReturn.ID }, announcementToReturn);
        }

        [HttpDelete("{announcementID:guid}")]
       // [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteAnnouncementForUserProfileAsync(string userId, Guid announcementID)
        {
            await _service.AnnouncementService.DeleteAnnouncementForUserProfileAsync(userId, announcementID, trackChanges: false);
            return NoContent();
        }
    }
}
