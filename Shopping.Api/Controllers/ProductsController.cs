using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Shopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ProductDbContext dbContext) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return Ok(await dbContext.Products.Find(p => true).ToListAsync());
        }
    }
}
