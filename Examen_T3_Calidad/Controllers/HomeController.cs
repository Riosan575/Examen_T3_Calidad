using Examen_T3_Calidad.DB;
using Examen_T3_Calidad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T3_Calidad.Controllers
{
    public class HomeController : Controller
    {
        private NotaContext context;
        public HomeController(NotaContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
