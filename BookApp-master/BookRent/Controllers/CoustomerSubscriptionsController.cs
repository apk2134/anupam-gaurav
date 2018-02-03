using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookEntity;

namespace BookRent.Controllers
{
    public class CoustomerSubscriptionsController : Controller
    {
        private Entity db = new Entity();

        // GET: CoustomerSubscriptions
        public ActionResult Index()
        {
            var coustomerSubscription = db.CoustomerSubscription.Include(c => c.CoustomerDetails).Include(c => c.Subscriptions);
            return View(coustomerSubscription.ToList());
        }

        // GET: CoustomerSubscriptions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoustomerSubscription coustomerSubscription = db.CoustomerSubscription.Find(id);
            if (coustomerSubscription == null)
            {
                return HttpNotFound();
            }
            return View(coustomerSubscription);
        }

        // GET: CoustomerSubscriptions/Create
        public ActionResult Create()
        {
            ViewBag.CoustomerId = new SelectList(db.CoustomerDetails, "CoustomerId", "Phone");
            ViewBag.SubscriptionId = new SelectList(db.Subscriptions, "SubscriptionID", "SubscriptionID");
            return View();
        }

        // POST: CoustomerSubscriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerSubscription,CoustomerId,SubscriptionId,booksTaken,booksRemaning")] CoustomerSubscription coustomerSubscription)
        {
            if (ModelState.IsValid)
            {
                db.CoustomerSubscription.Add(coustomerSubscription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoustomerId = new SelectList(db.CoustomerDetails, "CoustomerId", "Phone", coustomerSubscription.CoustomerId);
            ViewBag.SubscriptionId = new SelectList(db.Subscriptions, "SubscriptionID", "SubscriptionID", coustomerSubscription.SubscriptionId);
            return View(coustomerSubscription);
        }

        // GET: CoustomerSubscriptions/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoustomerSubscription coustomerSubscription = db.CoustomerSubscription.Find(id);
            if (coustomerSubscription == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoustomerId = new SelectList(db.CoustomerDetails, "CoustomerId", "Phone", coustomerSubscription.CoustomerId);
            ViewBag.SubscriptionId = new SelectList(db.Subscriptions, "SubscriptionID", "SubscriptionID", coustomerSubscription.SubscriptionId);
            return View(coustomerSubscription);
        }

        // POST: CoustomerSubscriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerSubscription,CoustomerId,SubscriptionId,booksTaken,booksRemaning")] CoustomerSubscription coustomerSubscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coustomerSubscription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CoustomerId = new SelectList(db.CoustomerDetails, "CoustomerId", "Phone", coustomerSubscription.CoustomerId);
            ViewBag.SubscriptionId = new SelectList(db.Subscriptions, "SubscriptionID", "SubscriptionID", coustomerSubscription.SubscriptionId);
            return View(coustomerSubscription);
        }

        // GET: CoustomerSubscriptions/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoustomerSubscription coustomerSubscription = db.CoustomerSubscription.Find(id);
            if (coustomerSubscription == null)
            {
                return HttpNotFound();
            }
            return View(coustomerSubscription);
        }

        // POST: CoustomerSubscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CoustomerSubscription coustomerSubscription = db.CoustomerSubscription.Find(id);
            db.CoustomerSubscription.Remove(coustomerSubscription);
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
