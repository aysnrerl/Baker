using BakerWebUI.Dtos.Notifications;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BakerWebUI.Controllers
{
    public class NotificationController : Controller
    {
            private readonly IHttpClientFactory _httpClientFactory;

            public NotificationController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            public async Task<IActionResult> NotificationList()
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://localhost:7098/api/Notification");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(json);
                    return View(values);
                }
                return View();
            }

            public async Task<IActionResult> DeleteNotification(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.DeleteAsync($"https://localhost:7098/api/Notification/{id}");
                return RedirectToAction("NotificationList");
            }
    }
}
