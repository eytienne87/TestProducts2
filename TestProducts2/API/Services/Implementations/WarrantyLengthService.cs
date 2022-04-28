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

        public WarrantyLengthReadDto Create(WarrantyLengthCreateDto warrantyLengthDto)
        {
            if (warrantyLengthDto == null)
                throw new BadRequestException("The format of the warrantyLength DTO was invalid");

            var warrantyLength = _mapper.Map<WarrantyLength>(warrantyLengthDto);

            _repositoryManager.WarrantyLengthRepository.Create(warrantyLength);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyLengthReadDto>(warrantyLength);
        }

        public void Delete(int id)
        {
            var warrantyLength = _repositoryManager.WarrantyLengthRepository.GetById(id);
            if (warrantyLength == null)
                throw new NotFoundException($"The warrantyLength with the identifier {id} could not be found");

            _repositoryManager.WarrantyLengthRepository.Delete(warrantyLength);
            _repositoryManager.UnitOfWork.SaveChanges();

            return;
        }


        public IEnumerable<WarrantyLengthReadDto> GetAll()
        {
            var warrantyLengths = _repositoryManager.WarrantyLengthRepository.GetAll();
            var mappedWarrantyLengths = _mapper.Map<IEnumerable<WarrantyLengthReadDto>>(warrantyLengths);

            return mappedWarrantyLengths;
        }

        public WarrantyLengthReadDto? GetById(int id)
        {
            var warrantyLength = _repositoryManager.WarrantyLengthRepository.GetById(id);

            if (warrantyLength == null)
                throw new NotFoundException($"The warrantyLength with the identifier {id} could not be found");

            var warrantyLengthDto = _mapper.Map<WarrantyLengthReadDto>(warrantyLength);

            return warrantyLengthDto;
        }

        public WarrantyLengthReadDto PartialUpdate(int id, JsonPatchDocument<WarrantyLengthUpdateDto> patchDoc)
        {
            if (patchDoc == null)
                throw new BadRequestException("The Patch Document provided was invalid");

            var warrantyLength = _repositoryManager.WarrantyLengthRepository.GetById(id);

            if (warrantyLength == null)
                throw new NotFoundException($"The warrantyLength with the identifier {id} could not be found");

            var warrantyLengthToPatch = _mapper.Map<WarrantyLengthUpdateDto>(warrantyLength);
            patchDoc.ApplyTo(warrantyLengthToPatch);

            warrantyLengthToPatch.Id = warrantyLength.Id;
            _mapper.Map(warrantyLengthToPatch, warrantyLength);

            _repositoryManager.WarrantyLengthRepository.Update(warrantyLength);

            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyLengthReadDto>(warrantyLength);
        }


        public WarrantyLengthReadDto Update(int id, WarrantyLengthUpdateDto warrantyLengthDto)
        {
            if (warrantyLengthDto == null)
                throw new BadRequestException("The WarrantyLength DTO provided was invalid");

            var warrantyLength = _repositoryManager.WarrantyLengthRepository.GetById(id);

            if (warrantyLength == null)
                throw new NotFoundException($"The warrantyLength with the identifier {id} could not be found");

            warrantyLengthDto.Id = warrantyLength.Id;
            _mapper.Map(warrantyLengthDto, warrantyLength);

            _repositoryManager.WarrantyLengthRepository.Update(warrantyLength);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyLengthReadDto>(warrantyLength);
        }

    }
}