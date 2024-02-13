using HotelProject.WebUI.Dtos.ServiceDto;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HotelProject.WebUI.Models.Staff;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://mustafabalkaya.com.tr/api/Service");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);

            }
            return View();
        }
        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddService(CreateServiceDto createServiceDto)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createServiceDto);
            StringContent stringcontent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsemessage = await client.PostAsync("https://mustafabalkaya.com.tr/api/Service", stringcontent);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();

        }
        public async Task<IActionResult> DeleteService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.DeleteAsync($"https://mustafabalkaya.com.tr/api/Service/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://mustafabalkaya.com.tr/api/Service/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsondata);
                return View(values);

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateServiceDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsemessage = await client.PutAsync("https://mustafabalkaya.com.tr/api/Service/", stringContent);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
