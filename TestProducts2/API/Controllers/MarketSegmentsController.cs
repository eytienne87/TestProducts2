using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Update;
using TestProducts2.Services.Abstractions;

namespace TestProducts2.Controllers
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
        public ActionResult<IEnumerable<MarketSegmentReadDto>> GetAll([FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            return Ok(_serviceManager.MarketSegmentService.GetAll(lang));
        }

        // GET api/MarketSegments/{id}
        [HttpGet("{id}")]
        public ActionResult<MarketSegmentReadDto> GetById(int id, [FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            return Ok(_serviceManager.MarketSegmentService.GetById(id, lang));
        }

        //POST api/MarketSegments
        [HttpPost]
        public ActionResult<MarketSegmentReadDto> Create(MarketSegmentCreateDto categoryDto)
        {
            return Ok(_serviceManager.MarketSegmentService.Create(categoryDto));
        }

        // PUT api/MarketSegments/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, MarketSegmentUpdateDto categoryDto)
        {
            return Ok(_serviceManager.MarketSegmentService.Update(id, categoryDto));
        }

        // PATCH api/MarketSegments/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<MarketSegmentUpdateDto> patchDoc)
        {
            return Ok(_serviceManager.MarketSegmentService.PartialUpdate(id, patchDoc));
        }

        // DELETE api/MarketSegments/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _serviceManager.MarketSegmentService.Delete(id);
            return NoContent();
        }
    }
}
