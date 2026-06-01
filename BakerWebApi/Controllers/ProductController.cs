using BakerWebApi.Context;
using BakerWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly BakerContext _context;

        public ProductController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            return Ok(_context.Products.ToList());
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound("Ürün Bulunamadı.");
            }
            return Ok(product);
        }

        [HttpGet("with-category")]
        public IActionResult GetProductWithCategory()
        {
            var products = _context.Products.Include(p => p.Category)
                .Select(p => new
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    CategoryName = p.Category != null ? p.Category.Name : null
                })
                .ToList();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
       
            product.Category = null;
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok("Ürün başarıyla eklendi.");
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            var existingProduct = _context.Products.Find(product.ProductId);
            if (existingProduct == null) return NotFound("Ürün bulunamadı.");

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.ImageUrl = product.ImageUrl;
            existingProduct.CategoryId = product.CategoryId;

            _context.SaveChanges();
            return Ok("Ürün başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound("Ürün bulunamadı.");

            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok("Ürün başarıyla silindi.");
        }


        [HttpGet("count-product")]
        public async Task<IActionResult> GetProductCount()
        {
            var count = await _context.Products.CountAsync();
            return Ok(count);
        }
    }
}