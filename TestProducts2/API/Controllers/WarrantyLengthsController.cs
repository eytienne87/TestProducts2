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
    public class WarrantyLengthsController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public WarrantyLengthsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/WarrantyLengths
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarrantyLengthReadDto>>> GetAll()
        {
            var categories = await _serviceManager.WarrantyLengthService.GetAll();
            return Ok(categories);
        }

        // GET api/WarrantyLengths/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WarrantyLengthReadDto>> GetById(int id)
        {
            var lengthReadDto = await _serviceManager.WarrantyLengthService.GetById(id);
            return Ok(lengthReadDto);
        }

        //POST api/WarrantyLengths
        [HttpPost]
        public async Task<ActionResult<WarrantyLengthReadDto>> Create(WarrantyLengthCreateDto lengthCreateDto)
        {
            var lengthReadDto = await _serviceManager.WarrantyLengthService.Create(lengthCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = lengthReadDto.Id }, lengthReadDto);
        }

        // PUT api/WarrantyLengths/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<WarrantyLengthReadDto>> Update(int id, WarrantyLengthUpdateDto lengthDto)
        {
            await _serviceManager.WarrantyLengthService.Update(id, lengthDto);
            return NoContent();
        }

        // PATCH api/WarrantyLengths/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult<WarrantyLengthReadDto>> PartialUpdate(int id, JsonPatchDocument<WarrantyLengthUpdateDto> patchDoc)
        {
            await _serviceManager.WarrantyLengthService.PartialUpdate(id, patchDoc);
            return NoContent();
        }

        // DELETE api/WarrantyLengths/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _serviceManager.WarrantyLengthService.Delete(id);
            return NoContent();
        }
    }
}
