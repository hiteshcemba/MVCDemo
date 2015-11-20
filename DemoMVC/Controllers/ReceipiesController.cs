using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoMVC.Models;
using DemoMVC.Classes;

namespace DemoMVC.Controllers
{
    public class ReceipiesController : Controller
    {
      //  private SubCategoryDBContext db = new SubCategoryDBContext();

        AllDemoMVCBLL objBLL = new AllDemoMVCBLL();
        // GET: Receipies
        public ActionResult Index()
        {
            var receipies = objBLL.Receipies.All();
            return View(receipies.ToList());
        }

        // GET: Receipies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipy receipy = objBLL.Receipies.Find(id.Value);
            if (receipy == null)
            {
                return HttpNotFound();
            }
            return View(receipy);
        }

        // GET: Receipies/Create
        public ActionResult Create()
        {
            ViewBag.SubCategoryID = new SelectList(objBLL.SubCategories.All(), "SubCategoryID", "SubCategoryName");
            return View();
        }

        // POST: Receipies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReceipyID,ReceipyName,Ingredients,Making,Time,Image,SubCategoryID")] Receipy receipy, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload!= null && upload.ContentLength > 0)
                {                 
                        try
                        {
                      
                            string fileName = Guid.NewGuid().ToString();
                            string serverPath = Server.MapPath("~");
                            string imagesPath = serverPath + "Content\\Images\\";
                            upload.SaveAs(imagesPath + fileName);
                            receipy.Image = fileName;
                        }
                        catch (Exception ex)
                        {

                        }
                   
                }


                objBLL.Receipies.Add(receipy);
                return RedirectToAction("Index");
            }

            ViewBag.SubCategoryID = new SelectList(objBLL.SubCategories.All(), "SubCategoryID", "SubCategoryName", receipy.SubCategoryID);
            return View(receipy);
        }

        // GET: Receipies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipy receipy = objBLL.Receipies.Find(id.Value);
            if (receipy == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubCategoryID = new SelectList(objBLL.SubCategories.All(), "SubCategoryID", "SubCategoryName", receipy.SubCategoryID);
            return View(receipy);
        }

        // POST: Receipies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReceipyID,ReceipyName,Ingredients,Making,Time,Image,SubCategoryID")] Receipy receipy)
        {
            if (ModelState.IsValid)
            {
                objBLL.Receipies.Edit(receipy);
                return RedirectToAction("Index");
            }
            ViewBag.SubCategoryID = new SelectList(objBLL.SubCategories.All(), "SubCategoryID", "SubCategoryName", receipy.SubCategoryID);
            return View(receipy);
        }

        // GET: Receipies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipy receipy = objBLL.Receipies.Find(id.Value);
            if (receipy == null)
            {
                return HttpNotFound();
            }
            return View(receipy);
        }

        // POST: Receipies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receipy receipy = objBLL.Receipies.Find(id);
            objBLL.Receipies.Delete(receipy);
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
