using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using API.Services.Abstractions;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.Shared;
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

        public CategoryOfBenefitReadDto Create(CategoryOfBenefitCreateDto categoryDto)
        {
            if (categoryDto == null)
                throw new Exception("The format of the category DTO was invalid");

            var category = _mapper.Map<CategoryOfBenefit>(categoryDto);

            _repositoryManager.CategoryOfBenefitRepository.Create(category);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<CategoryOfBenefitReadDto>(category);
        }

        public void Delete(int id)
        {
            var model = _repositoryManager.CategoryOfBenefitRepository.GetById(id);
            if (model == null)
            {
                throw new Exception($"The category with the identifier {id} could not be found");
            }

            _repositoryManager.CategoryOfBenefitRepository.Delete(model);
            _repositoryManager.UnitOfWork.SaveChanges();

            return;
        }


        public IEnumerable<CategoryOfBenefitReadDto> GetAll(LanguageClass? lang)
        {
            var categorys = _repositoryManager.CategoryOfBenefitRepository.GetAll();

            var mappedCategoryOfBenefits = _mapper.Map<IEnumerable<CategoryOfBenefitReadDto>>(categorys, opt => opt.Items["lang"] = lang);

            return mappedCategoryOfBenefits;
        }

        public CategoryOfBenefitReadDto GetById(int id, LanguageClass? lang)
        {
            var category = _repositoryManager.CategoryOfBenefitRepository.GetById(id);

            if (category == null)
            {
                throw new Exception($"The category with the identifier {id} could not be found");
            }

            var categoryDto = _mapper.Map<CategoryOfBenefitReadDto>(category, opt => opt.Items["lang"] = lang);

            return categoryDto;
        }

        public CategoryOfBenefitReadDto PartialUpdate(int id, JsonPatchDocument<CategoryOfBenefitUpdateDto> patchDoc)
        {
            var category = _repositoryManager.CategoryOfBenefitRepository.GetById(id);

            if (category == null)
            {
                throw new Exception($"The category with the identifier {id} could not be found");
            }

            var categoryToPatch = _mapper.Map<CategoryOfBenefitUpdateDto>(category);
            patchDoc.ApplyTo(categoryToPatch);

            categoryToPatch.Id = category.Id;
            _mapper.Map(categoryToPatch, category);

            _repositoryManager.CategoryOfBenefitRepository.Update(category);

            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<CategoryOfBenefitReadDto>(category);
        }


        public CategoryOfBenefitReadDto Update(int id, CategoryOfBenefitUpdateDto categoryDto)
        {
            if (categoryDto == null)
                throw new Exception("The format of the category DTO was invalid");

            var category = _repositoryManager.CategoryOfBenefitRepository.GetById(id);

            if (category == null)
            {
                throw new Exception($"The category with the identifier {id} could not be found");
            }

            categoryDto.Id = category.Id;
            _mapper.Map(categoryDto, category);

            _repositoryManager.CategoryOfBenefitRepository.Update(category);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<CategoryOfBenefitReadDto>(category);
        }
    }
}
