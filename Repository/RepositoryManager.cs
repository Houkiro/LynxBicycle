using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IAnnouncementRepository> _announcementRepository;
        private readonly Lazy<IBrendRepository> _brendRepository;
        private readonly Lazy<IItemRepository> _itemRepository;
        private readonly Lazy<IBicycleTypeRepository> _typeRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _announcementRepository = new Lazy<IAnnouncementRepository>(() => new AnnouncementRepository(repositoryContext));
            _brendRepository = new Lazy<IBrendRepository>(() => new BrendRepository(repositoryContext));
            _itemRepository = new Lazy<IItemRepository>(() => new ItemRepository(repositoryContext));
            _typeRepository = new Lazy<IBicycleTypeRepository>(() => new BicycleTypeRepository(repositoryContext));
        }
        public IAnnouncementRepository Announcement => _announcementRepository.Value;
        public IBrendRepository Brend => _brendRepository.Value;
        public IItemRepository Item => _itemRepository.Value;
        public IBicycleTypeRepository BicycleType => _typeRepository.Value;

        public void Save() => _repositoryContext.SaveChanges();
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

    }
}
