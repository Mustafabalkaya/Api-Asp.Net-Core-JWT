using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Hotelier Admin", "balkayamustafa99@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAdressTo = new MailboxAddress("User", model.ReceiverMail);
            mimeMessage.To.Add(mailboxAdressTo);
            var bodybuilder= new BodyBuilder();
            bodybuilder.TextBody = model.Body;
            mimeMessage.Body=bodybuilder.ToMessageBody();
            mimeMessage.Subject=model.Subject;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587,false);
            smtpClient.Authenticate("balkayamustafa99@gmail.com", "nermpncjblbxfkkf");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);


            return View();
        }
    }
}
