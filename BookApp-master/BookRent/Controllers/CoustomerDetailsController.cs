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
    [AuthorizationFilter.AuthorizationFilter]

    public class CoustomerDetailsController : Controller
    {
        private Entity db = new Entity();

        // GET: CoustomerDetails
        public ActionResult Index()
        {
            var coustomerDetails = db.CoustomerDetails.Include(c => c.Address);
            return View(coustomerDetails.ToList());
        }

        // GET: CoustomerDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoustomerDetails coustomerDetails = db.CoustomerDetails.Find(id);
            if (coustomerDetails == null)
            {
                return HttpNotFound();
            }
            return View(coustomerDetails);
        }

        // GET: CoustomerDetails/Create
        public ActionResult Create()
        {
            ViewBag.AddressId = new SelectList(db.Address, "AddressId", "House");
            return View();
        }

        // POST: CoustomerDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CoustomerId,AddressId,Phone,email")] CoustomerDetails coustomerDetails)
        {
            if (ModelState.IsValid)
            {
                db.CoustomerDetails.Add(coustomerDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressId = new SelectList(db.Address, "AddressId", "House", coustomerDetails.AddressId);
            return View(coustomerDetails);
        }

        // GET: CoustomerDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoustomerDetails coustomerDetails = db.CoustomerDetails.Find(id);
            if (coustomerDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressId = new SelectList(db.Address, "AddressId", "House", coustomerDetails.AddressId);
            return PartialView("Edit",coustomerDetails);
        }

        // POST: CoustomerDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CoustomerId,AddressId,Phone,email")] CoustomerDetails coustomerDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coustomerDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(db.Address, "AddressId", "House", coustomerDetails.AddressId);
            return View(coustomerDetails);
        }

        // GET: CoustomerDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoustomerDetails coustomerDetails = db.CoustomerDetails.Find(id);
            if (coustomerDetails == null)
            {
                return HttpNotFound();
            }
            return View(coustomerDetails);
        }

        // POST: CoustomerDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoustomerDetails coustomerDetails = db.CoustomerDetails.Find(id);
            db.CoustomerDetails.Remove(coustomerDetails);
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
