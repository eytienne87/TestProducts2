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
    public class CategoryOfBenefitService : ICategoryOfBenefitService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CategoryOfBenefitService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CategoryOfBenefitReadDto> CreateAsync(CategoryOfBenefitCreateDto categoryDto)
        {
            if (categoryDto == null)
                throw new BadRequestException("The format of the category DTO was invalid");

            var category = _mapper.Map<CategoryOfBenefit>(categoryDto);

            _repositoryManager.CategoryOfBenefitRepository.Create(category);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<CategoryOfBenefitReadDto>(category);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _repositoryManager.CategoryOfBenefitRepository.GetByIdAsync(id);
            if (category == null)
                throw new NotFoundException($"The category with the identifier {id} could not be found");

            _repositoryManager.CategoryOfBenefitRepository.Delete(category);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return;
        }


        public async Task<IEnumerable<CategoryOfBenefitReadDto>> GetAllAsync()
        {
            var categories = await _repositoryManager.CategoryOfBenefitRepository.GetAllAsync();
            var mappedCategoryOfBenefits = _mapper.Map<IEnumerable<CategoryOfBenefitReadDto>>(categories);

            return mappedCategoryOfBenefits;
        }

        public async Task<CategoryOfBenefitReadDto>? GetByIdAsync(int id)
        {
            var category = await _repositoryManager.CategoryOfBenefitRepository.GetByIdAsync(id);

            if (category == null)
                throw new NotFoundException($"The category with the identifier {id} could not be found");

            var categoryDto = _mapper.Map<CategoryOfBenefitReadDto>(category);

            return categoryDto;
        }

        public async Task<CategoryOfBenefitReadDto> PartialUpdateAsync(int id, JsonPatchDocument<CategoryOfBenefitUpdateDto> patchDoc)
        {
            if (patchDoc == null)
                throw new BadRequestException("The Patch Document provided was invalid");

            var category = await _repositoryManager.CategoryOfBenefitRepository.GetByIdAsync(id);

            if (category == null)
                throw new NotFoundException($"The category with the identifier {id} could not be found");

            var categoryToPatch = _mapper.Map<CategoryOfBenefitUpdateDto>(category);
            patchDoc.ApplyTo(categoryToPatch);

            categoryToPatch.Id = category.Id;
            _mapper.Map(categoryToPatch, category);

            _repositoryManager.CategoryOfBenefitRepository.Update(category);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<CategoryOfBenefitReadDto>(category);
        }


        public async Task<CategoryOfBenefitReadDto> UpdateAsync(int id, CategoryOfBenefitUpdateDto categoryDto)
        {
            if (categoryDto == null)
                throw new BadRequestException("The CategoryOfBenefit DTO provided was invalid");

            var category = await _repositoryManager.CategoryOfBenefitRepository.GetByIdAsync(id);

            if (category == null)
                throw new NotFoundException($"The category with the identifier {id} could not be found");

            categoryDto.Id = category.Id;
            _mapper.Map(categoryDto, category);

            _repositoryManager.CategoryOfBenefitRepository.Update(category);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<CategoryOfBenefitReadDto>(category);
        }

    }
}