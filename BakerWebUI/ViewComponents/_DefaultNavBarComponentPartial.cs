using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BakerWebUI.ViewComponents
{
    public class _DefaultNavBarComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultNavBarComponentPartial (IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://localhost:7098/api/AddressInfo");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var addresses = JsonConvert.DeserializeObject<List<dynamic>>(json);
                    if (addresses != null && addresses.Count > 0)
                    {
                        ViewBag.Phone = addresses[0].phone;
                    }
                }
            }
            catch { }
            return View();
        }
    }
}
