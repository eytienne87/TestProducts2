using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IWarrantyLengthService
    {
        public Task<IEnumerable<WarrantyLengthReadDto>> GetAll();
        public Task<WarrantyLengthReadDto?> GetById(int id);
        public Task<WarrantyLengthReadDto> Create(WarrantyLengthCreateDto lengthCreateDto);
        public Task<WarrantyLengthReadDto> Update(int id, WarrantyLengthUpdateDto lengthUpdateDto);
        public Task<WarrantyLengthReadDto> PartialUpdate(int id, JsonPatchDocument<WarrantyLengthUpdateDto> patchDoc);
        public Task Delete(int id);
    }
}
