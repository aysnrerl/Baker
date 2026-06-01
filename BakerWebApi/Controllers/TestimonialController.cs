using BakerWebApi.Context;
using BakerWebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly BakerContext _context;

        public TestimonialController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _context.Testimonials.ToList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var testimonial = _context.Testimonials.Find(id);
            if (testimonial == null)
            {
                return NotFound("Referans bulunamadı.");
            }
            return Ok(testimonial);
        }

        [HttpPost]
        public IActionResult Create(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return Ok("Referans ekleme işlemi başarıyla gerçekleşti.");
        }

        [HttpPut]
        public IActionResult Update(Testimonial testimonial)
        {
            var existing = _context.Testimonials.Find(testimonial.TestimonialId);
            if (existing == null)
            {
                return NotFound("Referans bulunamadı.");
            }
            existing.Name = testimonial.Name;
            existing.Title = testimonial.Title;
            existing.Description = testimonial.Description;
            existing.ImageUrl = testimonial.ImageUrl;
            _context.SaveChanges();
            return Ok("Referans güncelleme işlemi başarıyla gerçekleşti.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var testimonial = _context.Testimonials.Find(id);
            if (testimonial == null)
            {
                return NotFound("Referans bulunamadı.");
            }
            _context.Testimonials.Remove(testimonial);
            _context.SaveChanges();
            return Ok("Referans silme işlemi başarıyla gerçekleşti.");
        }

        [HttpGet("count-testimonial")]
        public async Task<IActionResult> GetTestimonialCount()
        {
            var count = await _context.Testimonials.CountAsync();
            return Ok(count);
        }
    }
}
