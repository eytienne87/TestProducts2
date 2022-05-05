using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IBenefitService
    {
        public Task<IEnumerable<BenefitReadDto>> GetAll();
        public Task<BenefitReadDto?> GetById(int id);
        public Task<BenefitReadDto> Create(BenefitCreateDto benefitCreateDto);
        public Task<BenefitReadDto> Update(int id, BenefitUpdateDto benefitUpdateDto);
        public Task<BenefitReadDto> PartialUpdate(int id, JsonPatchDocument<BenefitUpdateDto> patchDoc);
        public Task Delete(int id);
    }
}
