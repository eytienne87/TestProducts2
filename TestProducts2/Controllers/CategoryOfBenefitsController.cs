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
    public class CategoryOfBenefitsController : Controller
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CategoryOfBenefitsController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

        // GET: api/CategoryOfBenefits
        [HttpGet]
        public ActionResult<IEnumerable<CategoryOfBenefitReadDto>> GetCategoryOfBenefits([FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)

        {
            var categoryOfBenefits = _unitOfWork.CategoryOfBenefitRepository.GetAll();

            var mappedCategoryOfBenefits = _mapper.Map<IEnumerable<CategoryOfBenefitReadDto>>(categoryOfBenefits, opt => opt.Items["lang"] = lang);

            return Ok(mappedCategoryOfBenefits);
        }

        // GET api/CategoryOfBenefits/{id}
        [HttpGet("{id}")]
        public ActionResult<CategoryOfBenefitReadDto> GetCategoryOfBenefitById(int id, [FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            var categoryOfBenefitModel = _unitOfWork.CategoryOfBenefitRepository.GetById(id);
            if (categoryOfBenefitModel != null)
            {
                return Ok(_mapper.Map<CategoryOfBenefitReadDto>(categoryOfBenefitModel, opt => opt.Items["lang"] = lang));
            }
            return NotFound();
        }

        //POST api/CategoryOfBenefits
        [HttpPost]
        public ActionResult<CategoryOfBenefitReadDto> CreateCategoryOfBenefit(CategoryOfBenefitCreateDto categoryOfBenefitCreateDto)
        {
            var categoryOfBenefitModel = _mapper.Map<CategoryOfBenefit>(categoryOfBenefitCreateDto);

            if (!_unitOfWork.CategoryOfBenefitRepository.Create(categoryOfBenefitModel))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok(_mapper.Map<CategoryOfBenefitReadDto>(categoryOfBenefitModel));
        }

        // PUT api/CategoryOfBenefits/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, CategoryOfBenefitUpdateDto benefitUpdateDto)
        {
            var categoryOfBenefitModel = _unitOfWork.CategoryOfBenefitRepository.GetById(id);
            if (categoryOfBenefitModel == null)
            {
                return NotFound();
            }
            benefitUpdateDto.Id = categoryOfBenefitModel.Id;
            _mapper.Map(benefitUpdateDto, categoryOfBenefitModel);

            _unitOfWork.CategoryOfBenefitRepository.Update(categoryOfBenefitModel);

            _unitOfWork.CategoryOfBenefitRepository.SaveChanges();

            return NoContent();
        }

        // PATCH api/CategoryOfBenefits/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCategoryOfBenefitUpdate(int id, JsonPatchDocument<CategoryOfBenefitUpdateDto> patchDoc)
        {
            var categoryOfBenefitModel = _unitOfWork.CategoryOfBenefitRepository.GetById(id);
            if (categoryOfBenefitModel == null)
            {
                return NotFound();
            }

            var categoryOfBenefitToPatch = _mapper.Map<CategoryOfBenefitUpdateDto>(categoryOfBenefitModel);
            patchDoc.ApplyTo(categoryOfBenefitToPatch, ModelState);

            if (!TryValidateModel(categoryOfBenefitToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(categoryOfBenefitToPatch, categoryOfBenefitModel);

            _unitOfWork.CategoryOfBenefitRepository.Update(categoryOfBenefitModel);

            _unitOfWork.CategoryOfBenefitRepository.SaveChanges();

            return NoContent();
        }

        // DELETE api/CategoryOfBenefits/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var model = _unitOfWork.CategoryOfBenefitRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            _unitOfWork.CategoryOfBenefitRepository.Delete(model);
            _unitOfWork.CategoryOfBenefitRepository.SaveChanges();

            return NoContent();
        }

    }
}
