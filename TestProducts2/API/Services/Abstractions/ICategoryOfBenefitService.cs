using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface ICategoryOfBenefitService
    {
        public Task<IEnumerable<BenefitCategoryReadDto>> GetAll();
        public Task<BenefitCategoryReadDto?> GetById(int id);
        public Task<BenefitCategoryReadDto> Create(CategoryOfBenefitCreateDto categoryCreateDto);
        public Task<BenefitCategoryReadDto> Update(int id, CategoryOfBenefitUpdateDto categoryUpdateDto);
        public Task<BenefitCategoryReadDto> PartialUpdate(int id, JsonPatchDocument<CategoryOfBenefitUpdateDto> patchDoc);
        public Task Delete(int id);
    }
}
