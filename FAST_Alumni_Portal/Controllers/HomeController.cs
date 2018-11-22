using FAST_Alumni_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;





namespace FAST_Alumni_Portal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult AboutUs()
        {
            ViewBag.Title = "About Us";

            return View();
        }
        public ActionResult MyAccount()
        {
            ViewBag.Title = "My Account";

            return View();
        }

        public ActionResult ContactUs()
        {
            ViewBag.Title = "Contact Us";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ContactUs(ContactUsModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("fastalumniportal@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("fastalumniportal@gmail.com");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential
                    ("fastalumniportal@gmail.com", "sheridan18$");

                    smtp.EnableSsl = true;

                    smtp.Send(message);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
/*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyAccount(LogInModel u)
        {
            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {
                
            }
            return View(u);
        }*/

    }
}
