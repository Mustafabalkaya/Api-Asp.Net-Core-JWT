using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://mustafabalkaya.com.tr/api/Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);
                return View(values);

            }
            return View();
        }
        [HttpGet]
        public IActionResult AddStaff() 
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(model);
            StringContent stringcontent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsemessage = await client.PostAsync("https://mustafabalkaya.com.tr/api/Staff", stringcontent);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();

        }
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.DeleteAsync($"https://mustafabalkaya.com.tr/api/Staff/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://mustafabalkaya.com.tr/api/Staff/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata=await responsemessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsondata);   
                return View(values);

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata=JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsondata,Encoding.UTF8,"application/json");
            var responsemessage = await client.PutAsync("https://mustafabalkaya.com.tr/api/Staff/", stringContent);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
