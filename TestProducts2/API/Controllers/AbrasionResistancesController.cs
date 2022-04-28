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
        public ActionResult<IEnumerable<AbrasionResistanceReadDto>> GetAll()
        {
            return Ok(_serviceManager.AbrasionResistanceService.GetAll());
        }

        // GET api/AbrasionResistances/{id}
        [HttpGet("{id}")]
        public ActionResult<AbrasionResistanceReadDto> GetById(int id)
        {
            var abrasionReadDto = _serviceManager.AbrasionResistanceService.GetById(id);
            if (abrasionReadDto == null)
            {
                return NotFound();
            }
            return Ok(abrasionReadDto);
        }

        //POST api/AbrasionResistances
        [HttpPost]
        public ActionResult<AbrasionResistanceReadDto> Create(AbrasionResistanceCreateDto abrasionDto)
        {
            if (abrasionDto == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_serviceManager.AbrasionResistanceService.Create(abrasionDto));
        }

        // PUT api/AbrasionResistances/{id}
        [HttpPut("{id}")]
        public ActionResult<AbrasionResistanceReadDto> Update(int id, AbrasionResistanceUpdateDto abrasionDto)
        {
            if (abrasionDto == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_serviceManager.AbrasionResistanceService.GetById(id) == null)
                return NotFound();

            return Ok(_serviceManager.AbrasionResistanceService.Update(id, abrasionDto));
        }

        // PATCH api/AbrasionResistances/{id}
        [HttpPatch("{id}")]
        public ActionResult<AbrasionResistanceReadDto> PartialUpdate(int id, JsonPatchDocument<AbrasionResistanceUpdateDto> patchDoc)
        {
            return Ok(_serviceManager.AbrasionResistanceService.PartialUpdate(id, patchDoc));
        }

        // DELETE api/AbrasionResistances/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var abrasionReadDto = _serviceManager.AbrasionResistanceService.GetById(id);
            if (abrasionReadDto == null)
            {
                return NotFound();
            }

            _serviceManager.AbrasionResistanceService.Delete(id);
            return NoContent();
        }
    }
}
