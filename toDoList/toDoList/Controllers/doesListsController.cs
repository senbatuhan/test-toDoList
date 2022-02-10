using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using toDoList.Models;

namespace toDoList.Controllers
{
    public class doesListsController : Controller
    {
        private toDoListEntitiesConnectionDB db = new toDoListEntitiesConnectionDB();

        // GET: doesLists
        public ActionResult Index()
        {
            return View(db.doesLists.ToList());
        }

        // GET: doesLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doesList doesList = db.doesLists.Find(id);
            if (doesList == null)
            {
                return HttpNotFound();
            }
            return View(doesList);
        }

        // GET: doesLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: doesLists/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,task,dList")] doesList doesList)
        {
            if (ModelState.IsValid)
            {
                db.doesLists.Add(doesList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doesList);
        }

        // GET: doesLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doesList doesList = db.doesLists.Find(id);
            if (doesList == null)
            {
                return HttpNotFound();
            }
            return View(doesList);
        }

        // POST: doesLists/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,task,dList")] doesList doesList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doesList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doesList);
        }

        // GET: doesLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doesList doesList = db.doesLists.Find(id);
            if (doesList == null)
            {
                return HttpNotFound();
            }
            return View(doesList);
        }

        // POST: doesLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            doesList doesList = db.doesLists.Find(id);
            db.doesLists.Remove(doesList);
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
