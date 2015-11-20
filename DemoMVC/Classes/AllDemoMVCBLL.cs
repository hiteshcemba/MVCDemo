using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.Classes
{
    public class AllDemoMVCBLL
    {
        public AllDemoMVCBLL(string strconnectionstring)
        {
            Categories = new Categories();
            Logins = new Logins();
            SubCategories = new SubCategories();
        }
        public void Dispose()
        {

        }


        public Categories Categories { get; set; }
        public Logins Logins { get; set; }
        public SubCategories SubCategories { get; set; }

    }
}