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
using Microsoft.AspNet.Identity;
using System.Globalization;

namespace BudgetingWebApp.Controllers
{
    public class BudgetController : Controller
    {
        private BudgetingWebAppContext db = new BudgetingWebAppContext();

        // GET: BudgetModels
        public ActionResult Index(int? id)
        {
            string userID = User.Identity.GetUserId();
            var budgetModel = from a in db.BudgetModels
                              where a.UserID == userID
                              select a;

            return View(budgetModel.ToList());
        }

        // GET: BudgetModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string userID = User.Identity.GetUserId();
            var budgetModel = from a in db.BudgetModels
                              where a.UserID == userID
                              select a;

            if (budgetModel == null)
            {
                return HttpNotFound();
            }

            return View(budgetModel);
        }

        // GET: BudgetModels/Create
        public ActionResult Create(int? id)
        {
            return View();
        }

        // POST: BudgetModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BudgetID,UserID,DateCreated,BudgetMonth")] BudgetModel budgetModel)
        {
            if (ModelState.IsValid)
            {
                budgetModel.DateCreated = DateTime.Now.Date;
                DateTime inputedBudgetDate = DateTime.Parse(budgetModel.BudgetMonth);
                budgetModel.BudgetMonth = inputedBudgetDate.ToString("MMMM", new CultureInfo("en-GB")) + " " + inputedBudgetDate.Year;
                budgetModel.UserID = User.Identity.GetUserId();
                db.BudgetModels.Add(budgetModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(budgetModel);
        }

        // GET: BudgetModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = BuildMainViewModel((int)id);

            return View(viewModel);
        }

        // Build the main view model for the main page
        public MainViewModel BuildMainViewModel(int budgetID)
        {
            var budgetModel = db.BudgetModels.Find(budgetID);
            var mainCategoryModel = (from a in db.MainCategoryModels where a.BudgetID == budgetID select a).ToList();
            var subCategoryModel = (from a in db.SubCategoryModels where a.BudgetID == budgetID select a).ToList();
            decimal totalAllotment = 0;
            decimal totalActual = 0;

            foreach(var model in mainCategoryModel)
            {
                totalAllotment += model.Allotment;
                totalActual += model.Actual;
            }

            //foreach(var model in subCategoryModel)
            //{
            //    totalAllotment += model.Allotment;
            //    totalActual += model.Actual;
            //}

            var mainViewModel = new MainViewModel
            {
                Budget = budgetModel,
                MainCategory = mainCategoryModel,
                SubCategory = subCategoryModel,
                TotalAllotment = totalAllotment
            };

            return mainViewModel;
        }

        // POST: BudgetModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BudgetID,UserID,DateCreated,BudgetMonth")] MainViewModel mainViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainViewModel.Budget).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mainViewModel);
        }

        // GET: BudgetModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetModel budgetModel = db.BudgetModels.Find(id);
            if (budgetModel == null)
            {
                return HttpNotFound();
            }
            return View(budgetModel);
        }

        // POST: BudgetModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Remove the budget
            BudgetModel budgetModel = db.BudgetModels.Find(id);
            db.BudgetModels.Remove(budgetModel);

            // Removes the categories associated with the budget
            IEnumerable<MainCategoryModel> mainCategoryModel = (from a in db.MainCategoryModels
                                                  where a.BudgetID == id
                                                  select a).ToList();
            foreach(var model in mainCategoryModel)
            {
                db.MainCategoryModels.Remove(model);
            }

            // Removes the sub categories associated with the budget
            IEnumerable<SubCategoryModel> subCategoryModel = (from a in db.SubCategoryModels
                                                                where a.BudgetID == id
                                                                select a).ToList();
            foreach (var model in subCategoryModel)
            {
                db.SubCategoryModels.Remove(model);
            }

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
