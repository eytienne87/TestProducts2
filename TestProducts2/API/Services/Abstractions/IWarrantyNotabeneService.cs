using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Update;

namespace TestProducts2.Services.Abstractions
{
    public interface IWarrantyNotabeneService
    {
        public IEnumerable<WarrantyNotabeneReadDto> GetAll(LanguageClass? lang); 
        public WarrantyNotabeneReadDto GetById(int id, LanguageClass? lang); 
        public WarrantyNotabeneReadDto Create(WarrantyNotabeneCreateDto warrantyNotabeneCreateDto); 
        public WarrantyNotabeneReadDto Update(int id, WarrantyNotabeneUpdateDto warrantyNotabeneUpdateDto); 
        public WarrantyNotabeneReadDto PartialUpdate(int id, JsonPatchDocument<WarrantyNotabeneUpdateDto> patchDoc); 
        public void Delete(int id); 
    }
}
