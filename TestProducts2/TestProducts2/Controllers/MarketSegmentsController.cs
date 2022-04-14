using AutoMapper;
using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Update;
using TestProducts2.Services.Abstractions;

namespace TestProducts2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketSegmentsController : Controller
        {
            private readonly IServiceManager _serviceManager;

            public MarketSegmentsController(IServiceManager serviceManager)
            {
                _serviceManager = serviceManager;
            }

        // GET: api/MarketSegments
        [HttpGet]
        public ActionResult<IEnumerable<MarketSegmentReadDto>> GetMarketSegments([FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)

        {
            //var marketSegments = _unitOfWork.MarketSegmentRepository.GetAll();

            //var mappedMarketSegments = _mapper.Map<IEnumerable<MarketSegmentReadDto>>(marketSegments, opt => opt.Items["lang"] = lang);

            //return Ok(mappedMarketSegments);
            return Ok();
        }

        // GET api/MarketSegments/{id}
        [HttpGet("{id}")]
        public ActionResult<MarketSegmentReadDto> GetMarketSegmentById(int id, [FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            //var categoryOfBenefitItem = _unitOfWork.MarketSegmentRepository.GetById(id);
            //if (categoryOfBenefitItem != null)
            //{
            //    return Ok(_mapper.Map<MarketSegmentReadDto>(categoryOfBenefitItem, opt => opt.Items["lang"] = lang));
            //}
            return NotFound();
        }

        //POST api/MarketSegments
        [HttpPost]
        public ActionResult<MarketSegmentReadDto> CreateMarketSegment(MarketSegmentCreateDto marketSegmentCreateDto)
        {
            //var marketSegmentModel = _mapper.Map<MarketSegment>(marketSegmentCreateDto);

            //if (!_unitOfWork.MarketSegmentRepository.Create(marketSegmentModel))
            //{
            //    ModelState.AddModelError("", "Something went wrong while saving");
            //    return StatusCode(500, ModelState);
            //}

            //return Ok(_mapper.Map<MarketSegmentReadDto>(marketSegmentModel));
            return Ok();
        }

        // PUT api/MarketSegments/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, MarketSegmentUpdateDto categoryOfBenefitUpdateDto)
        {
            //var marketSegmentModel = _unitOfWork.MarketSegmentRepository.GetById(id);
            //if (marketSegmentModel == null)
            //{
            //    return NotFound();
            //}
            //categoryOfBenefitUpdateDto.Id = marketSegmentModel.Id;
            //_mapper.Map(categoryOfBenefitUpdateDto, marketSegmentModel);

            //_unitOfWork.MarketSegmentRepository.Update(marketSegmentModel);

            //_unitOfWork.MarketSegmentRepository.SaveChanges();

            return NoContent();
        }

        // PATCH api/MarketSegments/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialMarketSegmentUpdate(int id, JsonPatchDocument<MarketSegmentUpdateDto> patchDoc)
        {
            //var marketSegmentModel = _unitOfWork.MarketSegmentRepository.GetById(id);
            //if (marketSegmentModel == null)
            //{
            //    return NotFound();
            //}

            //var marketSegmentToPatch = _mapper.Map<MarketSegmentUpdateDto>(marketSegmentModel);
            //patchDoc.ApplyTo(marketSegmentToPatch, ModelState);

            //if (!TryValidateModel(marketSegmentToPatch))
            //{
            //    return ValidationProblem(ModelState);
            //}

            //_mapper.Map(marketSegmentToPatch, marketSegmentModel);

            //_unitOfWork.MarketSegmentRepository.Update(marketSegmentModel);

            //_unitOfWork.MarketSegmentRepository.SaveChanges();

            return NoContent();
        }

        // DELETE api/MarketSegments/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //var model = _unitOfWork.MarketSegmentRepository.GetById(id);
            //if (model == null)
            //{
            //    return NotFound();
            //}

            //_unitOfWork.MarketSegmentRepository.Delete(model);
            //_unitOfWork.MarketSegmentRepository.SaveChanges();

            return NoContent();
        }

    }
}
