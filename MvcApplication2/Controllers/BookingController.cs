using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.DAL;

namespace MvcApplication2.Controllers
{
    public class BookingController : Controller
    {

        private LaunchDBContext db = new LaunchDBContext();
        
        //
        // GET: /Booking/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Book(int id,int type)
        {
            Ticket ticket=db.Tickets.Find(id);

            customer custobj = db.customers.Find(Convert.ToInt32(Session["UserID"]));

            CustomerTicket custticket = new CustomerTicket();
            custticket.CustomerID = custobj.ID;
            custticket.TicketID = ticket.L_ID;
            custticket.CreatedDate = DateTime.Today;
            db.CustomerTickets.Add(custticket);
            db.SaveChanges();
            if (custobj !=null)
            {
                EMail omail = new EMail();
                try
                {
                    string sub = "";
                    string Fare = "";
                    string UN = "";
                    string Start = "";
                    string Destination = "";
                    string LN = "";
                    string DT = "";
                    string Time = "";

                    if (type==1)
                    {
                        sub = "Deck Fare";
                        Fare += ticket.Fare_Deck;

                        UN += custobj.user_name;
                        Start += ticket.Start;
                        Destination += ticket.Destination;
                        DT += ticket.Dept_Time;
                        LN += ticket.L_Name;
                        

                    }
                    if (type == 3)
                    {
                        sub = "Cabin Fare";
                        Fare += ticket.Fare_Cabin;


                        UN += custobj.user_name;
                        Start += ticket.Start;
                        Destination += ticket.Destination;
                        DT += ticket.Dept_Time;
                        LN += ticket.L_Name;
                        
                    }
                    if (type == 2)
                    {
                        sub = "First Class Fare";
                        Fare += ticket.Fare_1st_Class;

                        UN += custobj.user_name;
                        Start += ticket.Start;
                        Destination += ticket.Destination;
                        DT += ticket.Dept_Time;
                        LN += ticket.L_Name;
                        

                    }

                    omail.SendMail("Email", custobj.email, new string[] { sub, UN , Start , Destination , DT , LN , Fare }); 
                }
                catch (Exception)
                {
                    
                    throw;
                }
            return View(ticket);  
            }

            if (Session["UserID"] != null)
            {
                ViewBag.User = "1";
                ViewBag.UserName = Session["UserName"];
            }

            
            return View(ticket);
        
        }

    }
}
