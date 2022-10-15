using Microsoft.AspNetCore.Mvc;

namespace ProjectControl.WEB.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index() => await Task.Run(() => View());

        [HttpGet]
        public async Task<IActionResult> Projects()
        {
            ViewBag.Title = "Projects";
            return await Task.Run(() => View("ApiShared"));
        }

        [HttpGet]
        public async Task<IActionResult> Employees()
        {
            ViewBag.Title = "Employees";
            return await Task.Run(() => View("ApiShared"));
        }
    }
}
