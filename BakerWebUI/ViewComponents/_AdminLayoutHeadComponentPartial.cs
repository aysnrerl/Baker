using BakerWebUI.Dtos.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BakerWebUI.ViewComponents
{
    public class _AdminLayoutHeadComponentPartial : ViewComponent
    { 
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
