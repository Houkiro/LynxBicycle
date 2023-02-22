using AutoMapper;
using Contracts;
using Entities.Exeptions;
using LynxBicycle.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class BicycleTypeService : IBicycleTypeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public BicycleTypeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BicycleTypeDto>> GetAllTypesAsync(bool trackChanges)
        {
            try
            {
                var bicycleType = await _repository.BicycleType.GetAllTypesAsync(trackChanges);

                var bicycleTypeDto = _mapper.Map<IEnumerable<BicycleTypeDto>>(bicycleType);

                return bicycleTypeDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllTypesAsync)} service method {ex}");
                throw;
            }
        }

        public async Task<BicycleTypeDto> GetTypeAsync(Guid bicycleTypeID, bool trackChanges)
        {
            var bicycleType = await _repository.BicycleType.GetTypeAsync(bicycleTypeID, trackChanges);
            if (bicycleType == null)
                throw new BicycleTypeNotFoundException(bicycleTypeID);

            var bicycleTypeDto = _mapper.Map<BicycleTypeDto>(bicycleType);

            return bicycleTypeDto;
        }

        public async Task<BicycleTypeDto> CreateTypeAsync(TypeForCreationDto type)
        {
            var typeEntity = _mapper.Map<BicycleType>(type);

            _repository.BicycleType.CreateType(typeEntity);
            await _repository.SaveAsync();

            var typeToReturne = _mapper.Map<BicycleTypeDto>(typeEntity);

            return typeToReturne;
        }

        public async Task DeleteTypeAsync(Guid typeID, bool trackChanges)
        {
            var type = await _repository.BicycleType.GetTypeAsync(typeID, trackChanges);
            if (type is null)
                throw new BicycleTypeNotFoundException(typeID);
            _repository.BicycleType.DeleteType(type);
            await _repository.SaveAsync();
        }
    }
}
