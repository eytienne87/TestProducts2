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
    public class WarrantyLengthsController : Controller
        {
            private readonly IServiceManager _serviceManager;

        public WarrantyLengthsController(IServiceManager serviceManager)
            {
                _serviceManager = serviceManager;
            }

        // GET: api/WarrantyLengths
        [HttpGet]
        public ActionResult<IEnumerable<WarrantyLengthReadDto>> GetAll([FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            return Ok(_serviceManager.WarrantyLengthService.GetAll(lang));
        }

        // GET api/WarrantyLengths/{id}
        [HttpGet("{id}")]
        public ActionResult<WarrantyLengthReadDto> GetById(int id, [FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            return Ok(_serviceManager.WarrantyLengthService.GetById(id, lang));
        }

        //POST api/WarrantyLengths
        [HttpPost]
        public ActionResult<WarrantyLengthReadDto> Create(WarrantyLengthCreateDto lengthDto)
        {
            return Ok(_serviceManager.WarrantyLengthService.Create(lengthDto));
        }

        // PUT api/WarrantyLengths/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, WarrantyLengthUpdateDto lengthDto)
        {
            return Ok(_serviceManager.WarrantyLengthService.Update(id, lengthDto));
        }

        // PATCH api/WarrantyLengths/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<WarrantyLengthUpdateDto> patchDoc)
        {
            return Ok(_serviceManager.WarrantyLengthService.PartialUpdate(id, patchDoc));
        }

        // DELETE api/WarrantyLengths/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _serviceManager.WarrantyLengthService.Delete(id);
            return NoContent();
        }
    }
}
