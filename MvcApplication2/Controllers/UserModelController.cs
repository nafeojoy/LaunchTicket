using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Models
{
    public class UserModelController : Controller
    {
        private LaunchDBContext db = new LaunchDBContext();
        //
        // GET: /UserModel/

        public ActionResult Register()
        {
            return View();
        }

        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Register(UserModel U) 
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (LaunchDBContext db = new LaunchDBContext()) 
        //        {
        //            db.customer.Add(U);

        //            db.SaveChanges();
        //            ModelState.Clear();
        //            U = null;
        //            ViewBag.Message = " Successfully Registration Done ";

        //        }
        //    }
        //    return View(U);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                //db.customer.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticket);
        }
    }
}
