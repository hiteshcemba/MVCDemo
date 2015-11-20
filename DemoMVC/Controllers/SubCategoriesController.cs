using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoMVC.Models;
using DemoMVC.Classes;

namespace WebApplication3.Controllers
{
    public class SubCategoriesController : Controller
    {


        AllDemoMVCBLL objBLL = new AllDemoMVCBLL(AllConstants.CONNECTIONSTRING);
        // GET: SubCategories
        public ActionResult Index()
        {
            var subCategories = objBLL.SubCategories.All();
            return View(subCategories);
        }

        //// GET: SubCategories/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SubCategory subCategory = db.SubCategories.Find(id);
        //    if (subCategory == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(subCategory);
        //}

        // GET: SubCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(objBLL.Categories.All(), "CategoryId", "CategoryName");
            return View();
        }   

        //// POST: SubCategories/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubCategoryId,SubCategoryName,CategoryId")] SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                objBLL.SubCategories.Add(subCategory);
                 return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(objBLL.Categories.All() , "CategoryId", "CategoryName", subCategory.CategoryId);
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
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", subCategory.CategoryId);
            return View(subCategory);
        }

        // POST: SubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubCategoryId,SubCategoryName,CategoryId")] SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", subCategory.CategoryId);
            return View(subCategory);
        }

        //// GET: SubCategories/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SubCategory subCategory = db.SubCategories.Find(id);
        //    if (subCategory == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(subCategory);
        //}

        //// POST: SubCategories/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    SubCategory subCategory = db.SubCategories.Find(id);
        //    db.SubCategories.Remove(subCategory);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
