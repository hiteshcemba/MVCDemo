using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoMVC.Models;
using DemoMVC.Classes; 

namespace DemoMVC.Controllers
{
    public class AccountController : Controller
    {
        
         AllDemoMVCBLL objBLL = new AllDemoMVCBLL();


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

       [ValidateAntiForgeryToken]
       [HttpPost]
        public ActionResult Login([Bind(Include = "UserId,Password")] Login login)
        {
           
           if (ModelState.IsValid)
            {
                Login tmplogin = objBLL.Logins.Find(login);
                if (tmplogin != null)
                {
                    if (login.UserId == tmplogin.UserId && login.Password == tmplogin.Password)
                    {
                        ViewBag.Login = tmplogin;
                        return View("Home");

                    }
                   
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login,Please try again !");
                }
               
            }

           return View(login);
           
        }

     
      
       public ActionResult Home()
       {
           if (ViewBag.Login == null)
           {
               return View("Login"); 
           }
           else
           {
               return View();
           }
              
       }

    }
}