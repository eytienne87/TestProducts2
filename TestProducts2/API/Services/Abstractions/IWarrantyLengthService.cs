using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Update;

namespace TestProducts2.Services.Abstractions
{
    public interface IWarrantyLengthService
    {
        public IEnumerable<WarrantyLengthReadDto> GetAll(LanguageClass? lang); 
        public WarrantyLengthReadDto GetById(int id, LanguageClass? lang); 
        public WarrantyLengthReadDto Create(WarrantyLengthCreateDto warrantyLengthCreateDto); 
        public WarrantyLengthReadDto Update(int id, WarrantyLengthUpdateDto warrantyLengthUpdateDto); 
        public WarrantyLengthReadDto PartialUpdate(int id, JsonPatchDocument<WarrantyLengthUpdateDto> patchDoc); 
        public void Delete(int id); 
    }
}
