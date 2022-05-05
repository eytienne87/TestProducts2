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
    public class CategoryOfBenefitsController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public CategoryOfBenefitsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/CategoryOfBenefits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryOfBenefitReadDto>>> GetAll()
        {
            var categories = await _serviceManager.CategoryOfBenefitService.GetAll();
            return Ok(categories);
        }

        // GET api/CategoryOfBenefits/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryOfBenefitReadDto>> GetById(int id)
        {
            var categoryReadDto = await _serviceManager.CategoryOfBenefitService.GetById(id);
            return Ok(categoryReadDto);
        }

        //POST api/CategoryOfBenefits
        [HttpPost]
        public async Task<ActionResult<CategoryOfBenefitReadDto>> Create(CategoryOfBenefitCreateDto categoryCreateDto)
        {
            var categoryReadDto = await _serviceManager.CategoryOfBenefitService.Create(categoryCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = categoryReadDto.Id }, categoryReadDto);
        }

        // PUT api/CategoryOfBenefits/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryOfBenefitReadDto>> Update(int id, CategoryOfBenefitUpdateDto categoryDto)
        {
            await _serviceManager.CategoryOfBenefitService.Update(id, categoryDto);
            return NoContent();
        }

        // PATCH api/CategoryOfBenefits/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult<CategoryOfBenefitReadDto>> PartialUpdate(int id, JsonPatchDocument<CategoryOfBenefitUpdateDto> patchDoc)
        {
            await _serviceManager.CategoryOfBenefitService.PartialUpdate(id, patchDoc);
            return NoContent();
        }

        // DELETE api/CategoryOfBenefits/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _serviceManager.CategoryOfBenefitService.Delete(id);
            return NoContent();
        }
    }
}
