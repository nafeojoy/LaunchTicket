using MvcApplication2.DatabaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.DAL;

namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            if (Session["UserID"] != null)
            {
                ViewBag.User = "1";
                ViewBag.UserName = Session["UserName"];
            }
            return View();
        }

        public ActionResult TestUIElements()
        {

            return View();
        }


        public ActionResult Welcome()
        {

            if (Session["UserID"] != null)
            {
                ViewBag.User = "1";
                ViewBag.UserName = Session["UserName"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home", null);
            }

        }

        public ActionResult Profile()
        {
            if (Session["UserID"] != null)
            {
                ViewBag.User = "1";
                ViewBag.UserName = Session["UserName"];
                try
                {
                    UserModel userModel = new UserDAL().SelectUser((Session["UserID"] != null) ? Convert.ToInt16(Session["UserID"].ToString()) : 1);
                    return View(userModel);
                }
                catch
                {
                    return View();
                }

            }
            else
            {
                return RedirectToAction("Login", "Home", null);
            }
        }


        [HttpPost]
        public ActionResult Profile(UserModel userModel)
        {
            if (Session["UserID"] != null)
            {
                ViewBag.User = "1";
                ViewBag.UserName = Session["UserName"];


                return RedirectToAction("", "", null);

            }
            else
            {
                return RedirectToAction("Login", "Home", null);
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            string dataString = "";
            int UserID = 0;
            if (ModelState.IsValid)
            {
                dataString = "select Count(*) from customer where user_name='" + loginModel.user_name + "' and password='" + loginModel.password + "'";
                int IsExist = new DbHelperClass().ExecuteScalerDataString(dataString);
                dataString = "";
                if (IsExist != 0)
                {
                    dataString = "select top 1 ID from customer where user_name='" + loginModel.user_name + "' and password='" + loginModel.password + "'";
                    UserID = new DbHelperClass().ExecuteScalerDataString(dataString);
                    dataString = "";
                    Session["UserID"] = UserID;
                    Session["UserName"] = loginModel.user_name;
                    return RedirectToAction("Profile", "Home", null);
                }
                else
                {
                    ModelState.AddModelError("user_name", "wrong username or password");
                    ModelState.AddModelError("password", "wrong username or password");
                    loginModel.user_name = "";
                    loginModel.password = "";
                    return View(loginModel);
                }
            }
            else
            {
                return View(loginModel);
            }
        }

        public ActionResult Signout()
        {
            Session.Abandon();
            return View();
        }

        public ActionResult CheckOut()
        {
            if (Session["UserID"] != null)
            {
                ViewBag.User = "1";
                ViewBag.UserName = Session["UserName"];
                if (Session["seatNumber"] != null)
                {
                    ViewBag.NoSeat = "1";
                    ViewBag.Seats = Session["seatNumber"].ToString();
                    ViewBag.trainName = Session["trainName"].ToString();
                    ViewBag.departurePlace = Session["departurePlace"].ToString();
                    ViewBag.destinationPlace = Session["destinationPlace"].ToString();
                    ViewBag.departureTime = Session["departureTime"].ToString();
                    //UserModel userInfo = new UserDAL().SelectUser(Convert.ToInt16(Session["UserID"].ToString()));
                    //string emailSubject = "Online Launch Ticket";
                    //string emailBody = "<h1>WELOCOME TO ONLINE LAUNCH TICKET SYSTEM</h1>"
                    //    + "<p>This is your desired ticket.</p>"
                    //    + "<p>write text that you want to show in email.</p>";
                    //Mailer.SendEmail(userInfo.email, emailSubject, emailBody);
                }
                else
                {
                    ViewBag.NoSeat = "0";
                }
                return PartialView();
            }
            else
            {
                return RedirectToAction("Login", "Home", null);
            }

        }
    }
}
