using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Examen_T3_Calidad.Service
{
    public interface IAuthService
    {
        void Login(List<Claim> claims);

        void Logout();
    }
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _context;
        public AuthService(IHttpContextAccessor context)
        {
            _context = context;
        }
        public void Login(List<Claim> claims)
        {
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            _context.HttpContext.SignInAsync(claimsPrincipal);
        }

        public void Logout()
        {
            _context.HttpContext.SignOutAsync();
        }
    }
}
