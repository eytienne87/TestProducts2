using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
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
