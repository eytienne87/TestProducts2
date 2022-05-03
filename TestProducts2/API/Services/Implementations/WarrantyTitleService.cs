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

        public async Task<WarrantyTitleReadDto> CreateAsync(WarrantyTitleCreateDto titleDto)
        {
            if (titleDto == null)
                throw new BadRequestException("The format of the title DTO was invalid");

            var title = _mapper.Map<WarrantyTitle>(titleDto);

            _repositoryManager.WarrantyTitleRepository.Create(title);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<WarrantyTitleReadDto>(title);
        }

        public async Task DeleteAsync(int id)
        {
            var title = await _repositoryManager.WarrantyTitleRepository.GetByIdAsync(id);
            if (title == null)
                throw new NotFoundException($"The title with the identifier {id} could not be found");

            _repositoryManager.WarrantyTitleRepository.Delete(title);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return;
        }


        public async Task<IEnumerable<WarrantyTitleReadDto>> GetAllAsync()
        {
            var titles = await _repositoryManager.WarrantyTitleRepository.GetAllAsync();
            var mappedWarrantyTitles = _mapper.Map<IEnumerable<WarrantyTitleReadDto>>(titles);

            return mappedWarrantyTitles;
        }

        public async Task<WarrantyTitleReadDto>? GetByIdAsync(int id)
        {
            var title = await _repositoryManager.WarrantyTitleRepository.GetByIdAsync(id);

            if (title == null)
                throw new NotFoundException($"The title with the identifier {id} could not be found");

            var titleDto = _mapper.Map<WarrantyTitleReadDto>(title);

            return titleDto;
        }

        public async Task<WarrantyTitleReadDto> PartialUpdateAsync(int id, JsonPatchDocument<WarrantyTitleUpdateDto> patchDoc)
        {
            if (patchDoc == null)
                throw new BadRequestException("The Patch Document provided was invalid");

            var title = await _repositoryManager.WarrantyTitleRepository.GetByIdAsync(id);

            if (title == null)
                throw new NotFoundException($"The title with the identifier {id} could not be found");

            var titleToPatch = _mapper.Map<WarrantyTitleUpdateDto>(title);
            patchDoc.ApplyTo(titleToPatch);

            titleToPatch.Id = title.Id;
            _mapper.Map(titleToPatch, title);

            _repositoryManager.WarrantyTitleRepository.Update(title);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<WarrantyTitleReadDto>(title);
        }


        public async Task<WarrantyTitleReadDto> UpdateAsync(int id, WarrantyTitleUpdateDto titleDto)
        {
            if (titleDto == null)
                throw new BadRequestException("The WarrantyTitle DTO provided was invalid");

            var title = await _repositoryManager.WarrantyTitleRepository.GetByIdAsync(id);

            if (title == null)
                throw new NotFoundException($"The title with the identifier {id} could not be found");

            titleDto.Id = title.Id;
            _mapper.Map(titleDto, title);

            _repositoryManager.WarrantyTitleRepository.Update(title);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<WarrantyTitleReadDto>(title);
        }

    }
}