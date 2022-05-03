using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using API.Services.Abstractions;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Implementations
{
    public class AbrasionResistanceService : IAbrasionResistanceService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AbrasionResistanceService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<AbrasionResistanceReadDto> CreateAsync(AbrasionResistanceCreateDto abrasionDto)
        {
            if (abrasionDto == null)
                throw new BadRequestException("The format of the abrasion DTO was invalid");

            var abrasion = _mapper.Map<AbrasionResistance>(abrasionDto);

            _repositoryManager.AbrasionResistanceRepository.Create(abrasion);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<AbrasionResistanceReadDto>(abrasion);
        }

        public async Task DeleteAsync(int id)
        {
            var abrasion = await _repositoryManager.AbrasionResistanceRepository.GetByIdAsync(id);
            if (abrasion == null)
                throw new NotFoundException($"The abrasion with the identifier {id} could not be found");

            _repositoryManager.AbrasionResistanceRepository.Delete(abrasion);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return;
        }


        public async Task<IEnumerable<AbrasionResistanceReadDto>> GetAllAsync()
        {
            var abrasions = await _repositoryManager.AbrasionResistanceRepository.GetAllAsync();
            var mappedAbrasionResistances = _mapper.Map<IEnumerable<AbrasionResistanceReadDto>>(abrasions);

            return mappedAbrasionResistances;
        }

        public async Task<AbrasionResistanceReadDto>? GetByIdAsync(int id)
        {
            var abrasion = await _repositoryManager.AbrasionResistanceRepository.GetByIdAsync(id);

            if (abrasion == null)
                throw new NotFoundException($"The abrasion with the identifier {id} could not be found");

            var abrasionDto = _mapper.Map<AbrasionResistanceReadDto>(abrasion);

            return abrasionDto;
        }

        public async Task<AbrasionResistanceReadDto> PartialUpdateAsync(int id, JsonPatchDocument<AbrasionResistanceUpdateDto> patchDoc)
        {
            if (patchDoc == null)
                throw new BadRequestException("The Patch Document provided was invalid");

            var abrasion = await _repositoryManager.AbrasionResistanceRepository.GetByIdAsync(id);

            if (abrasion == null)
                throw new NotFoundException($"The abrasion with the identifier {id} could not be found");

            var abrasionToPatch = _mapper.Map<AbrasionResistanceUpdateDto>(abrasion);
            patchDoc.ApplyTo(abrasionToPatch);

            abrasionToPatch.Id = abrasion.Id;
            _mapper.Map(abrasionToPatch, abrasion);

            _repositoryManager.AbrasionResistanceRepository.Update(abrasion);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<AbrasionResistanceReadDto>(abrasion);
        }


        public async Task<AbrasionResistanceReadDto> UpdateAsync(int id, AbrasionResistanceUpdateDto abrasionDto)
        {
            if (abrasionDto == null)
                throw new BadRequestException("The AbrasionResistance DTO provided was invalid");

            var abrasion = await _repositoryManager.AbrasionResistanceRepository.GetByIdAsync(id);

            if (abrasion == null)
                throw new NotFoundException($"The abrasion with the identifier {id} could not be found");

            abrasionDto.Id = abrasion.Id;
            _mapper.Map(abrasionDto, abrasion);

            _repositoryManager.AbrasionResistanceRepository.Update(abrasion);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<AbrasionResistanceReadDto>(abrasion);
        }

    }
}