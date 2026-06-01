using BakerWebApi.Context;
using BakerWebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BakerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressInfoController : ControllerBase
    {
        private readonly BakerContext _context;

        public AddressInfoController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AddressInfoList()
        {
            var value = _context.AddressInfos.ToList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var addressInfo = _context.AddressInfos.Find(id);
            if (addressInfo == null)
            {
                return NotFound("Adres bilgisi bulunamadı.");
            }
            return Ok(addressInfo);
        }

        [HttpPost]
        public IActionResult Create(AddressInfo addressInfo)
        {
            _context.AddressInfos.Add(addressInfo);
            _context.SaveChanges();
            return Ok("Adres bilgisi ekleme işlemi başarıyla gerçekleşti.");
        }

        [HttpPut]
        public IActionResult Update(AddressInfo addressInfo)
        {
            var existing = _context.AddressInfos.Find(addressInfo.AddressInfoId);
            if (existing == null)
            {
                return NotFound("Adres bilgisi bulunamadı.");
            }
            existing.Address = addressInfo.Address;
            existing.Phone = addressInfo.Phone;
            existing.Email = addressInfo.Email;
            existing.OpenHours = addressInfo.OpenHours;
            existing.MapUrl = addressInfo.MapUrl;
            _context.SaveChanges();
            return Ok("Adres bilgisi güncelleme işlemi başarıyla gerçekleşti.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var addressInfo = _context.AddressInfos.Find(id);
            if (addressInfo == null)
            {
                return NotFound("Adres bilgisi bulunamadı.");
            }
            _context.AddressInfos.Remove(addressInfo);
            _context.SaveChanges();
            return Ok("Adres bilgisi silme işlemi başarıyla gerçekleşti.");
        }
    }
}
