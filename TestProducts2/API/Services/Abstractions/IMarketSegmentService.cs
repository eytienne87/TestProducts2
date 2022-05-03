using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IMarketSegmentService
    {
        public Task<IEnumerable<MarketSegmentReadDto>> GetAllAsync();
        public Task<MarketSegmentReadDto> GetByIdAsync(int id);
        public Task<MarketSegmentReadDto> CreateAsync(MarketSegmentCreateDto segmentCreateDto);
        public Task<MarketSegmentReadDto> UpdateAsync(int id, MarketSegmentUpdateDto segmentUpdateDto);
        public Task<MarketSegmentReadDto> PartialUpdateAsync(int id, JsonPatchDocument<MarketSegmentUpdateDto> patchDoc);
        public Task DeleteAsync(int id);
    }
}
