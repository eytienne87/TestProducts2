using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface ICategoryOfBenefitService
    {
        public Task<IEnumerable<CategoryOfBenefitReadDto>> GetAll();
        public Task<CategoryOfBenefitReadDto?> GetById(int id);
        public Task<CategoryOfBenefitReadDto> Create(CategoryOfBenefitCreateDto categoryCreateDto);
        public Task<CategoryOfBenefitReadDto> Update(int id, CategoryOfBenefitUpdateDto categoryUpdateDto);
        public Task<CategoryOfBenefitReadDto> PartialUpdate(int id, JsonPatchDocument<CategoryOfBenefitUpdateDto> patchDoc);
        public Task Delete(int id);
    }
}
