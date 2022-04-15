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
    public class WarrantyTitlesController : Controller
        {
            private readonly IServiceManager _serviceManager;

        public WarrantyTitlesController(IServiceManager serviceManager)
            {
                _serviceManager = serviceManager;
            }

        // GET: api/WarrantyTitles
        [HttpGet]
        public ActionResult<IEnumerable<WarrantyTitleReadDto>> GetAll([FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            return Ok(_serviceManager.WarrantyTitleService.GetAll(lang));
        }

        // GET api/WarrantyTitles/{id}
        [HttpGet("{id}")]
        public ActionResult<WarrantyTitleReadDto> GetById(int id, [FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            return Ok(_serviceManager.WarrantyTitleService.GetById(id, lang));
        }

        //POST api/WarrantyTitles
        [HttpPost]
        public ActionResult<WarrantyTitleReadDto> Create(WarrantyTitleCreateDto titleDto)
        {
            return Ok(_serviceManager.WarrantyTitleService.Create(titleDto));
        }

        // PUT api/WarrantyTitles/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, WarrantyTitleUpdateDto titleDto)
        {
            return Ok(_serviceManager.WarrantyTitleService.Update(id, titleDto));
        }

        // PATCH api/WarrantyTitles/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<WarrantyTitleUpdateDto> patchDoc)
        {
            return Ok(_serviceManager.WarrantyTitleService.PartialUpdate(id, patchDoc));
        }

        // DELETE api/WarrantyTitles/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _serviceManager.WarrantyTitleService.Delete(id);
            return NoContent();
        }
    }
}
