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
    public class WarrantyNotabenesController : ControllerBase
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public WarrantyNotabenesController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

        // GET: api/Dealers
        [HttpGet]
        public ActionResult<IEnumerable<WarrantyNotabene>> GetAll()

        {
            var items = _unitOfWork.WarrantyNotabeneRepository.GetAll();

            return Ok(items);
        }

        // GET api/Dealers/{id}
        [HttpGet("{id}")]
        public ActionResult<WarrantyNotabene> GetById(int id)
        {
            var item = _unitOfWork.WarrantyNotabeneRepository.GetById(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        // POST api/Dealers
        [HttpPost]
        public ActionResult<WarrantyNotabene> CreateDealer(WarrantyNotabene warrantyNotabene)
        {
            var model = _mapper.Map<WarrantyNotabene>(warrantyNotabene);
            _unitOfWork.WarrantyNotabeneRepository.Create(model);
            _unitOfWork.WarrantyNotabeneRepository.SaveChanges();

            //var dealerReadDto = _mapper.Map<DealerReadDto>(dealerModel);

            return Ok(model);
        }

        // PUT api/Dealers/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, WarrantyNotabene warrantyNotabene)
        {
            var model = _unitOfWork.WarrantyNotabeneRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            //_mapper.Map(dealerUpdateDto, dealerModelFromRepo);

            _unitOfWork.WarrantyNotabeneRepository.Update(model);

            _unitOfWork.WarrantyNotabeneRepository.SaveChanges();

            return NoContent();
        }

        // DELETE api/Dealers/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var model = _unitOfWork.WarrantyNotabeneRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            _unitOfWork.WarrantyNotabeneRepository.Delete(model);
            _unitOfWork.WarrantyNotabeneRepository.SaveChanges();

            return NoContent();
        }

    }
}
