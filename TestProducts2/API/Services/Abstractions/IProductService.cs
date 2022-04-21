using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IProductService
    {
        public IEnumerable<ProductReadDto> GetAll(LanguageClass? lang);
        public ProductReadDto GetById(int id, LanguageClass? lang);
        public ProductReadDto Create(ProductCreateDto productCreateDto);
        public ProductReadDto Update(int id, ProductUpdateDto productUpdateDto);
        public ProductReadDto PartialUpdate(int id, JsonPatchDocument<ProductUpdateDto> patchDoc);
        public void Delete(int id);
    }
}
