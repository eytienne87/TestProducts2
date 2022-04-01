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
    public class WarrantiesController : ControllerBase
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public WarrantiesController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

        // GET: api/warranties 
        [HttpGet]
        public ActionResult<IEnumerable<WarrantyReadDto>> GetWarranties()
        {
            var warranties = _unitOfWork.WarrantyRepository.GetAll();

            var mappedWarranties = _mapper.Map<IEnumerable<WarrantyReadDto>>(warranties);

            return Ok(mappedWarranties);
        }

        // GET: api/warranties 
        [HttpGet("language/{lang}")]
        public ActionResult<IEnumerable<WarrantyLanguageReadDto>> GetWarrantiesByLanguage(string lang)
        {
            var warranties = _unitOfWork.WarrantyRepository.GetAll();
            LanguageClass language = lang == "en" ? LanguageClass.en : LanguageClass.fr;

            List<WarrantyLanguageReadDto> list = new List<WarrantyLanguageReadDto>();

            foreach(var warranty in warranties)
            {
                WarrantyLanguageReadDto warrantyLanguageReadDto = new WarrantyLanguageReadDto();

                WarrantyTitleDescription titleDescription = warranty.WarrantyTitle.Descriptions.Where(x => x.Language == language).FirstOrDefault();
                warrantyLanguageReadDto.Title = titleDescription.Description;

                WarrantyLengthDescription lengthDescription = warranty.WarrantyLength.Descriptions.Where(x => x.Language == language).FirstOrDefault();
                warrantyLanguageReadDto.Length = lengthDescription.Description;

                WarrantyNotabeneDescription notabeneDescription = warranty.WarrantyNotabene.Descriptions.Where(x => x.Language == language).FirstOrDefault();
                warrantyLanguageReadDto.Notabene = notabeneDescription.Description;

                list.Add(warrantyLanguageReadDto);
            }

            //var mappedWarranties = _mapper.Map<IEnumerable<WarrantyReadDto>>(warranties);

            return Ok(list);
        }

        // GET api/warranties/{id}
        [HttpGet("{id}", Name = "GetWarantyById")]
        public ActionResult<WarrantyReadDto> GetWarantyById(int id)
        {
            var productItem = _unitOfWork.WarrantyRepository.GetById(id);
            if (productItem != null)
            {
                return Ok(_mapper.Map<WarrantyReadDto>(productItem));
            }
            return NotFound();
        }

        // PUT api/warranties/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, Warranty warrantyTitle)
        {
            var model = _unitOfWork.WarrantyRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            //_mapper.Map(dealerUpdateDto, dealerModelFromRepo);

            _unitOfWork.WarrantyRepository.Update(model);

            _unitOfWork.WarrantyRepository.SaveChanges();

            return NoContent();
        }

        // DELETE api/warranties/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var model = _unitOfWork.WarrantyRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            _unitOfWork.WarrantyRepository.Delete(model);
            _unitOfWork.WarrantyRepository.SaveChanges();

            return NoContent();
        }

    }
}
