using BakerWebUI.Dtos.Subscribe;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BakerWebUI.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SubscribeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        public async Task<IActionResult> SubscribeList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7098/api/Subscribe");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSubscribeDto>>(json);
                return View(values);
            }
            return View(new List<ResultSubscribeDto>());
        }

        [HttpPost]
        public async Task<IActionResult> AddSubscribe(string email)
        {
            
            if (string.IsNullOrEmpty(email))
            {
                return Redirect(Request.Headers["Referer"].ToString());
            }

            var client = _httpClientFactory.CreateClient();

            var model = new { EMail = email };
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            
            var response = await client.PostAsync("https://localhost:7098/api/Subscribe", content);

            
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> DeleteSubscribe(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7098/api/Subscribe/{id}");
            return RedirectToAction("SubscribeList");
        }
    }
}