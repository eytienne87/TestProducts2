using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using API.Services.Abstractions;
using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetAll([FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            return Ok(_serviceManager.ProductService.GetAll(lang));
        }

        // GET api/Products/{id}
        [HttpGet("{id}")]
        public ActionResult<ProductReadDto> GetById(int id, [FromHeader(Name = "Accept-Language")] LanguageClass? lang = null)
        {
            return Ok(_serviceManager.ProductService.GetById(id, lang));
        }

        //POST api/Products
        [HttpPost]
        public ActionResult<ProductReadDto> Create(ProductCreateDto productDto)
        {
            return Ok(_serviceManager.ProductService.Create(productDto));
        }

        // PUT api/Products/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, ProductUpdateDto productDto)
        {
            return Ok(_serviceManager.ProductService.Update(id, productDto));
        }

        // PATCH api/Products/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<ProductUpdateDto> patchDoc)
        {
            return Ok(_serviceManager.ProductService.PartialUpdate(id, patchDoc));
        }

        // DELETE api/Products/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _serviceManager.ProductService.Delete(id);
            return NoContent();
        }
    }
}
