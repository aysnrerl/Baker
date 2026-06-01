using BakerWebUI.Dtos.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BakerWebUI.ViewComponents
{
    public class _DefaultFeatureComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;//API çağrıları için HttpClientFactory kullanımı

        public _DefaultFeatureComponentPartial(IHttpClientFactory httpClientFactory)//Dependency Injection ile HttpClientFactory'yi alıyoruz.
            //Dependency Injection, uygulamanın bağımlılıklarını yönetmek ve çözmek için kullanılan bir tasarım desenidir.
            //Bu sayede sınıflar arasındaki bağımlılıkları azaltarak daha esnek ve test edilebilir bir kod yapısı oluşturabiliriz.
   
        {
            _httpClientFactory = httpClientFactory;//HttpClientFactory, HttpClient nesnelerini yönetmek ve yeniden kullanmak için kullanılan bir fabrika sınıfıdır.
        }

        public async Task<IViewComponentResult> InvokeAsync()//Invoke metodu, ViewComponent'ın çalıştırıldığında çağrılan ana metottur.
            //Bu metot, genellikle verileri alır ve ilgili view'ı döndürür.
        {
            var client = _httpClientFactory.CreateClient();//API'ye istek yapmak için HttpClient nesnesi oluşturuyoruz.
            var responseMessage = await client.GetAsync("https://localhost:7098/api/Feature");//Bilgileri API'den almak için API'ye GET isteği gönderiyoruz.
            if (responseMessage.IsSuccessStatusCode)//API çağrısının başarılı olup olmadığını kontrol ediyoruz.
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//API'den dönen JSON verisini string olarak okuyoruz.
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);//JSON verisini, uygulamamızda kullanabileceğimiz bir nesne listesine dönüştürüyoruz.
                //burada dto oluşturmamız gerekiyor. API'den dönen JSON verisini, uygulamamızda kullanabileceğimiz bir nesne listesine dönüştürüyoruz.
                return View(values);//Dönüştürdüğümüz nesne listesini view'a gönderiyoruz.

            }
            return View();
        }
    }
}
