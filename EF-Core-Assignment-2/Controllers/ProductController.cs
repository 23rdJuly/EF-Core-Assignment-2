using System.Collections.Generic;
using EF_Core_2.Models;
using EF_Core_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace EF_Core_2.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("api/product/GetAll")]
        public IEnumerable<Product> GetList(){
            return _productService.GetAll();;
        }
        
        [HttpPost("api/create/product")]
        public Product CreateProduct(ProductDTO product)
        {
            return _productService.Create(product);
        }
        [HttpPut("{id}")]
        public Product EditProduct(ProductDTO product, int id){
            return _productService.Edit(product, id);
        }

        [HttpDelete("api/delete/Product")]
        public IActionResult  DeleteProduct(int id){
            var product = _productService.Get(id);
           if (product == null)
            {
                return StatusCode(404);
            }
            else
            {
                _productService.Delete(id);
                return StatusCode(200);
            }
        }
    }
}