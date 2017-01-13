using Kancelaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Kancelaria.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }

        
        public ActionResult Index ( QustionModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SmtpClient client = new SmtpClient
                    {
                        Port = 587,
                        Host = "smtp.gmail.com",
                        EnableSsl = true,
                        Timeout = 900000,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new System.Net.NetworkCredential("odszkodariusz@gmail.com", "maximus,.1222")
                    };
                    var objeto_mail = new MailMessage { From = new MailAddress("\"Odszkodowania " + model.imie + " " + model.nazwisko + "\" <odszkodariusz@gmail.com>") };
                    objeto_mail.To.Add(new MailAddress("odszkodariusz@gmail.com"));
                    objeto_mail.Subject = "Pytanie od klienta: " + model.imie + " " + model.nazwisko;
                    objeto_mail.Body = string.Format(model.question + "<br/><br/><br/>" + "<strong>Imię i nazwisko: </strong>"+ model.imie + " " + model.nazwisko  + "<br/>" + "<strong>Email klienta: </strong>" + model.emailAddress + "<br/>" + "<strong>Telefon Kontaktowy: </strong>" +model.tel);
                    objeto_mail.IsBodyHtml = true;
                    if (model.file != null)
                    {

                        objeto_mail.Attachments.Add(new Attachment(model.file));
                    }
                    client.Send(objeto_mail);

                }
                catch
                {
                    ModelState.AddModelError("", "Problem " + model.imie + " " + model.nazwisko + " " + model.emailAddress + " " + model.question);
                }
            }
            return RedirectToAction("Thanks", "Home", new { clientName = model.imie + " " + model.nazwisko });
        }


        public ActionResult Thanks(string clientName)
        {
            ViewBag.client = clientName;
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}