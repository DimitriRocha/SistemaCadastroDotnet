using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AplicacaoDesafio.DAL;
using AplicacaoDesafio.Models;

namespace AplicacaoDesafio.Controllers
{
    public class LoginController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /login
        public ActionResult Index()
        {
            return View();
        }

        // POST: /login
        [HttpPost]
        public ActionResult Index(User loginUser)
        {
            var userObject = (from usr in db.Users where usr.Login == loginUser.Login && usr.Status == true select usr).FirstOrDefault();

            if (userObject != null)
            {
                string DecryptedPass = Decrypt(userObject.Senha);

                if (DecryptedPass == loginUser.Senha)
                {
                    FormsAuthentication.SetAuthCookie((string)userObject.Login, true);
                    return RedirectToAction("Index", "Users");
                }
            }

            ViewBag.errorMessage = "Usuário ou senha incorretos";
            
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        private string Decrypt(string pass)
        {
            return pass;
        }
    }
}