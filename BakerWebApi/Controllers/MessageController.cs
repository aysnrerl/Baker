using BakerWebApi.Context;
using BakerWebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly BakerContext _context;

        public MessageController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var value = _context.Messages.ToList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var message = _context.Messages.Find(id);
            if (message == null)
            {
                return NotFound("Mesaj bulunamadı.");
            }
            return Ok(message);
        }

        [HttpPost]
        public IActionResult Create(Message message)
        {
            message.SendDate = DateTime.Now;
            message.IsRead = false;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return Ok("Mesaj gönderme işlemi başarıyla gerçekleşti.");
        }

        [HttpPut]
        public IActionResult Update(Message message)
        {
            var existing = _context.Messages.Find(message.MessageId);
            if (existing == null)
            {
                return NotFound("Mesaj bulunamadı.");
            }
            existing.Name = message.Name;
            existing.Email = message.Email;
            existing.Subject = message.Subject;
            existing.Content = message.Content;
            existing.IsRead = message.IsRead;
            _context.SaveChanges();
            return Ok("Mesaj güncelleme işlemi başarıyla gerçekleşti.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var message = _context.Messages.Find(id);
            if (message == null)
            {
                return NotFound("Mesaj bulunamadı.");
            }
            _context.Messages.Remove(message);
            _context.SaveChanges();
            return Ok("Mesaj silme işlemi başarıyla gerçekleşti.");
        }

        [HttpGet("mark-as-read/{id}")]
        public IActionResult MarkAsRead(int id)
        {
            var message = _context.Messages.Find(id);
            if (message == null)
            {
                return NotFound("Mesaj bulunamadı.");
            }
            message.IsRead = true;
            _context.SaveChanges();
            return Ok("Mesaj okundu olarak işaretlendi.");
        }

        [HttpGet("count-message")]
        public async Task<IActionResult> GetMessageCount()
        {
            var count = await _context.Messages.CountAsync(m => !m.IsRead);
            return Ok(count);
        }
    }
}
