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
    public class ExpensesController : Controller
    {
        private BudgetingWebAppContext db = new BudgetingWebAppContext();

        // GET: Expenses
        public ActionResult Index()
        {
            return View(db.ExpenseModels.ToList());
        }

        // GET: Expenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseModel expenseModel = db.ExpenseModels.Find(id);
            if (expenseModel == null)
            {
                return HttpNotFound();
            }
            return View(expenseModel);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpenseModelID,MainCategoryID,SubCategoryID,Name,Cost,Description")] ExpenseModel expenseModel)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseModels.Add(expenseModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expenseModel);
        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseModel expenseModel = db.ExpenseModels.Find(id);
            if (expenseModel == null)
            {
                return HttpNotFound();
            }
            return View(expenseModel);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpenseModelID,MainCategoryID,SubCategoryID,Name,Cost,Description")] ExpenseModel expenseModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenseModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseModel);
        }

        // GET: Expenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseModel expenseModel = db.ExpenseModels.Find(id);
            if (expenseModel == null)
            {
                return HttpNotFound();
            }
            return View(expenseModel);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseModel expenseModel = db.ExpenseModels.Find(id);
            db.ExpenseModels.Remove(expenseModel);
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
