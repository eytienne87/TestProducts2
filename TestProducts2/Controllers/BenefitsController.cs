using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TestProducts2.Data;
using TestProducts2.Dtos;
using TestProducts2.Entities;
using TestProducts2.Models;
using TestProducts2.Common;

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
        public ActionResult<IEnumerable<BenefitReadDto>> GetAll([FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)

        {
            var benefits = _unitOfWork.BenefitRepository.GetAll();

            var mappedBenefits = _mapper.Map<IEnumerable<BenefitReadDto>>(benefits, opt => opt.Items["lang"] = lang);

            return Ok(mappedBenefits);
        }

        // GET api/Benefits/{id}
        [HttpGet("{id}")]
        public ActionResult<BenefitReadDto> GetById(int id, [FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            var benefit = _unitOfWork.BenefitRepository.GetById(id);
            if (benefit != null)
            {
                return Ok(_mapper.Map<BenefitReadDto>(benefit, opt => opt.Items["lang"] = lang));
            }
            return NotFound();
        }

        //POST api/Benefits
        [HttpPost]
        public ActionResult Create(BenefitCreateDto benefitDto)
        {
            if (benefitDto == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return StatusCode(422, ModelState);

            var benefit = _mapper.Map<Benefit>(benefitDto);

            SetBenefitNavigations(benefit, benefitDto);

            _unitOfWork.BenefitRepository.Create(benefit);
            _unitOfWork.BenefitRepository.SaveChanges();

            return Ok(_mapper.Map<BenefitReadDto>(benefit));
        }

        // PUT api/Benefits/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, BenefitUpdateDto benefitDto)
        {
            if (benefitDto == null)
                return BadRequest(ModelState);

            var benefit = _unitOfWork.BenefitRepository.GetById(id);

            if (benefit == null)
            {
                ModelState.AddModelError("", "The benefit doesn't exist");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return StatusCode(422, ModelState);

            benefitDto.Id = benefit.Id;
            _mapper.Map(benefitDto, benefit);

            SetBenefitNavigations(benefit, benefitDto);

            _unitOfWork.BenefitRepository.Update(benefit);
            _unitOfWork.BenefitRepository.SaveChanges();

            return Ok(_mapper.Map<BenefitReadDto>(benefit));
        }

        // PATCH api/Benefits/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<BenefitUpdateDto> patchDoc)
        {
            var benefit = _unitOfWork.BenefitRepository.GetById(id);
            if (benefit == null)
            {
                return NotFound();
            }

            var benefitToPatch = _mapper.Map<BenefitUpdateDto>(benefit);
            patchDoc.ApplyTo(benefitToPatch, ModelState);

            if (!TryValidateModel(benefitToPatch))
            {
                return ValidationProblem(ModelState);
            }

            benefitToPatch.Id = benefit.Id;
            _mapper.Map(benefitToPatch, benefit);

            SetBenefitNavigations(benefit, benefitToPatch);

            _unitOfWork.BenefitRepository.Update(benefit);

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

        private void SetBenefitNavigations(Benefit benefit, object benefitDto)
        {
            benefit.Category = _unitOfWork.CategoryOfBenefitRepository.GetById((int)Helper.GetDynamicValue(benefitDto, "CategoryId")!);

            benefit.MarketSegments= new HashSet<MarketSegment>();
            var marketSegmentsFromDto = Helper.GetDynamicValue(benefitDto, "MarketSegments");

            SetBenefitMarketSegments(benefit, marketSegmentsFromDto); 
        }
        
        private void SetBenefitMarketSegments(Benefit benefit, dynamic? marketSegments)
        {
            if (marketSegments == null)
                return;

            foreach (var marketSegment in marketSegments)
            {
                var marketSegmentModel = _unitOfWork.MarketSegmentRepository.GetById((int)Helper.GetDynamicValue(marketSegment, "Id"));
                if (marketSegmentModel != null)
                {
                    benefit.MarketSegments.Add(marketSegmentModel);
                }
            }
        }
    }
}
