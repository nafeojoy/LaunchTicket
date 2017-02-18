using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.DAL;

namespace MvcApplication2.Controllers
{
    public class TicketController : Controller
    {
        //
        // GET: /Ticket/

        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                ViewBag.User = "1";
                ViewBag.UserName = Session["UserName"];
            }

            List<TrainDetailsModel> trainList = new TrainDetailsDAL().SelecAllTrains();
            return View(trainList);
        }

        [HttpGet]
        public ActionResult ManageSeat(int trainID = 1)
        {
            if (Session["UserID"] != null)
            {
                ViewBag.User = "1";
                ViewBag.UserName = Session["UserName"];
            }

            TrainDetailsModel trainInfo = new TrainDetailsDAL().SelectTrain(trainID);
            Session["trainName"] = trainInfo.trainName;
            Session["departurePlace"] = trainInfo.departurePlace;
            Session["destinationPlace"] = trainInfo.destinationPlace;
            Session["departureTime"] = trainInfo.departureTime;
            Session["fare"] = trainInfo.fare;
            List<BogieModel> bogieList = new TrainDetailsDAL().SelecBogieByTrainID(trainID);
            return View(bogieList);
        }

        [HttpGet]
        public ActionResult _SeatDetails(int bogieID)
        {

            if (Session["UserID"] != null)
            {
                ViewBag.User = "1";
                ViewBag.UserName = Session["UserName"];
            }
            else
            {
                ViewBag.User = "0";
            }
            List<SeatModel> SeatList = new TrainDetailsDAL().SelectSeatByBogieID(bogieID);
            return PartialView(SeatList);

        }
        [HttpGet]
        public ActionResult BookTicket(int seatID, string seatNumber, int bogieID)
        {
            if (Session["UserID"] != null)
            {

                if (Session["seatNumber"] != null)
                {
                    Session["seatNumber"] = Session["seatNumber"].ToString() + " | " + seatNumber;
                }
                else
                {
                    Session["seatNumber"] = seatNumber;
                }
                ViewBag.User = "1";
                ViewBag.UserName = Session["UserName"];
                SeatModel seatModel = new SeatModel();
                seatModel.ID = seatID;
                seatModel.IsAvailable = false;
                seatModel.SeatNumber = seatNumber;
                seatModel.BogieID = bogieID;

                new TrainDetailsDAL().UpdateSeat(seatModel);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }


        }

    }
}
