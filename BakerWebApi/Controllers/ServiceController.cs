using BakerWebApi.Context;
using BakerWebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly BakerContext _context;

        public ServiceController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var value = _context.Services.ToList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound("Hizmet bulunamadı.");
            }
            return Ok(service);
        }

        [HttpPost]
        public IActionResult Create(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Hizmet ekleme işlemi başarıyla gerçekleşti.");
        }

        [HttpPut]
        public IActionResult Update(Service service)
        {
            var existing = _context.Services.Find(service.ServiceId);
            if (existing == null)
            {
                return NotFound("Hizmet bulunamadı.");
            }
            existing.Title = service.Title;
            existing.Description = service.Description;
            existing.Icon = service.Icon;
            _context.SaveChanges();
            return Ok("Hizmet güncelleme işlemi başarıyla gerçekleşti.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound("Hizmet bulunamadı.");
            }
            _context.Services.Remove(service);
            _context.SaveChanges();
            return Ok("Hizmet silme işlemi başarıyla gerçekleşti.");
        }

        [HttpGet("count-service")]
        public async Task<IActionResult> GetServiceCount()
        {
            var count = await _context.Services.CountAsync();
            return Ok(count);
        }
    }
}

