﻿using Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Update;
using TestProducts2.Services.Abstractions;

namespace TestProducts2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarrantyTitlesController : ControllerBase
        {
            private readonly IServiceManager _serviceManager;

            public WarrantyTitlesController(IServiceManager serviceManager)
            {
                _serviceManager = serviceManager;
            }

        // GET: api/WarrantyTitle
        [HttpGet]
        public ActionResult<IEnumerable<WarrantyTitleReadDto>> GetWarrantyTitles([FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)

        {
            //var warrantyTitleModels = _unitOfWork.WarrantyTitleRepository.GetAll();

            //var mappedWarrantyTitles = _mapper.Map<IEnumerable<WarrantyTitleReadDto>>(warrantyTitleModels, opt => opt.Items["lang"] = lang);

            //return Ok(mappedWarrantyTitles);
            return Ok();
        }

        // GET api/WarrantyTitle/{id}
        [HttpGet("{id}")]
        public ActionResult<WarrantyTitleReadDto> GetById(int id, [FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            //var warrantyTitle = _unitOfWork.WarrantyTitleRepository.GetById(id);

            //if (warrantyTitle != null)
            //{
            //    var mappedWarrantyTitle = _mapper.Map<WarrantyTitleReadDto>(warrantyTitle, opt => opt.Items["lang"] = lang);
            //    return Ok(mappedWarrantyTitle);
            //}

            return NotFound();
        }

        // POST api/WarrantyTitle
        [HttpPost]
        public ActionResult<WarrantyTitleReadDto> CreateWarrantyTitle(WarrantyTitleCreateDto warrantyTitleCreateDto)
        {
            //var warrantyTitle = _mapper.Map<WarrantyTitle>(warrantyTitleCreateDto);

            //_unitOfWork.WarrantyTitleRepository.Create(warrantyTitle);
            //_unitOfWork.WarrantyTitleRepository.SaveChanges();

            //var warrantyTitleReadDto = _mapper.Map<WarrantyTitleReadDto>(warrantyTitle, opt => opt.Items["lang"] = null);

            //return Ok(warrantyTitleReadDto);
            return Ok();
        }

        // PUT api/WarrantyTitle
        [HttpPut("{id}")]
        public ActionResult UpdateWarrantyTitle(int id, WarrantyTitleUpdateDto warrantyTitleUpdateDto)
        {
            //var warrantyTitleModel = _unitOfWork.WarrantyTitleRepository.GetById(id);
            //if (warrantyTitleModel == null)
            //{
            //    return NotFound();
            //}

            //warrantyTitleUpdateDto.Id = warrantyTitleModel.Id;
            //_mapper.Map(warrantyTitleUpdateDto, warrantyTitleModel);

            //_unitOfWork.WarrantyTitleRepository.Update(warrantyTitleModel);

            //_unitOfWork.WarrantyTitleRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteWarrantyTitle(int id)
        {
            //var warrantyTitleModel = _unitOfWork.WarrantyTitleRepository.GetById(id);
            //if (warrantyTitleModel == null)
            //{
            //    return NotFound();
            //}
            
            //_unitOfWork.WarrantyTitleRepository.Delete(warrantyTitleModel);
            //_unitOfWork.WarrantyTitleRepository.SaveChanges();

            return NoContent();
        }

    }
}