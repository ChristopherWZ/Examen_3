using Examen_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Examen_3.Controllers
{
    public class AccountController : Controller
    {
        private MigracionEntities db = new MigracionEntities();

        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Usuarios
                             .FirstOrDefault(u => u.Username == model.Username && u.PasswordHash == model.PasswordHash);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos.");
            }

            return View(model);
        }
        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the user already exists
                var existingUser = db.Usuarios
                                     .FirstOrDefault(u => u.Username == model.Username);

                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Username already exists.");
                    return View(model);
                }

                // Create a new user
                var newUser = new Usuario
                {
                    Username = model.Username,
                    PasswordHash = model.Password // In a real-world application, hash the password
                };

                db.Usuarios.Add(newUser);
                db.SaveChanges();

                FormsAuthentication.SetAuthCookie(newUser.Username, false);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        // GET: /Account/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}