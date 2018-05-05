using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DW.Web.Models;

namespace DW.Web.Controllers
{
    public class DbDeliveryRquestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DbDeliveryRquests
        public ActionResult Index()
        {
            return View(db.DeliveryRequest.ToList());
        }

        // GET: DbDeliveryRquests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DbDeliveryRquest dbDeliveryRquest = db.DeliveryRequest.Find(id);
            if (dbDeliveryRquest == null)
            {
                return HttpNotFound();
            }
            return View(dbDeliveryRquest);
        }

        // GET: DbDeliveryRquests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DbDeliveryRquests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Filled,FullName,TimeDeliver,ClientAddress,TotalCost")] DbDeliveryRquest dbDeliveryRquest)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryRequest.Add(dbDeliveryRquest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dbDeliveryRquest);
        }

        // GET: DbDeliveryRquests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DbDeliveryRquest dbDeliveryRquest = db.DeliveryRequest.Find(id);
            if (dbDeliveryRquest == null)
            {
                return HttpNotFound();
            }
            return View(dbDeliveryRquest);
        }

        // POST: DbDeliveryRquests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Filled,FullName,TimeDeliver,ClientAddress,TotalCost")] DbDeliveryRquest dbDeliveryRquest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dbDeliveryRquest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dbDeliveryRquest);
        }

        // GET: DbDeliveryRquests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DbDeliveryRquest dbDeliveryRquest = db.DeliveryRequest.Find(id);
            if (dbDeliveryRquest == null)
            {
                return HttpNotFound();
            }
            return View(dbDeliveryRquest);
        }

        // POST: DbDeliveryRquests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DbDeliveryRquest dbDeliveryRquest = db.DeliveryRequest.Find(id);
            db.DeliveryRequest.Remove(dbDeliveryRquest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
