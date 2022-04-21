using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface ICategoryOfBenefitService
    {
        public IEnumerable<CategoryOfBenefitReadDto> GetAll();
        public CategoryOfBenefitReadDto GetById(int id);
        public CategoryOfBenefitReadDto Create(CategoryOfBenefitCreateDto categoryOfBenefitCreateDto);
        public CategoryOfBenefitReadDto Update(int id, CategoryOfBenefitUpdateDto categoryOfBenefitUpdateDto);
        public CategoryOfBenefitReadDto PartialUpdate(int id, JsonPatchDocument<CategoryOfBenefitUpdateDto> patchDoc);
        public void Delete(int id);
    }
}
