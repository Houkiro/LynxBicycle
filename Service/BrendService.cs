using AutoMapper;
using Contracts;
using Entities.Exeptions;
using LynxBicycle.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.CreateDto;

namespace Service
{
    internal sealed class BrendService : IBrendService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public BrendService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BrendDto>> GetAllBrendsAsync(bool trackChanges)
        {
            try
            {
                var brends = await _repository.Brend.GetAllBrendsAsync(trackChanges);

                var brendsDbo = brends.Select(b => new BrendDto(b.ID, b.Name)).ToList();

                return brendsDbo;
            }
            catch(Exception ex) 
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllBrendsAsync)} service method {ex}");
                throw;
            }
        }

        public async Task<BrendDto> GetBrendAsync(Guid brendID, bool trackChanges)
        {
            var brend = await _repository.Brend.GetBrendAsync(brendID, trackChanges);
            if (brend == null)
                throw new BrendNotFoundException(brendID);

            var brendDto = _mapper.Map<BrendDto>(brend);

            return brendDto;
        }

        public async Task<BrendDto> CreateBrendAsync(BrendForCreationDto brend)
        {
            var brendEntity = _mapper.Map<Brend>(brend);

            _repository.Brend.CreateBrend(brendEntity);
            await _repository.SaveAsync();

            var brendToReturne = _mapper.Map<BrendDto>(brendEntity);

            return brendToReturne;
        }

        public async Task DeleteBrendAsync(Guid brendID, bool trackChanges)
        {
            var brend = await _repository.Brend.GetBrendAsync(brendID, trackChanges);
            if (brend is null)
                throw new BrendNotFoundException(brendID);
            _repository.Brend.DeleteBrend(brend);
            await _repository.SaveAsync();
        }
    }
}
