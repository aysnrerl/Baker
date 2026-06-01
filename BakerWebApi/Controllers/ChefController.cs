using BakerWebApi.Context;
using BakerWebApi.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefController : ControllerBase
    {
        private readonly BakerContext _context;

        public ChefController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ChefList()
        {
            var value = _context.Chefs.ToList();
            return Ok(value);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var chef = _context.Chefs.Find(id);
            return Ok(chef); 
        }

        [HttpPost]
        public IActionResult Create(Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarıyla gerçekleşti.");
        }

        [HttpPut]
        public IActionResult Update(Chef chef)
        {
            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarıyla gerçekleşti.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            var value = _context.Chefs.Find(id);
            _context.Chefs.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarıyla gerçekleşti.");
        }


        [HttpGet("count-chef")]
        public async Task<IActionResult> GetChefCount()
        {
            var count = await _context.Chefs.CountAsync();
            return Ok(count);
        }
    }
}
