using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IMarketSegmentService
    {
        public Task<IEnumerable<MarketSegmentReadDto>> GetAll();
        public Task<MarketSegmentReadDto?> GetById(int id);
        public Task<MarketSegmentReadDto> Create(MarketSegmentCreateDto marketCreateDto);
        public Task<MarketSegmentReadDto> Update(int id, MarketSegmentUpdateDto marketUpdateDto);
        public Task<MarketSegmentReadDto> PartialUpdate(int id, JsonPatchDocument<MarketSegmentUpdateDto> patchDoc);
        public Task Delete(int id);
    }
}
