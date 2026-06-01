using BakerWebUI.Dtos.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BakerWebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public IActionResult Index()
        {
           
            return View();
        }

        

        public async Task<IActionResult> ServiceList()
        {
            var client = _httpClientFactory.CreateClient();
          
            var response = await client.GetAsync("https://localhost:7098/api/Service");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(json);
                return View(values);
            }
            return View(new List<ResultServiceDto>());
        }

        [HttpGet]
        public IActionResult CreateService() => View();

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync("https://localhost:7098/api/Service", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ServiceList");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            
            var responseMessage = await client.GetAsync($"https://localhost:7098/api/Service/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsondata);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
            var response = await client.PutAsync("https://localhost:7098/api/Service", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ServiceList");
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            
            await client.DeleteAsync($"https://localhost:7098/api/Service/{id}");
            return RedirectToAction("ServiceList");
        }
    }
}