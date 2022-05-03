using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IWarrantyNotabeneService
    {
        public Task<IEnumerable<WarrantyNotabeneReadDto>> GetAllAsync();
        public Task<WarrantyNotabeneReadDto> GetByIdAsync(int id);
        public Task<WarrantyNotabeneReadDto> CreateAsync(WarrantyNotabeneCreateDto notaBeneCreateDto);
        public Task<WarrantyNotabeneReadDto> UpdateAsync(int id, WarrantyNotabeneUpdateDto notaBeneUpdateDto);
        public Task<WarrantyNotabeneReadDto> PartialUpdateAsync(int id, JsonPatchDocument<WarrantyNotabeneUpdateDto> patchDoc);
        public Task DeleteAsync(int id);
    }
}
