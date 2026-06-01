using BakerWebUI.Dtos.Features; // Kendi DTO namespace'ine göre düzenle
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BakerWebUI.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        public async Task<IActionResult> FeatureList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7098/api/Feature");
            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsondata);
                return View(values);
            }
            return View();
        }

       
        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7098/api/Feature", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("FeatureList");
            }
            return View(model);
        }

     
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7098/api/Feature/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(int id, UpdateFeatureDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7098/api/Feature", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("FeatureList");
            }
            return View(model);
        }

        
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7098/api/Feature/" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("FeatureList");
            }
            return RedirectToAction("FeatureList");
        }
    }
}