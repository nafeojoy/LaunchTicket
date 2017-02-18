using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.DAL;

namespace MvcApplication2.Controllers
{
    public class SignupController : Controller
    {
        //
        // GET: /Signup/
        public LaunchDBContext db = new LaunchDBContext();

        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                ViewBag.User = "1";
                ViewBag.UserName = Session["UserName"];
            }
            return View();
        }

        //public ActionResult SignUpSuccessful()
        //{

        //    return View();

        //}

        //public ActionResult SignupError()
        //{

        //    return View();

        //}

        //public ActionResult Verification()
        //{

        //    return View();

        //}

        [HttpPost]
        public ActionResult Index(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                new UserDAL().Save(userModel);
                Session["UserID"] = new DbHelperClass().GetNextID("customer", "ID") - 1;
                Session["UserName"] = userModel.user_name;
                ViewBag.UserName = userModel.user_name;
                return RedirectToAction("Welcome", "Home", null);
            }
            else
            {
                return View(userModel);
            }

        }

        //public ActionResult Save(UserModel user)
        //{
        //    customer custobj = new customer();
        //    custobj.first_name = user.first_name;
        //    custobj.last_name = user.last_name;
        //    custobj.gender = user.gender;
        //    custobj.email = user.email;
        //    custobj.contact_no = user.contact_no;
        //    custobj.address = user.address;
        //    custobj.password = user.password;
        //    custobj.confirmpassword = user.confirmpassword;
        //    custobj.occupation = "Nai";
        //    custobj.user_name = user.first_name + " " + user.last_name;
        //    db.customers.Add(custobj);



        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {

        //        return RedirectToAction("SignupError");
        //    }



        //    return RedirectToAction("SignUpSuccessful");

        //}
    }
}
