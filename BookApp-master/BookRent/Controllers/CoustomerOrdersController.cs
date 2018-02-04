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
    public class CoustomerOrdersController : Controller
    {
        private Entity db = new Entity();

        // GET: CoustomerOrders
        public ActionResult Index()
        {
            var coustomerOrder = db.CoustomerOrder.Include(c => c.CoustomerDetails);
            return View(coustomerOrder.ToList());
        }

        // GET: CoustomerOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoustomerOrder coustomerOrder = db.CoustomerOrder.Find(id);
            if (coustomerOrder == null)
            {
                return HttpNotFound();
            }
            return View(coustomerOrder);
        }

        // GET: CoustomerOrders/Create
        public ActionResult Create()
        {
            ViewBag.CoustomerId = new SelectList(db.CoustomerDetails, "CoustomerId", "Phone");
            return View();
        }

        // POST: CoustomerOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,CoustomerId,OrderDate")] CoustomerOrder coustomerOrder)
        {
            if (ModelState.IsValid)
            {
                db.CoustomerOrder.Add(coustomerOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoustomerId = new SelectList(db.CoustomerDetails, "CoustomerId", "Phone", coustomerOrder.CoustomerId);
            return View(coustomerOrder);
        }

        // GET: CoustomerOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoustomerOrder coustomerOrder = db.CoustomerOrder.Find(id);
            if (coustomerOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoustomerId = new SelectList(db.CoustomerDetails, "CoustomerId", "Phone", coustomerOrder.CoustomerId);
            return View(coustomerOrder);
        }

        // POST: CoustomerOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,CoustomerId,OrderDate")] CoustomerOrder coustomerOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coustomerOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CoustomerId = new SelectList(db.CoustomerDetails, "CoustomerId", "Phone", coustomerOrder.CoustomerId);
            return View(coustomerOrder);
        }

        // GET: CoustomerOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoustomerOrder coustomerOrder = db.CoustomerOrder.Find(id);
            if (coustomerOrder == null)
            {
                return HttpNotFound();
            }
            return View(coustomerOrder);
        }

        // POST: CoustomerOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoustomerOrder coustomerOrder = db.CoustomerOrder.Find(id);
            db.CoustomerOrder.Remove(coustomerOrder);
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
