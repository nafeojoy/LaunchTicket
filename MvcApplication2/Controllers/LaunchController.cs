﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace MvcApplication2.Models
{
    public class LaunchController : Controller
    {
        private LaunchDBContext db = new LaunchDBContext();

        //
        // GET: /Ticket/

        public ActionResult Index(string Start, string Destination, TimeSpan? Dept_Time, string Date)
        {

            //string DATE = Convert.ToString(date);

            if (Session["UserID"] != null)
            {
                ViewBag.User = "1";
                ViewBag.UserName = Session["UserName"];
            }
            ViewBag.Start = (from r in db.Tickets
                             select r.Start).Distinct();

            ViewBag.Destination = (from r in db.Tickets
                                   select r.Destination).Distinct();

            
            
            ViewBag.Dept_Time = (from r in db.Tickets
                                 select r.Dept_Time).Distinct();
            ViewBag.Date = (from r in db.Tickets
                            select r.Date).Distinct();

            

            var model = (from r in db.Tickets

                        where r.Destination == Destination || Destination == null || Destination == ""
                        where r.Start == Start || Start == null || Start == ""
                        where r.Dept_Time == Dept_Time || Dept_Time == null
                         where r.Date == Date || Date == null || Date == ""
                         
                        select r).ToList();

            foreach (Ticket item in model)
            {
                
                    item.TotalTicket = item.Max.Value  - (from ut in db.CustomerTickets where ut.CreatedDate == DateTime.Today & ut.TicketID == item.L_ID select ut).Count();
                    
}
             
            return View(model);
            //return View(db.Tickets.ToList());
        }

        //
        // GET: /Ticket/Details/5

        public ActionResult Details(int id = 0)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        //
        // GET: /Ticket/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Ticket/Create

        [HttpPost]
        public ActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticket);
        }

        //
        // GET: /Ticket/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        //
        // POST: /Ticket/Edit/5

        [HttpPost]
        public ActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        //
        // GET: /Ticket/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        //
        // POST: /Ticket/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}