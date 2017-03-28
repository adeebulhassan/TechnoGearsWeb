using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using technogears.Models;

namespace technogears.Controllers
{
    public class HomeController : Controller
    {






        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
       

        [HttpPost]  
        public IActionResult Index(email e)
        {
            var messag = new MailMessage();
            messag.From = new MailAddress("adeeeb.ul.hassan@gmail.com", "TechnoGears");

            messag.To.Add(new MailAddress("bilal.qudoos@technogears.net"));
            messag.To.Add(new MailAddress("adeeb.hassan@technogears.net"));
            messag.To.Add(new MailAddress("husnain.ashraf@technogears.net"));
            messag.To.Add(new MailAddress("info@technogears.net"));

            // message.CC.ad
            //message.Bcc.Add
            messag.Subject = e.subject;

            messag.Body = "<h1>Hi, " + e.name + "<br>" + e.message + " <br> <br>sender email" + e.emaill;
            messag.IsBodyHtml = true;

            SmtpClient SC = new SmtpClient();
            SC.Credentials = new NetworkCredential
            {
                UserName = "adeeeb.ul.hassan@gmail.com",  // replace with valid value
                Password = "Gmail123@#"// replace with valid value
            };
            SC.Host = "smtp.gmail.com";
            SC.Port = 587;
            SC.EnableSsl = true;

            try
            {
                SC.Send(messag);
            }
            catch (Exception ex)
            {

            }
            return View();
        }


       

        public IActionResult Error()
        {
            return View();
        }
    }
}
