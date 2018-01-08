using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace DotNetAppSqlDb.Controllers
{
    public class CompanyController : Controller
    {
        private readonly MyDatabaseContext db = new MyDatabaseContext();

        // GET: Company
        public ActionResult Index()
        {
            return View(db.Companies.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Company company = db.Companies.Find(id);

            if (company == null)
            {
                return HttpNotFound();
            }

            return View(company);
        }

        public ActionResult Create()
        {
            return View(new Company());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description, Address1, Address2, Postcode")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(company);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Company company = db.Companies.Find(id);

            if (company == null)
            {
                return HttpNotFound();
            }

            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Description, Address1, Address2, Postcode")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(company);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Company company = db.Companies.Find(id);

            if (company == null)
            {
                return HttpNotFound();
            }

            return View(company);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
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