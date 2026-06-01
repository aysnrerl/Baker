using BakerWebApi.Context;
using BakerWebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BakerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly BakerContext _context;

        public FeatureController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _context.Features.Find(id);

            if (value == null)
            {
                return NotFound("Veri bulunamadı.");
            }

            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create(Feature feature)
        {
            _context.Features.Add(feature);
            _context.SaveChanges();
            return Ok("Kaydetme işlemi başarıyla gerçekleşti.");
        }

        [HttpPut]
        public IActionResult Update(Feature feature)
        {
            var value = _context.Features.Find(feature.FeatureId);

            if (value == null)
            {
                return NotFound("Güncellenecek veri bulunamadı.");
            }

            value.SupTitle = feature.SupTitle;
            value.Title = feature.Title;
            value.Description = feature.Description;
            value.ImageUrl = feature.ImageUrl;

            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarıyla gerçekleşti.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _context.Features.Find(id);

            if (value == null)
            {
                return NotFound("Silinecek veri bulunamadı.");
            }

            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarıyla gerçekleşti.");
        }
    }
}