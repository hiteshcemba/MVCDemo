using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoMVC.Models;

namespace DemoMVC.Classes
{
    public class AllDemoMVCBLL
    {
        //private DemoMVCDB _DB = null;

        //public DemoMVCDB DB { get { return _DB; } }

        //public List<Category> GetAllCategories()
        //{
        //    return DB.GetAllCategories(); 
        //}
        //public bool AddCategory(Category objCat)
        //{
        //    return DB.AddCategory(objCat); 
        //}
        //public Category  FindCategoryWithID(int id)
        //{
        //    return DB.FindCategoryWithID(id); 
        //}
        //public bool EditCategory(Category objCat)
        //{
        //    return DB.EditCategory(objCat); 
        //}
        //public bool DeleteCategory(Category objCat)
        //{
        //    return DB.DeleteCategory(objCat); 
        //}


        public void Dispose()
        {
             //this.Dispose();
        }


        public AllDemoMVCBLL()
        {
            Categories = new Categories();
            Logins = new Logins();
            SubCategories = new SubCategories();
            Receipies = new Receipies();
        }
        public Categories Categories { get; set; }
        public Logins Logins { get; set; }
        public SubCategories SubCategories { get; set; }
        public Receipies Receipies { get; set; } 




    }
}