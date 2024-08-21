using Microsoft.AspNetCore.Mvc;

namespace Shopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(ProductDbContext.GetProducts());
        }
    }
}
