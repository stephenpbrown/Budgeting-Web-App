using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudgetingWebApp.Models;
using BudgetingWebApp.ViewModels;

namespace BudgetingWebApp.Controllers
{
    public class SubCategoryController : Controller
    {
        private BudgetingWebAppContext db = new BudgetingWebAppContext();

        // GET: SubCategory
        public ActionResult Index()
        {
            return View(db.SubCategoryModels.ToList());
        }

        // GET: SubCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoryModel subCategoryModel = db.SubCategoryModels.Find(id);
            if (subCategoryModel == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryModel);
        }

        // GET: SubCategory/Create
        public ActionResult Create(int? id, int? budgetID, string mainCategoryName)
        {
            ViewBag.mainCategoryID = id;
            ViewBag.budgetID = budgetID;
            ViewBag.mainCategoryName = mainCategoryName;
            return View();
        }

        // POST: SubCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubCategoryID,MainCategoryID,Name,Allotment,Actual")] SubCategoryModel subCategoryModel, int id, int budgetID)
        {
            if (ModelState.IsValid)
            {
                subCategoryModel.MainCategoryID = id;
                subCategoryModel.BudgetID = budgetID;
                db.SubCategoryModels.Add(subCategoryModel);
                db.SaveChanges();

                return RedirectToAction("Edit", "Budget", new { id = budgetID });
            }

            return View(subCategoryModel);
        }

        public MainViewModel BuildMainViewModel(int budgetID)
        {
            var budgetModel = db.BudgetModels.Find(budgetID);
            var mainCategoryModel = (from a in db.MainCategoryModels where a.BudgetID == budgetID select a).ToList();
            var subCategoryModel = (from a in db.SubCategoryModels where a.BudgetID == budgetID select a).ToList();

            var mainViewModel = new MainViewModel
            {
                Budget = budgetModel,
                MainCategory = mainCategoryModel,
                SubCategory = subCategoryModel
            };

            return mainViewModel;
        }

        // GET: SubCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoryModel subCategoryModel = db.SubCategoryModels.Find(id);
            if (subCategoryModel == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryModel);
        }

        // POST: SubCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubCategoryID,MainCategoryID,Name,Allotment,Actual")] SubCategoryModel subCategoryModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCategoryModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subCategoryModel);
        }

        // GET: SubCategory/Delete/5
        public ActionResult Delete(int? id, int? budgetID)
        {
            if (id == null || budgetID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoryModel subCategoryModel = db.SubCategoryModels.Find(id);
            if (subCategoryModel == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryModel);
        }

        // POST: SubCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int budgetID)
        {
            SubCategoryModel subCategoryModel = db.SubCategoryModels.Find(id);
            db.SubCategoryModels.Remove(subCategoryModel);
            db.SaveChanges();

            return RedirectToAction("Edit", "Budget", new { id = budgetID });
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
