using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudgetingWebApp.Models;

namespace BudgetingWebApp.Controllers
{
    public class MainCategoryController : Controller
    {
        private BudgetingWebAppContext db = new BudgetingWebAppContext();

        // GET: MainCategory
        public ActionResult Index()
        {
            return View(db.MainCategoryModels.ToList());
        }

        // GET: MainCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCategoryModel mainCategoryModel = db.MainCategoryModels.Find(id);
            if (mainCategoryModel == null)
            {
                return HttpNotFound();
            }
            return View(mainCategoryModel);
        }

        // GET: MainCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MainCategoryID")] MainCategoryModel mainCategoryModel)
        {
            if (ModelState.IsValid)
            {
                db.MainCategoryModels.Add(mainCategoryModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mainCategoryModel);
        }

        // GET: MainCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCategoryModel mainCategoryModel = db.MainCategoryModels.Find(id);
            if (mainCategoryModel == null)
            {
                return HttpNotFound();
            }
            return View(mainCategoryModel);
        }

        // POST: MainCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MainCategoryID")] MainCategoryModel mainCategoryModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainCategoryModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mainCategoryModel);
        }

        // GET: MainCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCategoryModel mainCategoryModel = db.MainCategoryModels.Find(id);
            if (mainCategoryModel == null)
            {
                return HttpNotFound();
            }
            return View(mainCategoryModel);
        }

        // POST: MainCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MainCategoryModel mainCategoryModel = db.MainCategoryModels.Find(id);
            db.MainCategoryModels.Remove(mainCategoryModel);
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
