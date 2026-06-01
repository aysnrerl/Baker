using BakerWebApi.Context;
using BakerWebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BakerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly BakerContext _context;

        public AboutController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var value = _context.Abouts.ToList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var about = _context.Abouts.Find(id);
            if (about == null)
            {
                return NotFound("Hakkımızda bilgisi bulunamadı.");
            }
            return Ok(about);
        }

        [HttpPost]
        public IActionResult CreateAbout(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return Ok("Hakkımızda ekleme işlemi başarıyla gerçekleşti.");
        }

        [HttpPut]
        public IActionResult UpdateAbout(About about)
        {
            var existing = _context.Abouts.Find(about.AboutId);
            if (existing == null)
            {
                return NotFound("Hakkımızda bilgisi bulunamadı.");
            }

            existing.Name = about.Name;
            existing.Title = about.Title;
            existing.Description = about.Description;
            existing.ImageUrl1 = about.ImageUrl1;
            existing.ImageUrl2 = about.ImageUrl2;

            _context.SaveChanges();
            return Ok("Hakkımızda güncelleme işlemi başarıyla gerçekleşti.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var about = _context.Abouts.Find(id);
            if (about == null)
            {
                return NotFound("Hakkımızda bilgisi bulunamadı.");
            }

            _context.Abouts.Remove(about);
            _context.SaveChanges();
            return Ok("Hakkımızda silme işlemi başarıyla gerçekleşti.");
        }
    }
}