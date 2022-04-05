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
        public ActionResult<IEnumerable<ProductReadDto>> GetProducts([FromHeader(Name = "Accept-Language")] LanguageClass? lang)
        {
            var products = _unitOfWork.ProductRepository.GetAll();

            var mappedProducts = _mapper.Map<IEnumerable<ProductReadDto>>(products, opt => opt.Items["lang"] = lang);

            return Ok(mappedProducts);
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

            productModel.Warranties = new List<Warranty>();
            productModel.Benefits = new List<Benefit>();


            foreach (var benefit in productCreateDto.Benefits)
            {
                var benefitModel = _unitOfWork.BenefitRepository.GetById(benefit.Id);
                if (benefitModel != null)
                {
                    productModel.Benefits.Add(benefitModel);
                }
            }

            foreach (var warranty in productCreateDto.Warranties)
            {
                var warrantyModel  = _unitOfWork.WarrantyRepository.Get(w => w.WarrantyTitle.Id == warranty.WarrantyTitleId &&
                                                                             w.WarrantyLength.Id == warranty.WarrantyLengthId &&
                                                                             w.WarrantyNotabene.Id == warranty.WarrantyNotabeneId).FirstOrDefault();
                var warrantyTitleModel = _unitOfWork.WarrantyTitleRepository.GetById(warranty.WarrantyTitleId);
                var warrantyLengthModel = _unitOfWork.WarrantyLengthRepository.GetById(warranty.WarrantyLengthId);
                var warrantyNotabeneModel = _unitOfWork.WarrantyNotabeneRepository.GetById(warranty.WarrantyNotabeneId);

                if (warrantyModel != null)
                {
                    productModel.Warranties.Add(warrantyModel);
                }
                else if (warrantyTitleModel != null && warrantyLengthModel != null)    
                {
                    productModel.Warranties.Add(new Warranty
                    {
                        WarrantyTitle = warrantyTitleModel,
                        WarrantyLength = warrantyLengthModel,
                        WarrantyNotabene = warrantyNotabeneModel
                    });
                }

            }

            _unitOfWork.ProductRepository.Create(productModel);
            _unitOfWork.ProductRepository.SaveChanges();

            return Ok(_mapper.Map<ProductReadDto>(productModel));
        }

        // PUT api/Products/{id} 
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        {
            if (productUpdateDto == null)
                return BadRequest(ModelState);

            var product = _unitOfWork.ProductRepository.GetById(id);

            if (product == null)
            {
                ModelState.AddModelError("", "The product doesn't exist");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return StatusCode(422, ModelState);

            //var productModel = _mapper.Map<Product>(productUpdateDto);
            var productModel = product;
            _mapper.Map(productModel, productUpdateDto);
            //productModel.ProductType = productUpdateDto.ProductType;

            productModel.Warranties = new List<Warranty>();
            productModel.Benefits = new List<Benefit>();

            //foreach (var benefit in productUpdateDto.Benefits)
            //{
            //    var benefitModel = _unitOfWork.BenefitRepository.GetById(benefit.Id);
            //    if (benefitModel != null)
            //    {
            //        productModel.Benefits.Add(benefitModel);
            //    }
            //}

            foreach (var warranty in productUpdateDto.Warranties)
            {
                var warrantyModel = _unitOfWork.WarrantyRepository.Get(w => w.WarrantyTitle.Id == warranty.WarrantyTitle &&
                                                                            w.WarrantyLength.Id == warranty.WarrantyLength &&
                                                                            w.WarrantyNotabene.Id == warranty.WarrantyNotabene).FirstOrDefault();
                var warrantyTitleModel = _unitOfWork.WarrantyTitleRepository.GetById(warranty.WarrantyTitle);
                var warrantyLengthModel = _unitOfWork.WarrantyLengthRepository.GetById(warranty.WarrantyLength);
                var warrantyNotabeneModel = _unitOfWork.WarrantyNotabeneRepository.GetById(warranty.WarrantyNotabene);

                if (warrantyModel != null)
                {
                    productModel.Warranties.Add(warrantyModel);
                }
                else if (warrantyTitleModel != null && warrantyLengthModel != null)
                {
                    productModel.Warranties.Add(new Warranty
                    {
                        WarrantyTitle = warrantyTitleModel,
                        WarrantyLength = warrantyLengthModel,
                        WarrantyNotabene = warrantyNotabeneModel
                    });
                }
            }

            _unitOfWork.ProductRepository.Update(productModel);
            _unitOfWork.ProductRepository.SaveChanges();

            return Ok(_mapper.Map<ProductReadDto>(productModel));
        }

        //[HttpPatch("{id}")]
        //public ActionResult PartialProductUpdate(int id, JsonPatchDocument<ProductUpdateDto> patchDoc)
        //{
        //    var productModelFromRepo = _unitOfWork.ProductRepository.GetById(id);
        //    if (productModelFromRepo == null)
        //    {
        //        return NotFound();
        //    }

        //    var productToPatch = _mapper.Map<ProductUpdateDto>(productModelFromRepo);

        //    patchDoc.ApplyTo(productToPatch, ModelState);

        //    if (!TryValidateModel(productToPatch))
        //    {
        //        return ValidationProblem(ModelState);
        //    }

        //    _mapper.Map(productToPatch, productModelFromRepo);

        //    _unitOfWork.ProductRepository.Update(productModelFromRepo);

        //    _unitOfWork.ProductRepository.SaveChanges();

        //    return NoContent();

        //}

        // DELETE api/Products/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
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
