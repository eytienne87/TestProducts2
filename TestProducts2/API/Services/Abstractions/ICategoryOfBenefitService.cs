using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Update;

namespace TestProducts2.Services.Abstractions
{
    public interface ICategoryOfBenefitService
    {
        public IEnumerable<CategoryOfBenefitReadDto> GetAll(LanguageClass? lang); 
        public CategoryOfBenefitReadDto GetById(int id, LanguageClass? lang); 
        public CategoryOfBenefitReadDto Create(CategoryOfBenefitCreateDto categoryOfBenefitCreateDto); 
        public CategoryOfBenefitReadDto Update(int id, CategoryOfBenefitUpdateDto categoryOfBenefitUpdateDto); 
        public CategoryOfBenefitReadDto PartialUpdate(int id, JsonPatchDocument<CategoryOfBenefitUpdateDto> patchDoc); 
        public void Delete(int id); 
    }
}
