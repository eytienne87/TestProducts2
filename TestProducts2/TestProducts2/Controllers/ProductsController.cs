using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Update;
using TestProducts2.Services.Abstractions;

namespace TestProducts2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ProductsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/products 
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetProducts([FromHeader(Name = "Accept-Language")] LanguageClass? lang)
        {
            //var products = _unitOfWork.ProductRepository.GetAll();

            //var mappedProducts = _mapper.Map<IEnumerable<ProductReadDto>>(products, opt => opt.Items["lang"] = lang);

            //return Ok(mappedProducts);
            return Ok();
        }

        // GET api/Products/{id}
        [HttpGet("{id}")]
        public ActionResult<ProductReadDto> GetProductById(int id, [FromHeader(Name = "Accept-Language")] LanguageClass? lang)
        {
            //var productItem = _unitOfWork.ProductRepository.GetById(id);
            //if (productItem != null)
            //{
            //    return Ok(_mapper.Map<ProductReadDto>(productItem, opt => opt.Items["lang"] = lang));
            //}
            return NotFound();
        }

        // POST api/Products
        [HttpPost]
        public ActionResult<ProductReadDto> CreateProduct([FromBody] ProductCreateDto productCreateDto)
        {
            //if (productCreateDto == null)
            //    return BadRequest(ModelState);

            //var products = _unitOfWork.ProductRepository.GetAll()
            //    .Where(product => product.StyleCode == productCreateDto.StyleCode)
            //    .FirstOrDefault();

            //if (products != null)
            //{
            //    ModelState.AddModelError("", "Product already exists");
            //    return StatusCode(422, ModelState);
            //}

            //if (!ModelState.IsValid)
            //    return StatusCode(422, ModelState);

            //var productModel = _mapper.Map<Product>(productCreateDto);

            //SetProductNavigations(productModel, productCreateDto);

            //_unitOfWork.ProductRepository.Create(productModel);
            //_unitOfWork.ProductRepository.SaveChanges();

            ////return Ok(_mapper.Map<ProductReadDto>(productModel));
            return Ok();
        }

        // PUT api/Products/{id} 
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        {
            //if (productUpdateDto == null)
            //    return BadRequest(ModelState);

            //var product = _unitOfWork.ProductRepository.GetById(id);

            //if (product == null)
            //{
            //    ModelState.AddModelError("", "The product doesn't exist");
            //    return StatusCode(422, ModelState);
            //}

            //if (!ModelState.IsValid)
            //    return StatusCode(422, ModelState);

            //var productModel = product;
            //_mapper.Map(productUpdateDto, productModel);

            //SetProductNavigations(productModel, productUpdateDto);

            //_unitOfWork.ProductRepository.Update(productModel);
            //_unitOfWork.ProductRepository.SaveChanges();

            return Ok();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialProductUpdate(int id, JsonPatchDocument<ProductUpdateDto> patchDoc)
        {
            //var productModel = _unitOfWork.ProductRepository.GetById(id);
            //if (productModel == null)
            //{
            //    return NotFound();
            //}

            //var productToPatch = _mapper.Map<ProductUpdateDto>(productModel);

            //patchDoc.ApplyTo(productToPatch, ModelState);

            //if (!TryValidateModel(productToPatch))
            //{
            //    return ValidationProblem(ModelState);
            //}


            //_mapper.Map(productToPatch, productModel);

            //SetProductNavigations(productModel, productToPatch);

            //_unitOfWork.ProductRepository.Update(productModel);

            //_unitOfWork.ProductRepository.SaveChanges();

            return NoContent();
        }

        // DELETE api/Products/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            //var productModelFromRepo = _unitOfWork.ProductRepository.GetById(id);
            //if (productModelFromRepo == null)
            //{
            //    return NotFound();
            //}

            //_unitOfWork.ProductRepository.Delete(productModelFromRepo);
            //_unitOfWork.ProductRepository.SaveChanges();

            return NoContent();
        }

        //private void SetProductNavigations(Product product, object productDto)
        //{
        //    product.Benefits= new HashSet<Benefit>();
        //    var benefitsFromDto = (HashSet<object>?)Helper.GetDynamicValue(productDto, "Benefits");
        //    SetProductBenefits(product, benefitsFromDto);
            
        //    product.Warranties= new HashSet<Warranty>();
        //    var warrantiesFromDto = (HashSet<object>?)Helper.GetDynamicValue(productDto, "Warranties");
        //    SetProductWarranties(product, warrantiesFromDto);
        //}

        //private void SetProductBenefits(Product product, HashSet<object>? benefits)
        //{
        //    if (benefits == null)
        //        return;

        //    foreach (var benefit in benefits)
        //    {
        //        var benefitModel = _unitOfWork.BenefitRepository.GetById((int)Helper.GetDynamicValue(benefit, "Id")!);
        //        if (benefitModel != null)
        //        {
        //            product.Benefits.Add(benefitModel);
        //        }
        //    }
        //}
        //private void SetProductWarranties(Product product, HashSet<object>? warranties)
        //{
        //    if (warranties == null)
        //        return;

        //    foreach (var warranty in warranties)
        //    {
        //        int warrantyTitleId = (int)Helper.GetDynamicValue(warranty, "WarrantyTitleId");
        //        int warrantyLengthId = (int)Helper.GetDynamicValue(warranty, "WarrantyLengthId");
        //        int warrantyNotabeneId = (int)Helper.GetDynamicValue(warranty, "WarrantyNotabeneId");

        //        var warrantyModel = _unitOfWork.WarrantyRepository.Get(w => w.WarrantyTitle.Id == warrantyTitleId &&
        //                                                                    w.WarrantyLength.Id == warrantyLengthId &&
        //                                                                    w.WarrantyNotabene.Id == warrantyNotabeneId).FirstOrDefault();


        //        var warrantyTitleModel = _unitOfWork.WarrantyTitleRepository.GetById(warrantyTitleId!);
        //        var warrantyLengthModel = _unitOfWork.WarrantyLengthRepository.GetById(warrantyLengthId!);
        //        var warrantyNotabeneModel = _unitOfWork.WarrantyNotabeneRepository.GetById(warrantyNotabeneId!);

        //        if (warrantyModel != null)
        //        {
        //            product.Warranties.Add(warrantyModel);
        //        }
        //        else if (warrantyTitleModel != null && warrantyLengthModel != null)
        //        {
        //            product.Warranties.Add(new Warranty
        //            {
        //                WarrantyTitle = warrantyTitleModel,
        //                WarrantyLength = warrantyLengthModel,
        //                WarrantyNotabene = warrantyNotabeneModel
        //            });
        //        }
        //    }

        //}




    }
}
