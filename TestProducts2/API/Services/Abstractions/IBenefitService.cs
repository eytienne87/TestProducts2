using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IBenefitService
    {
        public IEnumerable<BenefitReadDto> GetAll(LanguageClass? lang);
        public BenefitReadDto GetById(int id, LanguageClass? lang);
        public BenefitReadDto Create(BenefitCreateDto benefitCreateDto);
        public BenefitReadDto Update(int id, BenefitUpdateDto benefitUpdateDto);
        public BenefitReadDto PartialUpdate(int id, JsonPatchDocument<BenefitUpdateDto> patchDoc);
        public void Delete(int id);
    }
}
