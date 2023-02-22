using Contracts;
using Service.Contracts;
using LynxBicycle.Models;
using Shared.DataTransferObjects;
using AutoMapper;
using Entities.Exeptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Service
{
    internal sealed class AnnouncementService : IAnnouncementService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public AnnouncementService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<AnnouncementDto> CreateAnnouncementAsync(string userId, Guid itemID, AnnouncementForCreationDto announcementForCreation, bool trackChanges)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                throw new UserNotFoundException(userId);

            var item = await _repository.Item.GetItemAsync(itemID, trackChanges);
            if (item is null)
                throw new ItemNotFoundException(itemID);

            var announcementEntity = _mapper.Map<Announcement>(announcementForCreation);

            _repository.Announcement.CreateAnnouncement(userId, itemID, announcementEntity);
            await _repository.SaveAsync();

            var announcementToReturn = _mapper.Map<AnnouncementDto>(announcementEntity);

            return announcementToReturn;
        }

        public async Task DeleteAnnouncementForUserProfileAsync(string userId, Guid announcementID, bool trackChanges)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                throw new UserNotFoundException(userId);
            var announcementForUserProfile = await _repository.Announcement.GetAnnouncementAsync(userId, announcementID, trackChanges);
            if (announcementForUserProfile is null)
                throw new AnnouncementNotFoundException(announcementID);
            _repository.Announcement.DeleteAnnouncement(announcementForUserProfile);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<AnnouncementDto>> GetAllAnnouncementsAsync(bool trackChanges)
        {

            var announcements = await _repository.Announcement.GetAllAnnouncementsAsync(trackChanges);

            var announcementsDto = _mapper.Map<IEnumerable<AnnouncementDto>>(announcements);

            return announcementsDto;


        }

        public async Task<IEnumerable<AnnouncementDto>> GetAllAnnouncementsForUserProfileAsync(string userId, bool trackChanges)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                throw new UserNotFoundException(userId);

            var announcementsFromDb = await _repository.Announcement.GetAllAnnouncementsForUserAsync(userId, trackChanges);
            var announcementssDto = _mapper.Map<IEnumerable<AnnouncementDto>>(announcementsFromDb);
            return announcementssDto;
        }

        public async Task<AnnouncementDto> GetAnnouncementAsync(string userId, Guid announcementID, bool trackChanges)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                throw new UserNotFoundException(userId);

            var announcementDb = await _repository.Announcement.GetAnnouncementAsync(userId, announcementID, trackChanges);
            if (announcementDb == null)
                throw new AnnouncementNotFoundException(announcementID);

            var announcementDto = _mapper.Map<AnnouncementDto>(announcementDb);

            return announcementDto;
        }
    }
}
