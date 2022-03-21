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
    public class WarrantyLengthsController : ControllerBase
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public WarrantyLengthsController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

        // GET: api/Dealers
        [HttpGet]
        public ActionResult<IEnumerable<WarrantyLength>> GetAll()

        {
            var items = _unitOfWork.WarrantyLengthRepository.GetAll();

            return Ok(items);
        }

        // GET api/Dealers/{id}
        [HttpGet("{id}")]
        public ActionResult<WarrantyLength> GetById(int id)
        {
            var item = _unitOfWork.WarrantyLengthRepository.GetById(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        // POST api/Dealers
        [HttpPost]
        public ActionResult<WarrantyLength> CreateDealer(WarrantyLength warrantyLength)
        {
            var model = _mapper.Map<WarrantyLength>(warrantyLength);
            _unitOfWork.WarrantyLengthRepository.Create(model);
            _unitOfWork.WarrantyLengthRepository.SaveChanges();

            //var dealerReadDto = _mapper.Map<DealerReadDto>(dealerModel);

            return Ok(model);
        }

        // PUT api/Dealers/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, WarrantyLength warrantyLength)
        {
            var model = _unitOfWork.WarrantyLengthRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            //_mapper.Map(dealerUpdateDto, dealerModelFromRepo);

            _unitOfWork.WarrantyLengthRepository.Update(model);

            _unitOfWork.WarrantyLengthRepository.SaveChanges();

            return NoContent();
        }

        // DELETE api/Dealers/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var model = _unitOfWork.WarrantyLengthRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            _unitOfWork.WarrantyLengthRepository.Delete(model);
            _unitOfWork.WarrantyLengthRepository.SaveChanges();

            return NoContent();
        }

    }
}
