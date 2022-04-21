using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Abstractions
{
    public interface IMarketSegmentService
    {
        public IEnumerable<MarketSegmentReadDto> GetAll(LanguageClass? lang);
        public MarketSegmentReadDto GetById(int id, LanguageClass? lang);
        public MarketSegmentReadDto Create(MarketSegmentCreateDto marketSegmentCreateDto);
        public MarketSegmentReadDto Update(int id, MarketSegmentUpdateDto marketSegmentUpdateDto);
        public MarketSegmentReadDto PartialUpdate(int id, JsonPatchDocument<MarketSegmentUpdateDto> patchDoc);
        public void Delete(int id);
    }
}
