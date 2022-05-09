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
            var benefits = await _serviceManager.BenefitService.GetAll();
            return Ok(benefits);
        }

        //GET api/Benefits/{id
        [HttpGet("{id}")]
        public async Task<ActionResult<BenefitReadDto>> GetById(int id)
        {
            var benefitReadDto = await _serviceManager.BenefitService.GetById(id);
            return Ok(benefitReadDto);
        }

        //POST api/Benefits
        [HttpPost]
        public async Task<ActionResult<BenefitReadDto>> Create(BenefitCreateDto benefitCreateDto)
        {
            var benefitReadDto = await _serviceManager.BenefitService.Create(benefitCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = benefitReadDto.Id }, benefitReadDto);
        }

        // PUT api/Benefits/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<BenefitReadDto>> Update(int id, BenefitUpdateDto benefitDto)
        {
            await _serviceManager.BenefitService.Update(id, benefitDto);
            return NoContent(); 
        }

        // PATCH api/Benefits/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult<BenefitReadDto>> PartialUpdate(int id, JsonPatchDocument<BenefitUpdateDto> patchDoc)
        {
            await _serviceManager.BenefitService.PartialUpdate(id, patchDoc);
            return NoContent();
        }

        // DELETE api/Benefits/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _serviceManager.BenefitService.Delete(id);
            return NoContent();
        }
    }
}
