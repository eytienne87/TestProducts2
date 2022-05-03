using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface ICategoryOfBenefitService
    {
        public Task<IEnumerable<CategoryOfBenefitReadDto>> GetAllAsync();
        public Task<CategoryOfBenefitReadDto> GetByIdAsync(int id);
        public Task<CategoryOfBenefitReadDto> CreateAsync(CategoryOfBenefitCreateDto categoryCreateDto);
        public Task<CategoryOfBenefitReadDto> UpdateAsync(int id, CategoryOfBenefitUpdateDto categoryUpdateDto);
        public Task<CategoryOfBenefitReadDto> PartialUpdateAsync(int id, JsonPatchDocument<CategoryOfBenefitUpdateDto> patchDoc);
        public Task DeleteAsync(int id);
    }
}
