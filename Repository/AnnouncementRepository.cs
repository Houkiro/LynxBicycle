using Contracts;
using LynxBicycle.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AnnouncementRepository : RepositoryBase<Announcement>, IAnnouncementRepository
    {
        
        public AnnouncementRepository(RepositoryContext repositoryContext) : base(repositoryContext) {}

        
        public void CreateAnnouncement(string userId, Guid itemID, Announcement announcement)
        {
            announcement.UserId = userId;
            announcement.ItemID = itemID;
            Create(announcement);
        }
        public async Task<IEnumerable<Announcement>> GetAllAnnouncementsForUserAsync(string userID, bool trackChanges) =>
           await FindByCondition(a => a.UserId.Equals(userID), trackChanges)
            .OrderBy(a => a.DateOfIssue).ToListAsync();
        public async Task<IEnumerable<Announcement>> GetAllAnnouncementsAsync(bool trackChanges) => await FindAll(trackChanges).ToListAsync();
        public async Task<Announcement> GetAnnouncementAsync(string userId, Guid announcementID, bool trackChanges) =>
            await FindByCondition(a => a.UserId.Equals(userId) && a.ID.Equals(announcementID), trackChanges).SingleOrDefaultAsync();

        public void DeleteAnnouncement(Announcement announcement) => Delete(announcement);
    }
}
