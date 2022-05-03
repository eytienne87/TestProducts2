using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IAbrasionResistanceService
    {
        public Task<IEnumerable<AbrasionResistanceReadDto>> GetAllAsync();
        public Task<AbrasionResistanceReadDto> GetByIdAsync(int id);
        public Task<AbrasionResistanceReadDto> CreateAsync(AbrasionResistanceCreateDto abrasionCreateDto);
        public Task<AbrasionResistanceReadDto> UpdateAsync(int id, AbrasionResistanceUpdateDto abrasionUpdateDto);
        public Task<AbrasionResistanceReadDto> PartialUpdateAsync(int id, JsonPatchDocument<AbrasionResistanceUpdateDto> patchDoc);
        public Task DeleteAsync(int id);
    }
}
