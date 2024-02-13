using HotelProject.WebUI.Models.Staff;
using HotelProject.WebUI.Models.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://mustafabalkaya.com.tr/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(jsonData);
                return View(values);

            }
            return View();
        }
        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTestimonial(TestimonialViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(model);
            StringContent stringcontent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsemessage = await client.PostAsync("https://mustafabalkaya.com.tr/api/Testimonial", stringcontent);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();

        }
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.DeleteAsync($"https://mustafabalkaya.com.tr/api/Testimonial/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://mustafabalkaya.com.tr/api/Testimonial/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TestimonialViewModel>(jsondata);
                return View(values);

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(TestimonialViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsemessage = await client.PutAsync("https://mustafabalkaya.com.tr/api/Testimonial/", stringContent);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
