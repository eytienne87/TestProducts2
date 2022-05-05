using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using API.Services.Abstractions;
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
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAll()
        {
            var products = await _serviceManager.ProductService.GetAll();
            return Ok(products);
        }

        // GET api/Products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReadDto>> GetById(int id)
        {
            var productReadDto = await _serviceManager.ProductService.GetById(id);
            return Ok(productReadDto);
        }

        //POST api/Products
        [HttpPost]
        public async Task<ActionResult<ProductReadDto>> Create(ProductCreateDto productCreateDto)
        {
            var productReadDto = await _serviceManager.ProductService.Create(productCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = productReadDto.Id }, productReadDto);
        }

        // PUT api/Products/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductReadDto>> Update(int id, ProductUpdateDto productDto)
        {
            await _serviceManager.ProductService.Update(id, productDto);
            return NoContent();
        }

        // PATCH api/Products/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult<ProductReadDto>> PartialUpdate(int id, JsonPatchDocument<ProductUpdateDto> patchDoc)
        {
            await _serviceManager.ProductService.PartialUpdate(id, patchDoc);
            return NoContent();
        }

        // DELETE api/Products/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _serviceManager.ProductService.Delete(id);
            return NoContent();
        }
    }
}
