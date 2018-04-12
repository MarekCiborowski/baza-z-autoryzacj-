using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication2.BusinessLayer;
using WebApplication2.DAL;
using WebApplication2.ViewModels.Authentication;

namespace WebApplication2.Controllers
{
   
    public class AuthenticationController : Controller
    {
        private DB db = new DB();
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginVM vm)
        {
            if (ModelState.IsValid)
            {
                AppBL appBL = new AppBL();
                if (appBL.isValidUser(vm))
                {
                    FormsAuthentication.SetAuthCookie(vm.username, false);
                    return Redirect("/Users/Index");
                }
                ModelState.AddModelError("CredentialError", "Niepoprawna nazwa użytkownika lub hasło");
            }
            return View(vm);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Users/Index");
        }

        public ActionResult NewUser()
        {
            ViewBag.availability = true;
            return View();
        }

        [HttpPost]
        public ActionResult NewUser(LoginVM newUser)
        {
            if (ModelState.IsValid)
            {
                AppBL appBL = new AppBL();
                if (!(ViewBag.availability = appBL.isUserNameAvailable(newUser.username)))
                    return View(newUser);
                newUser.password=newUser.hashPassword();
                db.adminsDB.Add(newUser);
                db.SaveChanges();
                return RedirectToAction("Login");

            }
            return View(newUser);
        }
    }
}