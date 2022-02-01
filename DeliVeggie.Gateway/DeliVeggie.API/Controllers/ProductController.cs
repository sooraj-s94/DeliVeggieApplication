using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DeliVeggie.API.Models;
using DeliVeggie.API.Services;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace DeliVeggie.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly ProductService productService;
        private readonly IConfiguration Configuration;

        public ProductController(ILogger<ProductController> logger, ProductService productService)
        {
            this.logger = logger;
            this.productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> GetProducts()
        {
            IEnumerable<ProductModel> products = productService.GetProducts();          
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductModel> GetProductDetails(string Id)
        {
            if(string.IsNullOrEmpty(Id)){
                return BadRequest("Invalid product id");
            }
            
            ProductModel product = productService.GetProduct(Id);

            if(product == null){
                return NotFound("Product not found");
            }

            return Ok(product);
        }
    }
}
