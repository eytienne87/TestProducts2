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
    public class BenefitsController : ControllerBase
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public BenefitsController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

        // GET: api/Dealers
        [HttpGet]
        public ActionResult<IEnumerable<Benefit>> GetAll()

        {
            var items = _unitOfWork.BenefitRepository.GetAll();

            return Ok(items);
        }

        // GET api/Dealers/{id}
        [HttpGet("{id}")]
        public ActionResult<Benefit> GetById(int id)
        {
            var item = _unitOfWork.BenefitRepository.GetById(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        // POST api/Dealers
        [HttpPost]
        public ActionResult<Benefit> CreateDealer(Benefit warrantyTitle)
        {
            var model = _mapper.Map<Benefit>(warrantyTitle);
            _unitOfWork.BenefitRepository.Create(model);
            _unitOfWork.BenefitRepository.SaveChanges();

            //var dealerReadDto = _mapper.Map<DealerReadDto>(dealerModel);

            return Ok(model);
        }

        // PUT api/Dealers/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, Benefit warrantyTitle)
        {
            var model = _unitOfWork.BenefitRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            //_mapper.Map(dealerUpdateDto, dealerModelFromRepo);

            _unitOfWork.BenefitRepository.Update(model);

            _unitOfWork.BenefitRepository.SaveChanges();

            return NoContent();
        }

        // DELETE api/Dealers/{id}
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

    }
}
