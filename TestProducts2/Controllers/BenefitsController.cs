using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TestProducts2.Data;
using TestProducts2.Dtos;
using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitsController : Controller
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
        public ActionResult<IEnumerable<BenefitReadDto>> GetBenefits([FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)

        {
            var benefits = _unitOfWork.BenefitRepository.GetAll();

            var mappedBenefits = _mapper.Map<IEnumerable<BenefitReadDto>>(benefits, opt => opt.Items["lang"] = lang);

            return Ok(mappedBenefits);
        }

        // GET api/Benefits/{id}
        [HttpGet("{id}")]
        public ActionResult<BenefitReadDto> GetBenefitById(int id, [FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            var benefitItem = _unitOfWork.BenefitRepository.GetById(id);
            if (benefitItem != null)
            {
                return Ok(_mapper.Map<BenefitReadDto>(benefitItem, opt => opt.Items["lang"] = lang));
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
        public ActionResult Update(int id, BenefitUpdateDto benefitUpdateDto)
        {
            var benefitModel = _unitOfWork.BenefitRepository.GetById(id);
            if (benefitModel == null)
            {
                return NotFound();
            }
            benefitUpdateDto.Id = benefitModel.Id;
            _mapper.Map(benefitUpdateDto, benefitModel);

            _unitOfWork.BenefitRepository.Update(benefitModel);

            _unitOfWork.BenefitRepository.SaveChanges();

            return NoContent();
        }

        // PATCH api/Benefits/{id}
        //[HttpPatch("{id}")]
        //public ActionResult PartialUpdate(int id, BenefitUpdateDto benefitUpdateDto)
        //{
        //    var benefitModel = _unitOfWork.BenefitRepository.GetById(id);
        //    if (benefitModel == null)
        //    {
        //        return NotFound();
        //    }
        //    benefitUpdateDto.Id = benefitModel.Id;
        //    _mapper.Map(benefitUpdateDto, benefitModel);

        //    _unitOfWork.BenefitRepository.Update(benefitModel);

        //    _unitOfWork.BenefitRepository.SaveChanges();

        //    return NoContent();
        //}

        // PATCH api/Benefits/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialBenefitUpdate(int id, JsonPatchDocument<BenefitUpdateDto> patchDoc)
        {
            var benefitModel = _unitOfWork.BenefitRepository.GetById(id);
            if (benefitModel == null)
            {
                return NotFound();
            }

            var benefitToPatch = _mapper.Map<BenefitUpdateDto>(benefitModel);
            patchDoc.ApplyTo(benefitToPatch, ModelState);

            if (!TryValidateModel(benefitToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(benefitToPatch, benefitModel);

            _unitOfWork.BenefitRepository.Update(benefitModel);

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
