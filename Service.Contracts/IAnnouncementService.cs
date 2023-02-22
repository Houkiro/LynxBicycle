using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAnnouncementService
    {
        Task<IEnumerable<AnnouncementDto>> GetAllAnnouncementsAsync(bool trackChanges);
        Task<AnnouncementDto> GetAnnouncementAsync(string userId, Guid announcementID, bool trackChanges);
        Task<IEnumerable<AnnouncementDto>> GetAllAnnouncementsForUserProfileAsync(string userId, bool trackChanges);
        Task<AnnouncementDto> CreateAnnouncementAsync(string userId, Guid itemID, AnnouncementForCreationDto announcementForCreation, bool trackChanges);
        Task DeleteAnnouncementForUserProfileAsync(string userId, Guid announcementID, bool trackChanges);
    }
}
