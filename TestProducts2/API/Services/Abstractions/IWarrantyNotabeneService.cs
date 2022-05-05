using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IWarrantyNotabeneService
    {
        public Task<IEnumerable<WarrantyNotabeneReadDto>> GetAll();
        public Task<WarrantyNotabeneReadDto?> GetById(int id);
        public Task<WarrantyNotabeneReadDto> Create(WarrantyNotabeneCreateDto notabeneCreateDto);
        public Task<WarrantyNotabeneReadDto> Update(int id, WarrantyNotabeneUpdateDto notabeneUpdateDto);
        public Task<WarrantyNotabeneReadDto> PartialUpdate(int id, JsonPatchDocument<WarrantyNotabeneUpdateDto> patchDoc);
        public Task Delete(int id);
    }
}
