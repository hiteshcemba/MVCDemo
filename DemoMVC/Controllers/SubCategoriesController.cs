using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoMVC.Models;
using DemoMVC.Classes;

namespace DemoMVC.Controllers
{
    public class SubCategoriesController : Controller
    {

        AllDemoMVCBLL objBLL = new AllDemoMVCBLL();
        // GET: SubCategories
        public ActionResult Index()
        {
            var subCategories = objBLL.SubCategories.All();
            return View(subCategories.ToList());
        }

        // GET: SubCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = objBLL.SubCategories.Find(id.Value);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // GET: SubCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(objBLL.Categories.All(), "CategoryID", "CategoryName");
            return View();
        }

        // POST: SubCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubCategoryID,SubCategoryName,CategoryID")] SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                objBLL.SubCategories.Add(subCategory);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(objBLL.Categories.All(), "CategoryID", "CategoryName", subCategory.CategoryID);
            return View(subCategory);
        }

        // GET: SubCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = objBLL.SubCategories.Find(id.Value);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList( objBLL.Categories.All(), "CategoryID", "CategoryName", subCategory.CategoryID);
            return View(subCategory);
        }

        // POST: SubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubCategoryID,SubCategoryName,CategoryID")] SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                objBLL.SubCategories.Edit(subCategory);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(objBLL.Categories.All(), "CategoryID", "CategoryName", subCategory.CategoryID);
            return View(subCategory);
        }

        // GET: SubCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = objBLL.SubCategories.Find(id.Value);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // POST: SubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCategory subCategory = objBLL.SubCategories.Find(id);
            objBLL.SubCategories.Delete(subCategory);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
