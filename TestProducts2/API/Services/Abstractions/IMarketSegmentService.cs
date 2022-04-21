using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IMarketSegmentService
    {
        public IEnumerable<MarketSegmentReadDto> GetAll();
        public MarketSegmentReadDto GetById(int id);
        public MarketSegmentReadDto Create(MarketSegmentCreateDto marketSegmentCreateDto);
        public MarketSegmentReadDto Update(int id, MarketSegmentUpdateDto marketSegmentUpdateDto);
        public MarketSegmentReadDto PartialUpdate(int id, JsonPatchDocument<MarketSegmentUpdateDto> patchDoc);
        public void Delete(int id);
    }
}
