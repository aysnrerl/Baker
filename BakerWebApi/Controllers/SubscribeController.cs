using BakerWebApi.Context;
using BakerWebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly BakerContext _context;

        public SubscribeController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var value = _context.Subscribes.ToList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var subscribe = _context.Subscribes.Find(id);
            if (subscribe == null)
            {
                return NotFound("Abone bulunamadı.");
            }
            return Ok(subscribe);
        }

        [HttpPost]
        public IActionResult Create(Subscribe subscribe)
        {
            subscribe.IsActive = true;
            subscribe.CreatedDate = DateTime.Now;
            _context.Subscribes.Add(subscribe);
            _context.SaveChanges();
            return Ok("Abone olma işlemi başarıyla gerçekleşti.");
        }

        [HttpPut]
        public IActionResult Update(Subscribe subscribe)
        {
            var existing = _context.Subscribes.Find(subscribe.SubscribeId);
            if (existing == null)
            {
                return NotFound("Abone bulunamadı.");
            }
            existing.Email = subscribe.Email;
            existing.IsActive = subscribe.IsActive;
            _context.SaveChanges();
            return Ok("Abone güncelleme işlemi başarıyla gerçekleşti.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var subscribe = _context.Subscribes.Find(id);
            if (subscribe == null)
            {
                return NotFound("Abone bulunamadı.");
            }
            _context.Subscribes.Remove(subscribe);
            _context.SaveChanges();
            return Ok("Abone silme işlemi başarıyla gerçekleşti.");
        }

        [HttpGet("count-subscribe")]
        public async Task<IActionResult> GetSubscribeCount()
        {
            var count = await _context.Subscribes.CountAsync();
            return Ok(count);
        }
    }
}
