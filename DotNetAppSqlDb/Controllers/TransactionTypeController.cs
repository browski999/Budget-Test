using DotNetAppSqlDb.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DotNetAppSqlDb.Controllers
{
    public class TransactionTypeController : Controller
    {
        private readonly MyDatabaseContext db = new MyDatabaseContext();

        // GET: Company
        public ActionResult Index()
        {
            return View(db.TransactionTypes.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TransactionType transactionType = db.TransactionTypes.Find(id);

            if (transactionType == null)
            {
                return HttpNotFound();
            }

            return View(transactionType);
        }

        public ActionResult Create()
        {
            return View(new TransactionType());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description")] TransactionType transactionType)
        {
            if (ModelState.IsValid)
            {
                db.TransactionTypes.Add(transactionType);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(transactionType);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TransactionType transactionType = db.TransactionTypes.Find(id);

            if (transactionType == null)
            {
                return HttpNotFound();
            }

            return View(transactionType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Description")] TransactionType transactionType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactionType).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(transactionType);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TransactionType transactionType = db.TransactionTypes.Find(id);

            if (transactionType == null)
            {
                return HttpNotFound();
            }

            return View(transactionType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransactionType transactionType = db.TransactionTypes.Find(id);
            db.TransactionTypes.Remove(transactionType);
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