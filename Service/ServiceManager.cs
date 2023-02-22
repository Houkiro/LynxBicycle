using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.ConfigurationModels;
using Microsoft.Extensions.Options;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAnnouncementService> _announementService;
        private readonly Lazy<IBrendService> _brendService;
        private readonly Lazy<IItemService> _itemService;
        private readonly Lazy<IBicycleTypeService> _typeService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IOptions<JwtConfiguration> configuration)
        {
            _announementService = new Lazy<IAnnouncementService>(() => new AnnouncementService(repositoryManager, logger, mapper, userManager));
            _brendService = new Lazy<IBrendService>(() => new BrendService(repositoryManager, logger, mapper));
            _itemService = new Lazy<IItemService>(() => new ItemService(repositoryManager, logger, mapper));
            _typeService = new Lazy<IBicycleTypeService>(() => new BicycleTypeService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
        }
        public IAnnouncementService AnnouncementService => _announementService.Value;
        public IBrendService BrendService => _brendService.Value;
        public IItemService ItemService => _itemService.Value;
        public IBicycleTypeService TypeService => _typeService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;

    }
}
