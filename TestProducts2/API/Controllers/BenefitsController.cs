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
    public class BenefitsController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public BenefitsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/Benefits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BenefitReadDto>>> GetAll()
        {
            var benefits = await _serviceManager.BenefitService.GetAllAsync();
            return Ok(benefits);
        }

        // GET api/Benefits/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BenefitReadDto>> GetById(int id)
        {
            var benefitReadDto =  await _serviceManager.BenefitService.GetByIdAsync(id);

            return Ok(benefitReadDto);
        }

        //POST api/Benefits
        [HttpPost]
        public async Task<ActionResult<BenefitReadDto>> Create(BenefitCreateDto benefitDto)
        {
            return Ok(await _serviceManager.BenefitService.CreateAsync(benefitDto));
        }

        // PUT api/Benefits/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<BenefitReadDto>> Update(int id, BenefitUpdateDto benefitDto)
        {
            return Ok(await _serviceManager.BenefitService.UpdateAsync(id, benefitDto));
        }

        // PATCH api/Benefits/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult<BenefitReadDto>> PartialUpdate(int id, JsonPatchDocument<BenefitUpdateDto> patchDoc)
        {
            return Ok(await _serviceManager.BenefitService.PartialUpdateAsync(id, patchDoc));
        }

        // DELETE api/Benefits/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _serviceManager.BenefitService.DeleteAsync(id);
            return NoContent();
        }
    }
}
