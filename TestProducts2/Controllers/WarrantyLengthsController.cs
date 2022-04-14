﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TestProducts2.Data;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Update;
using TestProducts2.Entities;


namespace TestProducts2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarrantyLengthsController : ControllerBase
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public WarrantyLengthsController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

        // GET: api/WarrantyLength
        [HttpGet]
        public ActionResult<IEnumerable<WarrantyLengthReadDto>> GetWarrantyLengths([FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)

        {
            var warrantyLengthModels = _unitOfWork.WarrantyLengthRepository.GetAll();

            var mappedWarrantyLengths = _mapper.Map<IEnumerable<WarrantyLengthReadDto>>(warrantyLengthModels, opt => opt.Items["lang"] = lang);

            return Ok(mappedWarrantyLengths);
        }

        // GET api/WarrantyLength/{id}
        [HttpGet("{id}")]
        public ActionResult<WarrantyLengthReadDto> GetById(int id, [FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            var warrantyLength = _unitOfWork.WarrantyLengthRepository.GetById(id);

            if (warrantyLength != null)
            {
                var mappedWarrantyLength = _mapper.Map<WarrantyLengthReadDto>(warrantyLength, opt => opt.Items["lang"] = lang);
                return Ok(mappedWarrantyLength);
            }

            return NotFound();
        }

        // POST api/WarrantyLength
        [HttpPost]
        public ActionResult<WarrantyLengthReadDto> CreateWarrantyTitle(WarrantyLengthCreateDto warrantyLengthCreateDto)
        {
            var warrantyLength = _mapper.Map<WarrantyLength>(warrantyLengthCreateDto);

            _unitOfWork.WarrantyLengthRepository.Create(warrantyLength);
            _unitOfWork.WarrantyLengthRepository.SaveChanges();

            var warrantyLengthReadDto = _mapper.Map<WarrantyLengthReadDto>(warrantyLength);

            return Ok(warrantyLengthReadDto);
        }

        // PUT api/WarrantyLength/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateWarrantyLength(int id, WarrantyLengthUpdateDto warrantyLengthUpdateDto)
        {
            var warrantyLengthModel = _unitOfWork.WarrantyLengthRepository.GetById(id);
            if (warrantyLengthModel == null)
            {
                return NotFound();
            }

            warrantyLengthUpdateDto.Id = warrantyLengthModel.Id;
            _mapper.Map(warrantyLengthUpdateDto, warrantyLengthModel);

            _unitOfWork.WarrantyLengthRepository.Update(warrantyLengthModel);

            _unitOfWork.WarrantyLengthRepository.SaveChanges();

            return NoContent();
        }

        // DELETE api/WarrantyLength/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteWarrantyLength(int id)
        {
            var warrantyLengthModel = _unitOfWork.WarrantyLengthRepository.GetById(id);
            if (warrantyLengthModel == null)
            {
                return NotFound();
            }

            _unitOfWork.WarrantyLengthRepository.Delete(warrantyLengthModel);
            _unitOfWork.WarrantyLengthRepository.SaveChanges();

            return NoContent();
        }

    }
}
