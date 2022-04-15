using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Update;

namespace TestProducts2.Services.Abstractions
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
