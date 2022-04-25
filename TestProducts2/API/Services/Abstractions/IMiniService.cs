using API.Dtos.Read;

namespace API.Services.Abstractions
{
    public interface IMiniService
    {
        public IEnumerable<ProductMiniReadDto> GetAll();
    }
}
