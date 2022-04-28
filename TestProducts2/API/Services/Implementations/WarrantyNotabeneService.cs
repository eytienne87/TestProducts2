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
    public class WarrantyNotabeneService : IWarrantyNotabeneService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public WarrantyNotabeneService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public WarrantyNotabeneReadDto Create(WarrantyNotabeneCreateDto warrantyNotabeneDto)
        {
            if (warrantyNotabeneDto == null)
                throw new BadRequestException("The format of the warrantyNotabene DTO was invalid");

            var warrantyNotabene = _mapper.Map<WarrantyNotabene>(warrantyNotabeneDto);

            _repositoryManager.WarrantyNotabeneRepository.Create(warrantyNotabene);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyNotabeneReadDto>(warrantyNotabene);
        }

        public void Delete(int id)
        {
            var warrantyNotabene = _repositoryManager.WarrantyNotabeneRepository.GetById(id);
            if (warrantyNotabene == null)
                throw new NotFoundException($"The warrantyNotabene with the identifier {id} could not be found");

            _repositoryManager.WarrantyNotabeneRepository.Delete(warrantyNotabene);
            _repositoryManager.UnitOfWork.SaveChanges();

            return;
        }


        public IEnumerable<WarrantyNotabeneReadDto> GetAll()
        {
            var warrantyNotabenes = _repositoryManager.WarrantyNotabeneRepository.GetAll();
            var mappedWarrantyNotabenes = _mapper.Map<IEnumerable<WarrantyNotabeneReadDto>>(warrantyNotabenes);

            return mappedWarrantyNotabenes;
        }

        public WarrantyNotabeneReadDto? GetById(int id)
        {
            var warrantyNotabene = _repositoryManager.WarrantyNotabeneRepository.GetById(id);

            if (warrantyNotabene == null)
                throw new NotFoundException($"The warrantyNotabene with the identifier {id} could not be found");

            var warrantyNotabeneDto = _mapper.Map<WarrantyNotabeneReadDto>(warrantyNotabene);

            return warrantyNotabeneDto;
        }

        public WarrantyNotabeneReadDto PartialUpdate(int id, JsonPatchDocument<WarrantyNotabeneUpdateDto> patchDoc)
        {
            if (patchDoc == null)
                throw new BadRequestException("The Patch Document provided was invalid");

            var warrantyNotabene = _repositoryManager.WarrantyNotabeneRepository.GetById(id);

            if (warrantyNotabene == null)
                throw new NotFoundException($"The warrantyNotabene with the identifier {id} could not be found");

            var warrantyNotabeneToPatch = _mapper.Map<WarrantyNotabeneUpdateDto>(warrantyNotabene);
            patchDoc.ApplyTo(warrantyNotabeneToPatch);

            warrantyNotabeneToPatch.Id = warrantyNotabene.Id;
            _mapper.Map(warrantyNotabeneToPatch, warrantyNotabene);

            _repositoryManager.WarrantyNotabeneRepository.Update(warrantyNotabene);

            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyNotabeneReadDto>(warrantyNotabene);
        }


        public WarrantyNotabeneReadDto Update(int id, WarrantyNotabeneUpdateDto warrantyNotabeneDto)
        {
            if (warrantyNotabeneDto == null)
                throw new BadRequestException("The WarrantyNotabene DTO provided was invalid");

            var warrantyNotabene = _repositoryManager.WarrantyNotabeneRepository.GetById(id);

            if (warrantyNotabene == null)
                throw new NotFoundException($"The warrantyNotabene with the identifier {id} could not be found");

            warrantyNotabeneDto.Id = warrantyNotabene.Id;
            _mapper.Map(warrantyNotabeneDto, warrantyNotabene);

            _repositoryManager.WarrantyNotabeneRepository.Update(warrantyNotabene);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyNotabeneReadDto>(warrantyNotabene);
        }

    }
}