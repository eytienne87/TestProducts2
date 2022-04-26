using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IAbrasionResistanceService
    {
        public IEnumerable<AbrasionResistanceReadDto> GetAll();
        public AbrasionResistanceReadDto? GetById(int id);
        public AbrasionResistanceReadDto Create(AbrasionResistanceCreateDto abrasionCreateDto);
        public AbrasionResistanceReadDto Update(int id, AbrasionResistanceUpdateDto abrasionUpdateDto);
        public AbrasionResistanceReadDto PartialUpdate(int id, JsonPatchDocument<AbrasionResistanceUpdateDto> patchDoc);
        public void Delete(int id);
    }
}
