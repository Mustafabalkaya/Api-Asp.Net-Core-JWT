using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace HotelProject.WebUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel viewModel = new UserEditViewModel();
            viewModel.Name = user.Name;
            viewModel.Surname = user.SurName;
            viewModel.Username = user.UserName;
            viewModel.Email = user.Email;
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            if (userEditViewModel.Password == userEditViewModel.Confirmpassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.UserName = userEditViewModel.Name;
                user.SurName = userEditViewModel.Surname;
                user.Email = userEditViewModel.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }




    }
}
