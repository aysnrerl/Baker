using BakerWebApi.Context;
using BakerWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // ToListAsync vb. için gerekli

namespace Baker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BakerContext _context;

        public CategoryController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
          
            var values = await _context.Categories.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound("Kategori bulunamadı.");
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return Ok("Kategori ekleme işlemi başarıyla gerçekleşti.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(Category category)
        {
          
            var existing = await _context.Categories.FindAsync(category.CategoryId);
            if (existing == null)
            {
                return NotFound("Kategori bulunamadı.");
            }

            existing.Name = category.Name;
            existing.Description = category.Description;

            await _context.SaveChangesAsync();
            return Ok("Kategori güncelleme işlemi başarıyla gerçekleşti.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound("Kategori bulunamadı.");
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return Ok("Kategori silme işlemi başarıyla gerçekleşti.");
        }

        [HttpGet("count-category")]
        public async Task<IActionResult> GetCategoryCount()
        {
            var count = await _context.Categories.CountAsync();
            return Ok(count);
        }
    }
}