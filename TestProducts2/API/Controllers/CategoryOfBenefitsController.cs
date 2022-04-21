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
    public class CategoryOfBenefitsController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public CategoryOfBenefitsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/CategoryOfBenefits
        [HttpGet]
        public ActionResult<IEnumerable<CategoryOfBenefitReadDto>> GetAll([FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            return Ok(_serviceManager.CategoryOfBenefitService.GetAll(lang));
        }

        // GET api/CategoryOfBenefits/{id}
        [HttpGet("{id}")]
        public ActionResult<CategoryOfBenefitReadDto> GetById(int id, [FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            return Ok(_serviceManager.CategoryOfBenefitService.GetById(id, lang));
        }

        //POST api/CategoryOfBenefits
        [HttpPost]
        public ActionResult<CategoryOfBenefitReadDto> Create(CategoryOfBenefitCreateDto categoryDto)
        {
            return Ok(_serviceManager.CategoryOfBenefitService.Create(categoryDto));
        }

        // PUT api/CategoryOfBenefits/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, CategoryOfBenefitUpdateDto categoryDto)
        {
            return Ok(_serviceManager.CategoryOfBenefitService.Update(id, categoryDto));
        }

        // PATCH api/CategoryOfBenefits/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<CategoryOfBenefitUpdateDto> patchDoc)
        {
            return Ok(_serviceManager.CategoryOfBenefitService.PartialUpdate(id, patchDoc));
        }

        // DELETE api/CategoryOfBenefits/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _serviceManager.CategoryOfBenefitService.Delete(id);
            return NoContent();
        }
    }
}
