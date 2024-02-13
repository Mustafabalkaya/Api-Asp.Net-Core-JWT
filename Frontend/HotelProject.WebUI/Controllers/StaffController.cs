using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.wwwroot.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
