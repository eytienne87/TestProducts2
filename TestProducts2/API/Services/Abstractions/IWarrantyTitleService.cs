using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IWarrantyTitleService
    {
        public Task<IEnumerable<WarrantyTitleReadDto>> GetAll();
        public Task<WarrantyTitleReadDto?> GetById(int id);
        public Task<WarrantyTitleReadDto> Create(WarrantyTitleCreateDto titleCreateDto);
        public Task<WarrantyTitleReadDto> Update(int id, WarrantyTitleUpdateDto titleUpdateDto);
        public Task<WarrantyTitleReadDto> PartialUpdate(int id, JsonPatchDocument<WarrantyTitleUpdateDto> patchDoc);
        public Task Delete(int id);
    }
}
