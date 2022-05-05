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

        public async Task<WarrantyNotabeneReadDto> Create(WarrantyNotabeneCreateDto notabeneDto)
        {
            if (notabeneDto == null)
                throw new BadRequestException("The format of the notabene DTO was invalid");

            var notabene = _mapper.Map<WarrantyNotabene>(notabeneDto);

            _repositoryManager.WarrantyNotabeneRepository.Create(notabene);
            await _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyNotabeneReadDto>(notabene);
        }

        public async Task Delete(int id)
        {
            var notabene = await _repositoryManager.WarrantyNotabeneRepository.GetById(id);
            if (notabene == null)
                throw new NotFoundException($"The notabene with the identifier {id} could not be found");

            _repositoryManager.WarrantyNotabeneRepository.Delete(notabene);
            await _repositoryManager.UnitOfWork.SaveChanges();

            return;
        }


        public async Task<IEnumerable<WarrantyNotabeneReadDto>> GetAll()
        {
            var notabenes = await _repositoryManager.WarrantyNotabeneRepository.GetAll();
            var mappedWarrantyNotabenes = _mapper.Map<IEnumerable<WarrantyNotabeneReadDto>>(notabenes);

            return mappedWarrantyNotabenes;
        }

        public async Task<WarrantyNotabeneReadDto?> GetById(int id)
        {
            var notabene = await _repositoryManager.WarrantyNotabeneRepository.GetById(id);

            if (notabene == null)
                throw new NotFoundException($"The notabene with the identifier {id} could not be found");

            var notabeneDto = _mapper.Map<WarrantyNotabeneReadDto>(notabene);

            return notabeneDto;
        }

        public async Task<WarrantyNotabeneReadDto> PartialUpdate(int id, JsonPatchDocument<WarrantyNotabeneUpdateDto> patchDoc)
        {
            if (patchDoc == null)
                throw new BadRequestException("The Patch Document provided was invalid");

            var notabene = await _repositoryManager.WarrantyNotabeneRepository.GetById(id);

            if (notabene == null)
                throw new NotFoundException($"The notabene with the identifier {id} could not be found");

            var notabeneToPatch = _mapper.Map<WarrantyNotabeneUpdateDto>(notabene);
            patchDoc.ApplyTo(notabeneToPatch);

            notabeneToPatch.Id = notabene.Id;
            _mapper.Map(notabeneToPatch, notabene);

            _repositoryManager.WarrantyNotabeneRepository.Update(notabene);

            await _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyNotabeneReadDto>(notabene);
        }


        public async Task<WarrantyNotabeneReadDto> Update(int id, WarrantyNotabeneUpdateDto notabeneDto)
        {
            if (notabeneDto == null)
                throw new BadRequestException("The WarrantyNotabene DTO provided was invalid");

            var notabene = await _repositoryManager.WarrantyNotabeneRepository.GetById(id);

            if (notabene == null)
                throw new NotFoundException($"The notabene with the identifier {id} could not be found");

            notabeneDto.Id = notabene.Id;
            _mapper.Map(notabeneDto, notabene);

            _repositoryManager.WarrantyNotabeneRepository.Update(notabene);
            await _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyNotabeneReadDto>(notabene);
        }

    }
}