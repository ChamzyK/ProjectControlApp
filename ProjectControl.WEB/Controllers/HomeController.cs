using Microsoft.AspNetCore.Mvc;

namespace ProjectControl.WEB.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index() => await Task.Run(() => View());

        [HttpGet]
        public async Task<IActionResult> Projects() => await Task.Run(() => View());

        [HttpGet]
        public async Task<IActionResult> Employees() => await Task.Run(() => View());
    }
}
