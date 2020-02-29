using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using inventoryV1;

namespace inventoryV1.Controllers
{
    public class categorysController : Controller
    {
        private invisDBEntities db = new invisDBEntities();

        // GET: categorys
        public ActionResult Index()
        {
            return View(db.categorys.ToList());
        }

        // GET: categorys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categorys categorys = db.categorys.Find(id);
            if (categorys == null)
            {
                return HttpNotFound();
            }
            return View(categorys);
        }

        // GET: categorys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: categorys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cat_id,cat_name,cat_status")] categorys categorys)
        {
            if (ModelState.IsValid)
            {
                db.categorys.Add(categorys);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categorys);
        }

        // GET: categorys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categorys categorys = db.categorys.Find(id);
            if (categorys == null)
            {
                return HttpNotFound();
            }
            return View(categorys);
        }

        // POST: categorys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cat_id,cat_name,cat_status")] categorys categorys)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorys).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorys);
        }

        // GET: categorys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categorys categorys = db.categorys.Find(id);
            if (categorys == null)
            {
                return HttpNotFound();
            }
            return View(categorys);
        }

        // POST: categorys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categorys categorys = db.categorys.Find(id);
            db.categorys.Remove(categorys);
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
