using Core.RepositoryAbstracts;
using Hospital_MVS_Task.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hospital_MVS_Task.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderRepository _sliderRepository;

        public HomeController(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

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
    }
}
