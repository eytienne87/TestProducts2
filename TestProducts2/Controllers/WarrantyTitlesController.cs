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
    public class WarrantyTitlesController : ControllerBase
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public WarrantyTitlesController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

        // GET: api/Dealers
        [HttpGet]
        public ActionResult<IEnumerable<WarrantyTitle>> GetAll()

        {
            var items = _unitOfWork.WarrantyTitleRepository.GetAll();

            return Ok(items);
        }

        // GET api/Dealers/{id}
        [HttpGet("{id}")]
        public ActionResult<WarrantyTitle> GetById(int id)
        {
            var item = _unitOfWork.WarrantyTitleRepository.GetById(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        // POST api/Dealers
        [HttpPost]
        public ActionResult<WarrantyTitle> CreateDealer(WarrantyTitle warrantyTitle)
        {
            var model = _mapper.Map<WarrantyTitle>(warrantyTitle);
            _unitOfWork.WarrantyTitleRepository.Create(model);
            _unitOfWork.WarrantyTitleRepository.SaveChanges();

            //var dealerReadDto = _mapper.Map<DealerReadDto>(dealerModel);

            return Ok(model);
        }

        // PUT api/Dealers/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, WarrantyTitle warrantyTitle)
        {
            var model = _unitOfWork.WarrantyTitleRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            //_mapper.Map(dealerUpdateDto, dealerModelFromRepo);

            _unitOfWork.WarrantyTitleRepository.Update(model);

            _unitOfWork.WarrantyTitleRepository.SaveChanges();

            return NoContent();
        }

        // DELETE api/Dealers/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var model = _unitOfWork.WarrantyTitleRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            _unitOfWork.WarrantyTitleRepository.Delete(model);
            _unitOfWork.WarrantyTitleRepository.SaveChanges();

            return NoContent();
        }

    }
}
