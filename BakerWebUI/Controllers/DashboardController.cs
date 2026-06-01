using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Baker.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var baseUrl = "https://localhost:7098/api"; 

            ViewBag.ProductCount = await GetCount(client, $"{baseUrl}/Product/count-product");
            ViewBag.CategoryCount = await GetCount(client, $"{baseUrl}/Category/count-category");
            ViewBag.ChefCount = await GetCount(client, $"{baseUrl}/Chef/count-chef");
            ViewBag.ServiceCount = await GetCount(client, $"{baseUrl}/Service/count-service");
            ViewBag.MessageCount = await GetCount(client, $"{baseUrl}/Message/count-message");
            ViewBag.GalleryCount = await GetCount(client, $"{baseUrl}/Gallery/count-gallery");
            ViewBag.SubscribeCount = await GetCount(client, $"{baseUrl}/Subscribe/count-subscribe");
            ViewBag.TestimonialCount = await GetCount(client, $"{baseUrl}/Testimonial/count-testimonial");

            return View();
        }

        private async Task<int> GetCount(HttpClient client, string url)
        {
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return int.Parse(json);
                }
            }
            catch { }
            return 0;
        }
    }
}