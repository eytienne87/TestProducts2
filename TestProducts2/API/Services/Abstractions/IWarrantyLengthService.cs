using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IWarrantyLengthService
    {
        public IEnumerable<WarrantyLengthReadDto> GetAll();
        public WarrantyLengthReadDto GetById(int id);
        public WarrantyLengthReadDto Create(WarrantyLengthCreateDto warrantyLengthCreateDto);
        public WarrantyLengthReadDto Update(int id, WarrantyLengthUpdateDto warrantyLengthUpdateDto);
        public WarrantyLengthReadDto PartialUpdate(int id, JsonPatchDocument<WarrantyLengthUpdateDto> patchDoc);
        public void Delete(int id);
    }
}
