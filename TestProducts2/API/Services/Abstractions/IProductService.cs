using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductReadDto>> GetAllAsync();
        public Task<ProductReadDto> GetByIdAsync(int id);
        public Task<ProductReadDto> CreateAsync(ProductCreateDto productCreateDto);
        public Task<ProductReadDto> UpdateAsync(int id, ProductUpdateDto productUpdateDto);
        public Task<ProductReadDto> PartialUpdateAsync(int id, JsonPatchDocument<ProductUpdateDto> patchDoc);
        public Task DeleteAsync(int id);
    }
}
