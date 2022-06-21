using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CommissionProject;

namespace CommissionProject.Controllers
{
    public class AbiturientsController : Controller
    {
        private CommissionDbEntities1 db = new CommissionDbEntities1();

        // GET: Abiturients
        public ActionResult Index()
        {
            return View(db.Abiturients.ToList());
        }

        // GET: Abiturients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abiturient abiturient = db.Abiturients.Find(id);
            if (abiturient == null)
            {
                return HttpNotFound();
            }
            return View(abiturient);
        }

        // GET: Abiturients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Abiturients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,SecondName,GPA,ZNO,FPT,OlympiadMark,MedicalCertificate")] Abiturient abiturient)
        {
            if (ModelState.IsValid)
            {
                db.Abiturients.Add(abiturient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(abiturient);
        }

        // GET: Abiturients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abiturient abiturient = db.Abiturients.Find(id);
            if (abiturient == null)
            {
                return HttpNotFound();
            }
            return View(abiturient);
        }

        // POST: Abiturients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,SecondName,GPA,ZNO,FPT,OlympiadMark,MedicalCertificate")] Abiturient abiturient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abiturient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(abiturient);
        }

        // GET: Abiturients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abiturient abiturient = db.Abiturients.Find(id);
            if (abiturient == null)
            {
                return HttpNotFound();
            }
            return View(abiturient);
        }

        // POST: Abiturients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Abiturient abiturient = db.Abiturients.Find(id);
            db.Abiturients.Remove(abiturient);
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
