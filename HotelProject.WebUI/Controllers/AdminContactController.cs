using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://mustafabalkaya.com.tr/api/Contact");

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://mustafabalkaya.com.tr/api/Contact/GetContactCount");

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://mustafabalkaya.com.tr/api/SendMessage/SendMessageCount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.contactCount = jsonData2;
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                ViewBag.sendMessageCount = jsonData3;

                return View(values);

            }
            return View();
        }
        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://mustafabalkaya.com.tr/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendBoxDto>>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessage model)
        {
            model.SenderMail = "admin@gmail.com";
            model.SenderName = "admin";
            model.Date = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(model);
            StringContent stringcontent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsemessage = await client.PostAsync("https://mustafabalkaya.com.tr/api/SendMessage", stringcontent);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");

            }
            return View();

        }
        public PartialViewResult SidebarAdminContactPartial()
        {
            return PartialView();
        }
        public PartialViewResult SidebarAdminContactCategoryPartial()
        {
            return PartialView();
        }
        public async Task< IActionResult> MessageDetailsBySendBox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://mustafabalkaya.com.tr/api/SendMessage/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsondata);
                return View(values);

            }
            return View();
        }
        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://mustafabalkaya.com.tr/api/Contact/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsondata);
                return View(values);

            }
            return View();
        }
        ////public async Task<IActionResult> GetContactCount()
        ////{
        ////    var client = _httpClientFactory.CreateClient();
        ////    var responseMessage = await client.GetAsync("https://mustafabalkaya.com.tr/api/Contact/GetContactCount");
        ////    if (responseMessage.IsSuccessStatusCode)
        ////    {
        ////        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        ////        var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
        ////        return View(values);

        ////    }
        ////    return View();
        ////}
    }
}
