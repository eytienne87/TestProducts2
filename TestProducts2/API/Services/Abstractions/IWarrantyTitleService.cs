using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IWarrantyTitleService
    {
        public Task<IEnumerable<WarrantyTitleReadDto>> GetAllAsync();
        public Task<WarrantyTitleReadDto> GetByIdAsync(int id);
        public Task<WarrantyTitleReadDto> CreateAsync(WarrantyTitleCreateDto titleCreateDto);
        public Task<WarrantyTitleReadDto> UpdateAsync(int id, WarrantyTitleUpdateDto titleUpdateDto);
        public Task<WarrantyTitleReadDto> PartialUpdateAsync(int id, JsonPatchDocument<WarrantyTitleUpdateDto> patchDoc);
        public Task DeleteAsync(int id);
    }
}

