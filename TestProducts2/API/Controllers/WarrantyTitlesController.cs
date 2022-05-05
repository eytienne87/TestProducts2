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
    public class WarrantyTitlesController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public WarrantyTitlesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/WarrantyTitles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarrantyTitleReadDto>>> GetAll()
        {
            var titles = await _serviceManager.WarrantyTitleService.GetAll();
            return Ok(titles);
        }

        // GET api/WarrantyTitles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WarrantyTitleReadDto>> GetById(int id)
        {
            var titleReadDto = await _serviceManager.WarrantyTitleService.GetById(id);
            return Ok(titleReadDto);
        }

        //POST api/WarrantyTitles
        [HttpPost]
        public async Task<ActionResult<WarrantyTitleReadDto>> Create(WarrantyTitleCreateDto titleCreateDto)
        {
            var titleReadDto = await _serviceManager.WarrantyTitleService.Create(titleCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = titleReadDto.Id }, titleReadDto);
        }

        // PUT api/WarrantyTitles/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<WarrantyTitleReadDto>> Update(int id, WarrantyTitleUpdateDto titleDto)
        {
            await _serviceManager.WarrantyTitleService.Update(id, titleDto);
            return NoContent();
        }

        // PATCH api/WarrantyTitles/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult<WarrantyTitleReadDto>> PartialUpdate(int id, JsonPatchDocument<WarrantyTitleUpdateDto> patchDoc)
        {
            await _serviceManager.WarrantyTitleService.PartialUpdate(id, patchDoc);
            return NoContent();
        }

        // DELETE api/WarrantyTitles/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _serviceManager.WarrantyTitleService.Delete(id);
            return NoContent();
        }
    }
}
