using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductReadDto>> GetAll();
        public Task<ProductReadDto> GetById(int id);
        public Task<ProductReadDto> Create(ProductCreateDto productCreateDto);
        public Task<ProductReadDto> Update(int id, ProductUpdateDto productUpdateDto);
        public Task<ProductReadDto> PartialUpdate(int id, JsonPatchDocument<ProductUpdateDto> patchDoc);
        public Task Delete(int id);
    }
}
