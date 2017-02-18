using MvcApplication2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class FeedBackController : Controller
    {
        //
        // GET: /FeedBack/
        [HttpPost]
        public ActionResult Index(string SName, string SEmail, string SSubject, string SMessage)
        
        {
            string SN = SName;
            string SE = SEmail;
            string SS = SSubject;
            string SM = SMessage;

            EMail omail = new EMail();

            omail.SendMail("FeedBack","nafeo@live.com", new string[] { SN,SE,SS,SM }); 
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                ViewBag.User = "1";
                ViewBag.UserName = Session["UserName"];
            }
            
            return View();
        }
        [HttpPost]
        public ActionResult GiveFeedBack(string SName, string SEmail, string SSubject, string SMessage)
        {

            string SN = SName;
            string SE = SEmail;
            string SS = SSubject;
            string SM = SMessage;

            EMail omail = new EMail();
            try
            {
                omail.SendMail("FeedBack", "nafeo@live.com", new string[] { SN, SE, SS, SM });
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
                
            }

            return RedirectToAction("Index");
        }

    }
}
