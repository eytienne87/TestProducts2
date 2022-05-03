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
            var lengths = await _serviceManager.WarrantyLengthService.GetAllAsync();
            return Ok(lengths);
        }

        // GET api/WarrantyLengths/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WarrantyLengthReadDto>> GetById(int id)
        {
            var lengthReadDto = await _serviceManager.WarrantyLengthService.GetByIdAsync(id);

            return Ok(lengthReadDto);
        }

        //POST api/WarrantyLengths
        [HttpPost]
        public async Task<ActionResult<WarrantyLengthReadDto>> Create(WarrantyLengthCreateDto lengthDto)
        {
            return Ok(await _serviceManager.WarrantyLengthService.CreateAsync(lengthDto));
        }

        // PUT api/WarrantyLengths/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<WarrantyLengthReadDto>> Update(int id, WarrantyLengthUpdateDto lengthDto)
        {
            return Ok(await _serviceManager.WarrantyLengthService.UpdateAsync(id, lengthDto));
        }

        // PATCH api/WarrantyLengths/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult<WarrantyLengthReadDto>> PartialUpdate(int id, JsonPatchDocument<WarrantyLengthUpdateDto> patchDoc)
        {
            return Ok(await _serviceManager.WarrantyLengthService.PartialUpdateAsync(id, patchDoc));
        }

        // DELETE api/WarrantyLengths/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _serviceManager.WarrantyLengthService.DeleteAsync(id);
            return NoContent();
        }
    }
}
