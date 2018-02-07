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
using System.Collections;

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
            //budgetID = (int)id;
            return View(mainCategoryModel);
        }

        // GET: MainCategory/Create
        public ActionResult Create(int? budgetID)
        {
            if(budgetID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.budgetID = budgetID;

            return View();
        }

        // POST: MainCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Allotment")] MainCategoryModel mainCategoryModel, int budgetID)
        {
            if (ModelState.IsValid)
            {
                mainCategoryModel.BudgetID = budgetID;
                db.MainCategoryModels.Add(mainCategoryModel);
                db.SaveChanges();

                return RedirectToAction("Edit", "Budget", new { id = budgetID });
            }

            return RedirectToAction("Edit", "Budget", new { id = budgetID });
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
        public ActionResult Delete(int? id, int? budgetID)
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
        public ActionResult DeleteConfirmed(int id, int budgetID)
        {
            // Removes the main category
            MainCategoryModel mainCategoryModel = db.MainCategoryModels.Find(id);
            db.MainCategoryModels.Remove(mainCategoryModel);

            // Removes the sub categories associated with the main categories
            IEnumerable<SubCategoryModel> subCategoryModel = (from a in db.SubCategoryModels
                                                              where a.MainCategoryID == id
                                                              select a).ToList();
            foreach (var model in subCategoryModel)
            {
                db.SubCategoryModels.Remove(model);
            }

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
