using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Update;

namespace TestProducts2.Services.Abstractions
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
