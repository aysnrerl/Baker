using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.ViewComponents
{
    public class _AdminLayoutNavBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
