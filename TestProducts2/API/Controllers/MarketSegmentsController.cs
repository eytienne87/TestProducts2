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
            var segments = await _serviceManager.MarketSegmentService.GetAll();
            return Ok(segments);
        }

        // GET api/MarketSegments/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketSegmentReadDto>> GetById(int id)
        {
            var segmentReadDto = await _serviceManager.MarketSegmentService.GetById(id);
            return Ok(segmentReadDto);
        }

        //POST api/MarketSegments
        [HttpPost]
        public async Task<ActionResult<MarketSegmentReadDto>> Create(MarketSegmentCreateDto segmentCreateDto)
        {
            var segmentReadDto = await _serviceManager.MarketSegmentService.Create(segmentCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = segmentReadDto.Id }, segmentReadDto);
        }

        // PUT api/MarketSegments/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<MarketSegmentReadDto>> Update(int id, MarketSegmentUpdateDto segmentDto)
        {
            await _serviceManager.MarketSegmentService.Update(id, segmentDto);
            return NoContent();
        }

        // PATCH api/MarketSegments/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult<MarketSegmentReadDto>> PartialUpdate(int id, JsonPatchDocument<MarketSegmentUpdateDto> patchDoc)
        {
            await _serviceManager.MarketSegmentService.PartialUpdate(id, patchDoc);
            return NoContent();
        }

        // DELETE api/MarketSegments/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _serviceManager.MarketSegmentService.Delete(id);
            return NoContent();
        }
    }
}
