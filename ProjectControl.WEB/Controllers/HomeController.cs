using Microsoft.AspNetCore.Mvc;

namespace ProjectControl.WEB.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View());
        }
    }
}
