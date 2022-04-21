using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using API.Services.Abstractions;
using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitsController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public BenefitsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/Benefits
        [HttpGet]
        public ActionResult<IEnumerable<BenefitReadDto>> GetAll([FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            return Ok(_serviceManager.BenefitService.GetAll(lang));
        }

        // GET api/Benefits/{id}
        [HttpGet("{id}")]
        public ActionResult<BenefitReadDto> GetById(int id, [FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            return Ok(_serviceManager.BenefitService.GetById(id, lang));
        }

        //POST api/Benefits
        [HttpPost]
        public ActionResult<BenefitReadDto> Create(BenefitCreateDto benefitDto)
        {
            return Ok(_serviceManager.BenefitService.Create(benefitDto));
        }

        // PUT api/Benefits/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, BenefitUpdateDto benefitDto)
        {
            return Ok(_serviceManager.BenefitService.Update(id, benefitDto));
        }

        // PATCH api/Benefits/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<BenefitUpdateDto> patchDoc)
        {
            return Ok(_serviceManager.BenefitService.PartialUpdate(id, patchDoc));
        }

        // DELETE api/Benefits/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _serviceManager.BenefitService.Delete(id);
            return NoContent();
        }
    }
}
