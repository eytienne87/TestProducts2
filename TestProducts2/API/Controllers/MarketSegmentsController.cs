using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using API.Services.Abstractions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketSegmentsController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public MarketSegmentsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/MarketSegments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketSegmentReadDto>>> GetAll()
        {
            var segments = await _serviceManager.MarketSegmentService.GetAllAsync();
            return Ok(segments);
        }

        // GET api/MarketSegments/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketSegmentReadDto>> GetById(int id)
        {
            var segmentReadDto = await _serviceManager.MarketSegmentService.GetByIdAsync(id);

            return Ok(segmentReadDto);
        }

        //POST api/MarketSegments
        [HttpPost]
        public async Task<ActionResult<MarketSegmentReadDto>> Create(MarketSegmentCreateDto segmentDto)
        {
            return Ok(await _serviceManager.MarketSegmentService.CreateAsync(segmentDto));
        }

        // PUT api/MarketSegments/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<MarketSegmentReadDto>> Update(int id, MarketSegmentUpdateDto segmentDto)
        {
            return Ok(await _serviceManager.MarketSegmentService.UpdateAsync(id, segmentDto));
        }

        // PATCH api/MarketSegments/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult<MarketSegmentReadDto>> PartialUpdate(int id, JsonPatchDocument<MarketSegmentUpdateDto> patchDoc)
        {
            return Ok(await _serviceManager.MarketSegmentService.PartialUpdateAsync(id, patchDoc));
        }

        // DELETE api/MarketSegments/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _serviceManager.MarketSegmentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
