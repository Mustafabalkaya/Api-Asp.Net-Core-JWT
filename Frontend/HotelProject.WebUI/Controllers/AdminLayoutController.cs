using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.wwwroot.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult _AdminLayout()
        {
            return View();
        }
    }
}
