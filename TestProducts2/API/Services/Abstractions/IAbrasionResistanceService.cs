using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IAbrasionResistanceService
    {
        public Task<IEnumerable<AbrasionResistanceReadDto>> GetAll();
        public Task<AbrasionResistanceReadDto?> GetById(int id);
        public Task<AbrasionResistanceReadDto> Create(AbrasionResistanceCreateDto abrasionCreateDto);
        public Task<AbrasionResistanceReadDto> Update(int id, AbrasionResistanceUpdateDto abrasionUpdateDto);
        public Task<AbrasionResistanceReadDto> PartialUpdate(int id, JsonPatchDocument<AbrasionResistanceUpdateDto> patchDoc);
        public Task Delete(int id);
    }
}
