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
    public class MarketSegmentsController : Controller
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public MarketSegmentsController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

        // GET: api/MarketSegments
        [HttpGet]
        public ActionResult<IEnumerable<MarketSegmentReadDto>> GetMarketSegments([FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)

        {
            var marketSegments = _unitOfWork.MarketSegmentRepository.GetAll();

            var mappedMarketSegments = _mapper.Map<IEnumerable<MarketSegmentReadDto>>(marketSegments, opt => opt.Items["lang"] = lang);

            return Ok(mappedMarketSegments);
        }

        // GET api/MarketSegments/{id}
        [HttpGet("{id}")]
        public ActionResult<MarketSegmentReadDto> GetMarketSegmentById(int id, [FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            var benefitItem = _unitOfWork.MarketSegmentRepository.GetById(id);
            if (benefitItem != null)
            {
                return Ok(_mapper.Map<MarketSegmentReadDto>(benefitItem, opt => opt.Items["lang"] = lang));
            }
            return NotFound();
        }

        //POST api/MarketSegments
        [HttpPost]
        public ActionResult<MarketSegmentReadDto> CreateMarketSegment(MarketSegmentCreateDto marketSegmentCreateDto)
        {
            var marketSegmentModel = _mapper.Map<MarketSegment>(marketSegmentCreateDto);

            if (!_unitOfWork.MarketSegmentRepository.Create(marketSegmentModel))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok(_mapper.Map<MarketSegmentReadDto>(marketSegmentModel));
        }

        // PUT api/MarketSegments/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, MarketSegmentUpdateDto benefitUpdateDto)
        {
            var marketSegmentModel = _unitOfWork.MarketSegmentRepository.GetById(id);
            if (marketSegmentModel == null)
            {
                return NotFound();
            }
            benefitUpdateDto.Id = marketSegmentModel.Id;
            _mapper.Map(benefitUpdateDto, marketSegmentModel);

            _unitOfWork.MarketSegmentRepository.Update(marketSegmentModel);

            _unitOfWork.MarketSegmentRepository.SaveChanges();

            return NoContent();
        }

        // PATCH api/MarketSegments/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialMarketSegmentUpdate(int id, JsonPatchDocument<MarketSegmentUpdateDto> patchDoc)
        {
            var marketSegmentModel = _unitOfWork.MarketSegmentRepository.GetById(id);
            if (marketSegmentModel == null)
            {
                return NotFound();
            }

            var marketSegmentToPatch = _mapper.Map<MarketSegmentUpdateDto>(marketSegmentModel);
            patchDoc.ApplyTo(marketSegmentToPatch, ModelState);

            if (!TryValidateModel(marketSegmentToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(marketSegmentToPatch, marketSegmentModel);

            _unitOfWork.MarketSegmentRepository.Update(marketSegmentModel);

            _unitOfWork.MarketSegmentRepository.SaveChanges();

            return NoContent();
        }

        // DELETE api/MarketSegments/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var model = _unitOfWork.MarketSegmentRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            _unitOfWork.MarketSegmentRepository.Delete(model);
            _unitOfWork.MarketSegmentRepository.SaveChanges();

            return NoContent();
        }

    }
}
