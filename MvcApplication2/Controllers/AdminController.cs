using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.DAL;
using MvcApplication2.Models;


namespace MvcApplication2.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserList()
        {
            List<UserModel> userList = new UserDAL().SelecAlltUser();
            return View(userList);
        }
    }
}
