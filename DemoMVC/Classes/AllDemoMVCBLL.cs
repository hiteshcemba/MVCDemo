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
            Categories = new Categories(strconnectionstring);
            Logins = new Logins(strconnectionstring);
            SubCategories = new SubCategories(strconnectionstring);
        }
        public void Dispose()
        {

        }


        public Categories Categories { get; set; }
        public Logins Logins { get; set; }
        public SubCategories SubCategories { get; set; }

    }
}