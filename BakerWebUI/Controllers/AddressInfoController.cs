using BakerWebUI.Dtos.AddressInfos;
using BakerWebUI.Dtos.Messages; 
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BakerWebUI.Controllers
{
    public class AddressInfoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AddressInfoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

          
            var response = await client.PostAsync("https://localhost:7098/api/Message", content);

            if (response.IsSuccessStatusCode)
            {
                
                return RedirectToAction("Index", "Default");
            }
            return View("Index", model);
        }

      

        public async Task<IActionResult> AddressInfoList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7098/api/AddressInfo");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAddressInfoDto>>(json);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateAddressInfo() => View();

        [HttpPost]
        public async Task<IActionResult> CreateAddressInfo(CreateAddressInfoDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7098/api/AddressInfo", content);

            if (response.IsSuccessStatusCode) return RedirectToAction("AddressInfoList");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAddressInfo(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7098/api/AddressInfo/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAddressInfoDto>(jsondata);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAddressInfo(UpdateAddressInfoDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7098/api/AddressInfo", content);

            if (response.IsSuccessStatusCode) return RedirectToAction("AddressInfoList");
            return View(model);
        }

        public async Task<IActionResult> DeleteAddressInfo(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7098/api/AddressInfo/{id}");
            return RedirectToAction("AddressInfoList");
        }
    }
}