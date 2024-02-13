using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class GuestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GuestController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://mustafabalkaya.com.tr/api/Guest");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);
                return View(values);

            }
            return View();
        }
        [HttpGet]
        public IActionResult AddGuest()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGuest(CreateGuestDto model)
        {
            if (ModelState.IsValid)
            {


                var client = _httpClientFactory.CreateClient();
                var jsondata = JsonConvert.SerializeObject(model);
                StringContent stringcontent = new StringContent(jsondata, Encoding.UTF8, "application/json");
                var responsemessage = await client.PostAsync("https://mustafabalkaya.com.tr/api/Guest", stringcontent);
                if (responsemessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
                return View();
            }
            else
            {
                return View();

            }

        }
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.DeleteAsync($"https://mustafabalkaya.com.tr/api/Guest/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://mustafabalkaya.com.tr/api/Guest/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateGuestDto>(jsondata);
                return View(values);

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGuest(UpdateGuestDto model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsondata = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
                var responsemessage = await client.PutAsync("https://mustafabalkaya.com.tr/api/Guest/", stringContent);
                if (responsemessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
                return View();
            }
            return View();
        }
    }
}
