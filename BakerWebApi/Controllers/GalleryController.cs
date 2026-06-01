using BakerWebApi.Context;
using BakerWebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly BakerContext _context;

        public GalleryController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GalleryList()
        {
            var value = _context.Galleries.ToList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var gallery = _context.Galleries.Find(id);
            if (gallery == null)
            {
                return NotFound("Galeri öğesi bulunamadı.");
            }
            return Ok(gallery);
        }

        [HttpPost]
        public IActionResult Create(Gallery gallery)
        {
            _context.Galleries.Add(gallery);
            _context.SaveChanges();
            return Ok("Galeri öğesi ekleme işlemi başarıyla gerçekleşti.");
        }

        [HttpPut]
        public IActionResult Update(Gallery gallery)
        {
            var existing = _context.Galleries.Find(gallery.GalleryId);
            if (existing == null)
            {
                return NotFound("Galeri öğesi bulunamadı.");
            }
            existing.Title = gallery.Title;
            existing.ImageUrl = gallery.ImageUrl;
            _context.SaveChanges();
            return Ok("Galeri öğesi güncelleme işlemi başarıyla gerçekleşti.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var gallery = _context.Galleries.Find(id);
            if (gallery == null)
            {
                return NotFound("Galeri öğesi bulunamadı.");
            }
            _context.Galleries.Remove(gallery);
            _context.SaveChanges();
            return Ok("Galeri öğesi silme işlemi başarıyla gerçekleşti.");
        }

        [HttpGet("count-gallery")]
        public async Task<IActionResult> GetGalleryCount()
        {
            var count = await _context.Galleries.CountAsync();
            return Ok(count);
        }
    }
}
