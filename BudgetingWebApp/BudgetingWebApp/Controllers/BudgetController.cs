using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudgetingWebApp.Models;
using Microsoft.AspNet.Identity;

namespace BudgetingWebApp.Controllers
{
    public class BudgetController : Controller
    {
        private BudgetingWebAppContext db = new BudgetingWebAppContext();

        // GET: BudgetModels
        public ActionResult Index()
        {
            return View(db.BudgetModels.ToList());
        }

        // GET: BudgetModels/Details/5
        public ActionResult Details(int? id)
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

        // GET: BudgetModels/Create
        public ActionResult Create()
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
                budgetModel.BudgetMonth = DateTime.Now.Date;

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
            BudgetModel budgetModel = db.BudgetModels.Find(id);
            if (budgetModel == null)
            {
                return HttpNotFound();
            }
            return View(budgetModel);
        }

        // POST: BudgetModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BudgetID,UserID,DateCreated,BudgetMonth")] BudgetModel budgetModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budgetModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(budgetModel);
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
            BudgetModel budgetModel = db.BudgetModels.Find(id);
            db.BudgetModels.Remove(budgetModel);
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
