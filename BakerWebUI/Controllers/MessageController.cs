using BakerWebUI.Dtos.Messages;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BakerWebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MessageList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7098/api/Message");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageDto>>(json);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> MessageDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();

            await client.GetAsync($"https://localhost:7098/api/Message/mark-as-read/{id}");

            var response = await client.GetAsync($"https://localhost:7098/api/Message/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultMessageDto>(json);
                return View(value);
            }
            return RedirectToAction("MessageList");
        }

        public async Task<IActionResult> DeleteMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7098/api/Message/{id}");
            return RedirectToAction("MessageList");
        }
    }
}
