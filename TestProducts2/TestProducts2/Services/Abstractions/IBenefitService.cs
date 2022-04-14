using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Update;

namespace TestProducts2.Services.Abstractions
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
