using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]

    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult _SubscribePartial()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto createSubscribeDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createSubscribeDto);
            StringContent stringcontent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            await client.PostAsync("https://mustafabalkaya.com.tr/api/Subscsribe", stringcontent);
            return RedirectToAction("Index", "Default");



        }

    }
}
