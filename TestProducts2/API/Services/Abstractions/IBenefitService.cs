using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IBenefitService
    {
        public Task<IEnumerable<BenefitReadDto>> GetAllAsync();
        public Task<BenefitReadDto> GetByIdAsync(int id);
        public Task<BenefitReadDto> CreateAsync(BenefitCreateDto benefitCreateDto);
        public Task<BenefitReadDto> UpdateAsync(int id, BenefitUpdateDto benefitUpdateDto);
        public Task<BenefitReadDto> PartialUpdateAsync(int id, JsonPatchDocument<BenefitUpdateDto> patchDoc);
        public Task DeleteAsync(int id);
    }
}
