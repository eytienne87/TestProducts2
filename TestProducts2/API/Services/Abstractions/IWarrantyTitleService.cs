using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
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
