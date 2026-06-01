using BakerWebApi.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly BakerContext _context;

        public AdminController(BakerContext context)
        {
            _context = context;
        }

        [HttpDelete("reset-database")]
        public IActionResult ResetDatabase()
        {
            
            _context.Database.ExecuteSqlRaw("DELETE FROM Products");
            _context.Database.ExecuteSqlRaw("DELETE FROM Categories");
            _context.Database.ExecuteSqlRaw("DELETE FROM Chefs");
            _context.Database.ExecuteSqlRaw("DELETE FROM Services");
            _context.Database.ExecuteSqlRaw("DELETE FROM Testimonials");
            _context.Database.ExecuteSqlRaw("DELETE FROM Galleries");
            _context.Database.ExecuteSqlRaw("DELETE FROM Messages");
            _context.Database.ExecuteSqlRaw("DELETE FROM Abouts");
            _context.Database.ExecuteSqlRaw("DELETE FROM AddressInfos");
            _context.Database.ExecuteSqlRaw("DELETE FROM Notifications");
            _context.Database.ExecuteSqlRaw("DELETE FROM Subscribes");

            try { _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Products', RESEED, 0)"); } catch { }
            try { _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Categories', RESEED, 0)"); } catch { }
            try { _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Chefs', RESEED, 0)"); } catch { }
            try { _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Services', RESEED, 0)"); } catch { }
            try { _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Testimonials', RESEED, 0)"); } catch { }
            try { _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Galleries', RESEED, 0)"); } catch { }
            try { _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Messages', RESEED, 0)"); } catch { }
            try { _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Abouts', RESEED, 0)"); } catch { }
            try { _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('AddressInfos', RESEED, 0)"); } catch { }
            try { _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Notifications', RESEED, 0)"); } catch { }
            try { _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Subscribes', RESEED, 0)"); } catch { }

            return Ok("Veritabani sifirlandi.");
        }
    }
}
