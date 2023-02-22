using AutoMapper;
using Entities.Models;
using LynxBicycle.Models;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.CreateDto;

namespace LynxBicycle
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Announcement, AnnouncementDto>();
            CreateMap<Item, ItemDto>();
            CreateMap<Brend, BrendDto>();
            CreateMap<BicycleType, BicycleTypeDto>();
            CreateMap<BrendForCreationDto, Brend>();
            CreateMap<TypeForCreationDto, BicycleType>();
            CreateMap<ItemForCreationDto, Item>();
            CreateMap<AnnouncementForCreationDto, Announcement>();
            CreateMap<UserForRegistrationDto, User>();

        }
    }
}
