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
    public class WarrantyNotabenesController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public WarrantyNotabenesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/WarrantyNotabenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarrantyNotabeneReadDto>>> GetAll()
        {
            var notabenes = await _serviceManager.WarrantyNotabeneService.GetAll();
            return Ok(notabenes);
        }

        // GET api/WarrantyNotabenes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WarrantyNotabeneReadDto>> GetById(int id)
        {
            var notabeneReadDto = await _serviceManager.WarrantyNotabeneService.GetById(id);
            return Ok(notabeneReadDto);
        }

        //POST api/WarrantyNotabenes
        [HttpPost]
        public async Task<ActionResult<WarrantyNotabeneReadDto>> Create(WarrantyNotabeneCreateDto notabeneCreateDto)
        {
            var notabeneReadDto = await _serviceManager.WarrantyNotabeneService.Create(notabeneCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = notabeneReadDto.Id }, notabeneReadDto);
        }

        // PUT api/WarrantyNotabenes/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<WarrantyNotabeneReadDto>> Update(int id, WarrantyNotabeneUpdateDto notabeneDto)
        {
            await _serviceManager.WarrantyNotabeneService.Update(id, notabeneDto);
            return NoContent();
        }

        // PATCH api/WarrantyNotabenes/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult<WarrantyNotabeneReadDto>> PartialUpdate(int id, JsonPatchDocument<WarrantyNotabeneUpdateDto> patchDoc)
        {
            await _serviceManager.WarrantyNotabeneService.PartialUpdate(id, patchDoc);
            return NoContent();
        }

        // DELETE api/WarrantyNotabenes/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _serviceManager.WarrantyNotabeneService.Delete(id);
            return NoContent();
        }
    }
}
