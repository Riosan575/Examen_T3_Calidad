using Examen_T3_Calidad.DB;
using Examen_T3_Calidad.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Examen_T3_Calidad.Controllers
{
    public class AuthController : Controller
    {
        private NotaContext context;
        private IConfiguration configuration;
        public AuthController(NotaContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = context.Usuarios.Where(o => o.Username == username && o.Password == password).FirstOrDefault();

            if (user == null)
            {
                TempData["AuthMessage"] = "Usuario o Contraseña incorrecto";
                return RedirectToAction("Index");
            }

            // Autenticar
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Username),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            HttpContext.SignInAsync(claimsPrincipal);


            return RedirectToAction("Index","Nota");
        }
        [HttpPost]
        public ActionResult Register(Usuario account) // POST
        {
            var accounts = context.Usuarios.ToList();
            foreach (var item in accounts)
            {
                if (item.Username == account.Username)
                    ModelState.AddModelError("Usuario", "El Usuario ya existe, ingrese otro Usuario");
            }

            if (ModelState.IsValid)
            {
                context.Usuarios.Add(account);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Register", account);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

    }
}
