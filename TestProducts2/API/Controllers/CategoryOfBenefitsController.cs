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
            var categories = await _serviceManager.CategoryOfBenefitService.GetAllAsync();
            return Ok(categories);
        }

        // GET api/CategoryOfBenefits/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryOfBenefitReadDto>> GetById(int id)
        {
            var categoryReadDto = await _serviceManager.CategoryOfBenefitService.GetByIdAsync(id);

            return Ok(categoryReadDto);
        }

        //POST api/CategoryOfBenefits
        [HttpPost]
        public async Task<ActionResult<CategoryOfBenefitReadDto>> Create(CategoryOfBenefitCreateDto categoryDto)
        {
            return Ok(await _serviceManager.CategoryOfBenefitService.CreateAsync(categoryDto));
        }

        // PUT api/CategoryOfBenefits/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryOfBenefitReadDto>> Update(int id, CategoryOfBenefitUpdateDto categoryDto)
        {
            return Ok(await _serviceManager.CategoryOfBenefitService.UpdateAsync(id, categoryDto));
        }

        // PATCH api/CategoryOfBenefits/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult<CategoryOfBenefitReadDto>> PartialUpdate(int id, JsonPatchDocument<CategoryOfBenefitUpdateDto> patchDoc)
        {
            return Ok(await _serviceManager.CategoryOfBenefitService.PartialUpdateAsync(id, patchDoc));
        }

        // DELETE api/CategoryOfBenefits/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _serviceManager.CategoryOfBenefitService.DeleteAsync(id);
            return NoContent();
        }
    }
}
