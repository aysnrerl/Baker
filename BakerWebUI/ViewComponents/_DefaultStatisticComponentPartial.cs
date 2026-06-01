using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace BakerWebUI.ViewComponents
{
    public class _DefaultStatisticComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7098/api/Product/count-product");
            var jsonString = await response.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonString;

            var response2 = await client.GetAsync("https://localhost:7098/api/Chef/count-chef");
            var jsonString2 = await response2.Content.ReadAsStringAsync();
            ViewBag.ChefCount = jsonString2;

            return View();

        }
    }
}