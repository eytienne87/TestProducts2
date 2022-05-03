using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IWarrantyLengthService
    {
        public Task<IEnumerable<WarrantyLengthReadDto>> GetAllAsync();
        public Task<WarrantyLengthReadDto> GetByIdAsync(int id);
        public Task<WarrantyLengthReadDto> CreateAsync(WarrantyLengthCreateDto lengthCreateDto);
        public Task<WarrantyLengthReadDto> UpdateAsync(int id, WarrantyLengthUpdateDto lengthUpdateDto);
        public Task<WarrantyLengthReadDto> PartialUpdateAsync(int id, JsonPatchDocument<WarrantyLengthUpdateDto> patchDoc);
        public Task DeleteAsync(int id);
    }
}
