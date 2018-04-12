using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAL;
using WebApplication2.Models;
using WebApplication2.ViewModels.User;

namespace WebApplication2.Controllers
{
    public class UsersController : Controller
    {
        private DB db = new DB();

        // GET: Users
        public ActionResult Index()
        {
            List<UserVM> listaVM = new List<UserVM>();
            
            if (db.userDB.ToList() != null)
            {
                foreach (User u in db.userDB.ToList())
                {
                    UserVM nowy = new UserVM(u);
                    listaVM.Add(nowy);
                }
            }
            IndexVM lista = new IndexVM();
            lista.userList = listaVM;
            lista.username = User.Identity.Name;
            return View(lista);
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailsVM user = new DetailsVM();
            user.user = new UserVM(db.userDB.Find(id));

            if (user == null)
            {
                return HttpNotFound();
            }
            user.username = User.Identity.Name;
            return View(user);
        }

        // GET: Users/Create
        [Authorize]
        public ActionResult Create()
        {
            CreateVM vm = new CreateVM();
            vm.username = User.Identity.Name;
            return View(vm);
        }

        // POST: Users/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateVM vm)
        {
            if (ModelState.IsValid)
            {
                User user = new Models.User();
                user.age = vm.age;
                user.firstName = vm.lastName;
                user.lastName = vm.lastName;
                db.userDB.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            

            return View(vm);
        }

        // GET: Users/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EditVM user = new EditVM ();
            user.user = new UserVM(db.userDB.Find(id));
            if (user == null)
            {
                return HttpNotFound();
            }
            user.username = User.Identity.Name;
            return View(user);
        }

        // POST: Users/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditVM vm)
        {
            if (ModelState.IsValid)
            {
                User user = new Models.User();
                user.age = vm.age;
                user.firstName = vm.lastName;
                user.lastName = vm.lastName;
                db.Entry(user ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(vm);
        }

        // GET: Users/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeleteVM user = new DeleteVM();
            user.user = new UserVM(db.userDB.Find(id));

            if (user == null)
            {
                return HttpNotFound();
            }
            user.username = User.Identity.Name;
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.userDB.Find(id);
            db.userDB.Remove(user);
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
