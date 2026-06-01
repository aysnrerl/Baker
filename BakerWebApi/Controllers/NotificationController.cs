using BakerWebApi.Context;
using BakerWebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly BakerContext _context;

        public NotificationController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var value = _context.Notifications.ToList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var notification = _context.Notifications.Find(id);
            if (notification == null)
            {
                return NotFound("Bildirim bulunamadı.");
            }
            return Ok(notification);
        }

        [HttpPost]
        public IActionResult Create(Notification notification)
        {
            notification.CreatedDate = DateTime.Now;
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            return Ok("Bildirim ekleme işlemi başarıyla gerçekleşti.");
        }

        [HttpPut]
        public IActionResult Update(Notification notification)
        {
            var existing = _context.Notifications.Find(notification.NotificationId);
            if (existing == null)
            {
                return NotFound("Bildirim bulunamadı.");
            }
            existing.Title = notification.Title;
            existing.Description = notification.Description;
            existing.IsRead = notification.IsRead;
            _context.SaveChanges();
            return Ok("Bildirim güncelleme işlemi başarıyla gerçekleşti.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var notification = _context.Notifications.Find(id);
            if (notification == null)
            {
                return NotFound("Bildirim bulunamadı.");
            }
            _context.Notifications.Remove(notification);
            _context.SaveChanges();
            return Ok("Bildirim silme işlemi başarıyla gerçekleşti.");
        }

        [HttpGet("count-notification")]
        public async Task<IActionResult> GetNotificationCount()
        {
            var count = await _context.Notifications.CountAsync();
            return Ok(count);
        }
    }
}
