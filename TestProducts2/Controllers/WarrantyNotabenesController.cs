using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TestProducts2.Data;
using TestProducts2.Domain.Models;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Update;
using TestProducts2.Entities;

namespace TestProducts2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarrantyNotabenesController : ControllerBase
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public WarrantyNotabenesController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

        // GET: api/WarrantyNotabene
        [HttpGet]
        public ActionResult<IEnumerable<WarrantyNotabeneReadDto>> GetWarrantyNotabenes([FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)

        {
            var warrantyNotabeneModels = _unitOfWork.WarrantyNotabeneRepository.GetAll();

            var mappedWarrantyNotabenes = _mapper.Map<IEnumerable<WarrantyNotabeneReadDto>>(warrantyNotabeneModels, opt => opt.Items["lang"] = lang);

            return Ok(mappedWarrantyNotabenes);
        }

        // GET api/WarrantyNotabene/{id}
        [HttpGet("{id}")]
        public ActionResult<WarrantyNotabeneReadDto> GetById(int id, [FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            var WarrantyNotabene = _unitOfWork.WarrantyNotabeneRepository.GetById(id);

            if (WarrantyNotabene != null)
            {
                var mappedWarrantyTitle = _mapper.Map<WarrantyNotabeneReadDto>(WarrantyNotabene, opt => opt.Items["lang"] = lang);
                return Ok(mappedWarrantyTitle);
            }

            return NotFound();
        }

        // POST api/WarrantyNotabene
        [HttpPost]
        public ActionResult<WarrantyNotabeneReadDto> CreateWarrantyTitle(WarrantyNotabeneCreateDto warrantyNotabeneCreateDto)
        {
            var warrantyNotabene = _mapper.Map<WarrantyNotabene>(warrantyNotabeneCreateDto);

            _unitOfWork.WarrantyNotabeneRepository.Create(warrantyNotabene);
            _unitOfWork.WarrantyNotabeneRepository.SaveChanges();

            var warrantyNotabeneReadDto = _mapper.Map<WarrantyNotabeneReadDto>(warrantyNotabene);

            return Ok(warrantyNotabeneReadDto);
        }

        // PUT api/WarrantyNotabene/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateWarrantyNotabene(int id, WarrantyNotabeneUpdateDto warrantyNotabeneUpdateDto)
        {
            var warrantyNotabeneModel = _unitOfWork.WarrantyNotabeneRepository.GetById(id);
            if (warrantyNotabeneModel == null)
            {
                return NotFound();
            }

            warrantyNotabeneUpdateDto.Id = warrantyNotabeneModel.Id;
            _mapper.Map(warrantyNotabeneUpdateDto, warrantyNotabeneModel);

            _unitOfWork.WarrantyNotabeneRepository.Update(warrantyNotabeneModel);

            _unitOfWork.WarrantyNotabeneRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteWarrantyNotabene(int id)
        {
            var warrantyNotabeneModel = _unitOfWork.WarrantyNotabeneRepository.GetById(id);
            if (warrantyNotabeneModel == null)
            {
                return NotFound();
            }

            _unitOfWork.WarrantyRepository.Get(w => w.WarrantyNotabene.Id == warrantyNotabeneModel.Id).ToList().ForEach(w => w.WarrantyNotabene = null);

            _unitOfWork.WarrantyNotabeneRepository.Delete(warrantyNotabeneModel);
            _unitOfWork.WarrantyNotabeneRepository.SaveChanges();

            return NoContent();
        }

    }
}
