using API.Dtos.Read;
using API.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductMinisController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductMinisController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/Minis
        [HttpGet]
        public ActionResult<IEnumerable<ProductMiniReadDto>> GetAll()
        {
            return Ok(_serviceManager.MiniService.GetAll());
        }
       
    }
}
