

using Examen_T3_Calidad.DB;
using Examen_T3_Calidad.Models;
using Examen_T3_Calidad.Repository;
using Examen_T3_Calidad.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Examen_T3_Calidad.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository authRepository;
        private readonly IAuthService authService;
        public AuthController(IAuthRepository loginRepository, IAuthService loginService)
        {
            this.authRepository = loginRepository;
            this.authService = loginService;
        }
        [HttpGet]
        public IActionResult Login()
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
            var usuario = authRepository.Login(username, password);
            // Autenticar
            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };

                authService.Login(claims);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Validation = "Usuario y/o contraseña incorrecta";
            return View();
        }
        [HttpPost]
        public ActionResult Register(Usuario account) // POST
        {
            if (account != null)
            {
                authRepository.Register(account);

                return RedirectToAction("Login");
            }
            return View("Register", account);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            authService.Logout();
            return RedirectToAction("Login");
        }

    }
}
