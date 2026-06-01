using BakerWebUI.Dtos.Products;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BakerWebUI.ViewComponents
{
    public class _DefaultProductComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultProductComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

          
            try
            {
                var addrResponse = await client.GetAsync("https://localhost:7098/api/AddressInfo");
                if (addrResponse.IsSuccessStatusCode)
                {
                    var addrJson = await addrResponse.Content.ReadAsStringAsync();
                    var addresses = JsonConvert.DeserializeObject<List<dynamic>>(addrJson);
                    if (addresses != null && addresses.Count > 0)
                    {
                        ViewBag.Phone = addresses[0].phone;
                    }
                }
            }
            catch { }

            var response = await client.GetAsync("https://localhost:7098/api/Product/with-category");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ProductWithCategoryDto>>(jsonString);
                return View(values);
            }
            return View();
        }
    }
}
