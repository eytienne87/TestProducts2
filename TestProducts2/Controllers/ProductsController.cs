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
    public class ProductsController : ControllerBase
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            // GET: api/products 
            [HttpGet]
            public ActionResult<IEnumerable<Product>> GetProducts()
            {
                var products = _unitOfWork.ProductRepository.GetAll();

                //var productReadDto = _mapper.Map<ProductReadDto>(products);

                return Ok(products);
            }

            // GET api/Products/{id}
            [HttpGet("{id}", Name = "GetProductById")]
            public ActionResult<ProductReadDto> GetProductById(int id)
            {
                var productItem = _unitOfWork.ProductRepository.GetById(id);
                if (productItem != null)
                {
                    return Ok(_mapper.Map<ProductReadDto>(productItem));
                }
                return NotFound();
            }

            // POST api/Products
            [HttpPost]
            public ActionResult<ProductReadDto> CreateProduct([FromBody] ProductCreateDto productCreateDto)
            {
                if (productCreateDto == null)
                    return BadRequest(ModelState);
            
                var products = _unitOfWork.ProductRepository.GetAll()
                    .Where(product => product.StyleCode == productCreateDto.StyleCode)
                    .FirstOrDefault();

                if (products != null)
                {
                    ModelState.AddModelError("", "Product already exists");
                    return StatusCode(422, ModelState); 
                }

                if (!ModelState.IsValid)
                    return StatusCode(422, ModelState);

                var productModel = _mapper.Map<Product>(productCreateDto);

                if (!_unitOfWork.ProductRepository.Create(productModel))
                {
                    ModelState.AddModelError("", "Something went wrong while saving");
                    return StatusCode(500, ModelState);
                }

                return Ok(_mapper.Map<ProductReadDto>(productModel)); 
            }

            // PUT api/Products/{id} 
            [HttpPut("{id}")]
            public ActionResult UpdateProduct(int id, ProductUpdateDto productUpdateDto)
            {
                var productModelFromRepo = _unitOfWork.ProductRepository.GetById(id);
                if (productModelFromRepo == null)
                {
                    return NotFound();
                }
                _mapper.Map(productUpdateDto, productModelFromRepo);

                _unitOfWork.ProductRepository.Update(productModelFromRepo);

                _unitOfWork.ProductRepository.SaveChanges();

                return NoContent();
            }

            [HttpPatch("{id}")]
            public ActionResult PartialProductUpdate(int id, JsonPatchDocument<ProductUpdateDto> patchDoc)
            {
                var productModelFromRepo = _unitOfWork.ProductRepository.GetById(id);
                if (productModelFromRepo == null)
                {
                    return NotFound();
                }

                var productToPatch = _mapper.Map<ProductUpdateDto>(productModelFromRepo);

                patchDoc.ApplyTo(productToPatch, ModelState);

                if (!TryValidateModel(productToPatch))
                {
                    return ValidationProblem(ModelState);
                }

                _mapper.Map(productToPatch, productModelFromRepo);

                _unitOfWork.ProductRepository.Update(productModelFromRepo);

                _unitOfWork.ProductRepository.SaveChanges();

                return NoContent();

            }

            // DELETE api/Commands/{id}
            [HttpDelete("{id}")]
            public ActionResult DeleteCommand(int id)
            {
                var productModelFromRepo = _unitOfWork.ProductRepository.GetById(id);
                if (productModelFromRepo == null)
                {
                    return NotFound();
                }

                _unitOfWork.ProductRepository.Delete(productModelFromRepo);
                _unitOfWork.ProductRepository.SaveChanges();

                return NoContent();
            }


    }
}
