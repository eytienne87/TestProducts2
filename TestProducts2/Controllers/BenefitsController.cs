using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TestProducts2.Data;
using TestProducts2.Dtos;
using TestProducts2.Models;

namespace TestProducts2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitsController : ControllerBase
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public BenefitsController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

        // GET: api/Benefits
        [HttpGet]
        public ActionResult<IEnumerable<Benefit>> GetAll()

        {
            var benefits = _unitOfWork.BenefitRepository.GetAll();

            var mappedBenefits = _mapper.Map<IEnumerable<BenefitReadDto>>(benefits);

            return Ok(mappedBenefits);
        }

        // GET api/Benefits/{id}
        [HttpGet("{id}", Name = "GetBenefitById")]
        public ActionResult<Benefit> GetBenefitById(int id)
        {
            var benefitItem = _unitOfWork.BenefitRepository.GetById(id);
            if (benefitItem != null)
            {
                return Ok(_mapper.Map<BenefitReadDto>(benefitItem));
            }
            return NotFound();
        }

        //POST api/Benefits
        [HttpPost]
        public ActionResult<BenefitReadDto> CreateBenefit(BenefitCreateDto benefitCreateDto)
        {
            var benefitModel = _mapper.Map<Benefit>(benefitCreateDto);

            if (!_unitOfWork.BenefitRepository.Create(benefitModel))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok(_mapper.Map<BenefitReadDto>(benefitModel));
        }

        // PUT api/Benefits/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, Benefit warrantyTitle)
        {
            var model = _unitOfWork.BenefitRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            //_mapper.Map(dealerUpdateDto, dealerModelFromRepo);

            _unitOfWork.BenefitRepository.Update(model);

            _unitOfWork.BenefitRepository.SaveChanges();

            return NoContent();
        }

        // DELETE api/Benefits/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var model = _unitOfWork.BenefitRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            _unitOfWork.BenefitRepository.Delete(model);
            _unitOfWork.BenefitRepository.SaveChanges();

            return NoContent();
        }

    }
}
