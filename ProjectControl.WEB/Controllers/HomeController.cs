using Microsoft.AspNetCore.Mvc;

namespace ProjectControl.WEB.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index() => await Task.Run(() => View());

        public async Task<IActionResult> Projects() => await Task.Run(() => View());

        public async Task<IActionResult> Employees() => await Task.Run(() => View());
    }
}
