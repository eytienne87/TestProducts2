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
    public class AbrasionResistancesController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public AbrasionResistancesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/AbrasionResistances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AbrasionResistanceReadDto>>> GetAll()
        {
            var abrasions = await _serviceManager.AbrasionResistanceService.GetAllAsync();
            return Ok(abrasions);
        }

        // GET api/AbrasionResistances/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AbrasionResistanceReadDto>> GetById(int id)
        {
            var abrasionReadDto = await _serviceManager.AbrasionResistanceService.GetByIdAsync(id);

            return Ok(abrasionReadDto);
        }

        //POST api/AbrasionResistances
        [HttpPost]
        public async Task<ActionResult<AbrasionResistanceReadDto>> Create(AbrasionResistanceCreateDto abrasionDto)
        {
            return Ok(await _serviceManager.AbrasionResistanceService.CreateAsync(abrasionDto));
        }

        // PUT api/AbrasionResistances/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<AbrasionResistanceReadDto>> Update(int id, AbrasionResistanceUpdateDto abrasionDto)
        {
            return Ok(await _serviceManager.AbrasionResistanceService.UpdateAsync(id, abrasionDto));
        }

        // PATCH api/AbrasionResistances/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult<AbrasionResistanceReadDto>> PartialUpdate(int id, JsonPatchDocument<AbrasionResistanceUpdateDto> patchDoc)
        {
            return Ok(await _serviceManager.AbrasionResistanceService.PartialUpdateAsync(id, patchDoc));
        }

        // DELETE api/AbrasionResistances/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _serviceManager.AbrasionResistanceService.DeleteAsync(id);
            return NoContent();
        }
    }
}
