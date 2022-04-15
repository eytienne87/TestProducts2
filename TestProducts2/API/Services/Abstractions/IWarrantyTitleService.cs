using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Update;

namespace TestProducts2.Services.Abstractions
{
    public interface IWarrantyTitleService
    {
        public IEnumerable<WarrantyTitleReadDto> GetAll(LanguageClass? lang); 
        public WarrantyTitleReadDto GetById(int id, LanguageClass? lang); 
        public WarrantyTitleReadDto Create(WarrantyTitleCreateDto warrantyTitleCreateDto); 
        public WarrantyTitleReadDto Update(int id, WarrantyTitleUpdateDto warrantyTitleUpdateDto); 
        public WarrantyTitleReadDto PartialUpdate(int id, JsonPatchDocument<WarrantyTitleUpdateDto> patchDoc); 
        public void Delete(int id); 
    }
}
