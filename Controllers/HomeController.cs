using EADAPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EADAPortal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult DownloadTeam()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files/team-details-demo.pdf");
            if (!System.IO.File.Exists(path))
            {
                return NotFound();
            }
            var bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/pdf", "Team-Details.pdf");
        }
    }
}
