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
    public class WarrantyNotabenesController : Controller
        {
            private readonly IServiceManager _serviceManager;

        public WarrantyNotabenesController(IServiceManager serviceManager)
            {
                _serviceManager = serviceManager;
            }

        // GET: api/WarrantyNotabenes
        [HttpGet]
        public ActionResult<IEnumerable<WarrantyNotabeneReadDto>> GetAll([FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            return Ok(_serviceManager.WarrantyNotabeneService.GetAll(lang));
        }

        // GET api/WarrantyNotabenes/{id}
        [HttpGet("{id}")]
        public ActionResult<WarrantyNotabeneReadDto> GetById(int id, [FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            return Ok(_serviceManager.WarrantyNotabeneService.GetById(id, lang));
        }

        //POST api/WarrantyNotabenes
        [HttpPost]
        public ActionResult<WarrantyNotabeneReadDto> Create(WarrantyNotabeneCreateDto notabeneDto)
        {
            return Ok(_serviceManager.WarrantyNotabeneService.Create(notabeneDto));
        }

        // PUT api/WarrantyNotabenes/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, WarrantyNotabeneUpdateDto notabeneDto)
        {
            return Ok(_serviceManager.WarrantyNotabeneService.Update(id, notabeneDto));
        }

        // PATCH api/WarrantyNotabenes/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<WarrantyNotabeneUpdateDto> patchDoc)
        {
            return Ok(_serviceManager.WarrantyNotabeneService.PartialUpdate(id, patchDoc));
        }

        // DELETE api/WarrantyNotabenes/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _serviceManager.WarrantyNotabeneService.Delete(id);
            return NoContent();
        }
    }
}
