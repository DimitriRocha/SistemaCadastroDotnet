using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AplicacaoDesafio.DAL;
using AplicacaoDesafio.Models;

namespace AplicacaoDesafio.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Users
        public ActionResult Index(UserSearchModel searchModel)
        {
            var model = FilterUsers(searchModel);
            return View(model);
        }

        // Returns the filter view for the data on the users table
        public ActionResult FilterUsersPartialView(UserSearchModel searchModel)
        {
            return View();
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Sobrenome,CPF,Email,Login,Senha,Status")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Sobrenome,CPF,Email,Login,Senha,Status")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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

        private IQueryable<User> FilterUsers(UserSearchModel searchModel)
        {
            var result = db.Users.AsQueryable();
            if (searchModel != null)
            {
                if (!string.IsNullOrEmpty(searchModel.Nome))
                    result = result.Where(x => x.Nome.Contains(searchModel.Nome));
                if (!string.IsNullOrEmpty(searchModel.Sobrenome))
                    result = result.Where(x => x.Sobrenome.Contains(searchModel.Sobrenome));
                if (!string.IsNullOrEmpty(searchModel.Email))
                    result = result.Where(x => x.Email.Contains(searchModel.Email));
                if (!string.IsNullOrEmpty(searchModel.Login))
                    result = result.Where(x => x.Login.Contains(searchModel.Login));
                if (searchModel.Status.HasValue)
                    result = result.Where(x => x.Status == searchModel.Status);
            }

            return result;
        }
    }
}
