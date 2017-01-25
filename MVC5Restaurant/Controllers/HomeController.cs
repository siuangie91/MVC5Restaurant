using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Restaurant.Models;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace MVC5Restaurant.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("About")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //[Route("Contact")]
        //public ActionResult Contact()
        //{
        //    return View();
        //}

        public ActionResult Success()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Send(EmailSender e)
        {
            if(ModelState.IsValid)
            {
                var smtp = new SmtpClient();

                var body = "<p><b><u>Email From:</u></b> {0} ({1})</p><p><b><u>Message:</u></b></p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("angiesiudevworks@gmail.com"));
                message.From = new MailAddress(e.Email.ToString());
                message.Subject = "MVC5DessertCafe: " + e.Subject.ToString();
                message.Body = string.Format(body, e.Name, e.Email, e.Body);
                message.IsBodyHtml = true;

                await smtp.SendMailAsync(message);

                return RedirectToAction("Success");

            }
            return RedirectToAction("About", "Home");
            
        }
    }
}