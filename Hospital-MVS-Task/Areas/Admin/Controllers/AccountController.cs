using Microsoft.AspNetCore.Mvc;

namespace Hospital_MVS_Task.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
