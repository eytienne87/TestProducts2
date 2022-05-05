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
    public class WarrantyLengthService : IWarrantyLengthService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public WarrantyLengthService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<WarrantyLengthReadDto> Create(WarrantyLengthCreateDto lengthDto)
        {
            if (lengthDto == null)
                throw new BadRequestException("The format of the length DTO was invalid");

            var length = _mapper.Map<WarrantyLength>(lengthDto);

            _repositoryManager.WarrantyLengthRepository.Create(length);
            await _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyLengthReadDto>(length);
        }

        public async Task Delete(int id)
        {
            var length = await _repositoryManager.WarrantyLengthRepository.GetById(id);
            if (length == null)
                throw new NotFoundException($"The length with the identifier {id} could not be found");

            _repositoryManager.WarrantyLengthRepository.Delete(length);
            await _repositoryManager.UnitOfWork.SaveChanges();

            return;
        }


        public async Task<IEnumerable<WarrantyLengthReadDto>> GetAll()
        {
            var lengths = await _repositoryManager.WarrantyLengthRepository.GetAll();
            var mappedWarrantyLengths = _mapper.Map<IEnumerable<WarrantyLengthReadDto>>(lengths);

            return mappedWarrantyLengths;
        }

        public async Task<WarrantyLengthReadDto?> GetById(int id)
        {
            var length = await _repositoryManager.WarrantyLengthRepository.GetById(id);

            if (length == null)
                throw new NotFoundException($"The length with the identifier {id} could not be found");

            var lengthDto = _mapper.Map<WarrantyLengthReadDto>(length);

            return lengthDto;
        }

        public async Task<WarrantyLengthReadDto> PartialUpdate(int id, JsonPatchDocument<WarrantyLengthUpdateDto> patchDoc)
        {
            if (patchDoc == null)
                throw new BadRequestException("The Patch Document provided was invalid");

            var length = await _repositoryManager.WarrantyLengthRepository.GetById(id);

            if (length == null)
                throw new NotFoundException($"The length with the identifier {id} could not be found");

            var lengthToPatch = _mapper.Map<WarrantyLengthUpdateDto>(length);
            patchDoc.ApplyTo(lengthToPatch);

            lengthToPatch.Id = length.Id;
            _mapper.Map(lengthToPatch, length);

            _repositoryManager.WarrantyLengthRepository.Update(length);

            await _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyLengthReadDto>(length);
        }


        public async Task<WarrantyLengthReadDto> Update(int id, WarrantyLengthUpdateDto lengthDto)
        {
            if (lengthDto == null)
                throw new BadRequestException("The WarrantyLength DTO provided was invalid");

            var length = await _repositoryManager.WarrantyLengthRepository.GetById(id);

            if (length == null)
                throw new NotFoundException($"The length with the identifier {id} could not be found");

            lengthDto.Id = length.Id;
            _mapper.Map(lengthDto, length);

            _repositoryManager.WarrantyLengthRepository.Update(length);
            await _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyLengthReadDto>(length);
        }

    }
}