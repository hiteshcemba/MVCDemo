using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoMVC.Models;

namespace DemoMVC.App_Start
{
    public class AllDemoMVCBLL
    {
        private DemoMVCDB _DB = null;

        public DemoMVCDB DB { get { return _DB; } }

        public AllDemoMVCBLL(string strconnectionstring)
        {
            _DB = new DemoMVCDB(strconnectionstring);
        }

        public List<Category> GetAllCategories()
        {
            return DB.GetAllCategories(); 
        }
        public bool AddCategory(Category objCat)
        {
            return DB.AddCategory(objCat); 
        }
        public Category  FindCategoryWithID(int id)
        {
            return DB.FindCategoryWithID(id); 
        }

        public void Dispose()
        {
             //this.Dispose();
        }

    }
}