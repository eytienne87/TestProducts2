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
    public class WarrantyTitleService : IWarrantyTitleService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public WarrantyTitleService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public WarrantyTitleReadDto Create(WarrantyTitleCreateDto warrantyTitleDto)
        {
            if (warrantyTitleDto == null)
                throw new BadRequestException("The format of the warrantyTitle DTO was invalid");

            var warrantyTitle = _mapper.Map<WarrantyTitle>(warrantyTitleDto);

            _repositoryManager.WarrantyTitleRepository.Create(warrantyTitle);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyTitleReadDto>(warrantyTitle);
        }

        public void Delete(int id)
        {
            var warrantyTitle = _repositoryManager.WarrantyTitleRepository.GetById(id);
            if (warrantyTitle == null)
                throw new NotFoundException($"The warrantyTitle with the identifier {id} could not be found");

            _repositoryManager.WarrantyTitleRepository.Delete(warrantyTitle);
            _repositoryManager.UnitOfWork.SaveChanges();

            return;
        }


        public IEnumerable<WarrantyTitleReadDto> GetAll()
        {
            var warrantyTitles = _repositoryManager.WarrantyTitleRepository.GetAll();
            var mappedWarrantyTitles = _mapper.Map<IEnumerable<WarrantyTitleReadDto>>(warrantyTitles);

            return mappedWarrantyTitles;
        }

        public WarrantyTitleReadDto? GetById(int id)
        {
            var warrantyTitle = _repositoryManager.WarrantyTitleRepository.GetById(id);

            if (warrantyTitle == null)
                throw new NotFoundException($"The warrantyTitle with the identifier {id} could not be found");

            var warrantyTitleDto = _mapper.Map<WarrantyTitleReadDto>(warrantyTitle);

            return warrantyTitleDto;
        }

        public WarrantyTitleReadDto PartialUpdate(int id, JsonPatchDocument<WarrantyTitleUpdateDto> patchDoc)
        {
            if (patchDoc == null)
                throw new BadRequestException("The Patch Document provided was invalid");

            var warrantyTitle = _repositoryManager.WarrantyTitleRepository.GetById(id);

            if (warrantyTitle == null)
                throw new NotFoundException($"The warrantyTitle with the identifier {id} could not be found");

            var warrantyTitleToPatch = _mapper.Map<WarrantyTitleUpdateDto>(warrantyTitle);
            patchDoc.ApplyTo(warrantyTitleToPatch);

            warrantyTitleToPatch.Id = warrantyTitle.Id;
            _mapper.Map(warrantyTitleToPatch, warrantyTitle);

            _repositoryManager.WarrantyTitleRepository.Update(warrantyTitle);

            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyTitleReadDto>(warrantyTitle);
        }


        public WarrantyTitleReadDto Update(int id, WarrantyTitleUpdateDto warrantyTitleDto)
        {
            if (warrantyTitleDto == null)
                throw new BadRequestException("The WarrantyTitle DTO provided was invalid");

            var warrantyTitle = _repositoryManager.WarrantyTitleRepository.GetById(id);

            if (warrantyTitle == null)
                throw new NotFoundException($"The warrantyTitle with the identifier {id} could not be found");

            warrantyTitleDto.Id = warrantyTitle.Id;
            _mapper.Map(warrantyTitleDto, warrantyTitle);

            _repositoryManager.WarrantyTitleRepository.Update(warrantyTitle);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyTitleReadDto>(warrantyTitle);
        }

    }
}