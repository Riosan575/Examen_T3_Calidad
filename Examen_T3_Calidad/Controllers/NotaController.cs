using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen_T3_Calidad.DB;
using Examen_T3_Calidad.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EXAMENFINALN00038802.Controllers
{
    [Authorize]
    public class NotaController : Controller
    {
        private readonly NotaContext context;
        public NotaController(NotaContext context)
        {
            this.context = context;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Etiquetas = context.Etiquetas.ToList();
            ViewBag.Etiquetitas = context.NotaEtiquetas.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult _Index(string search)
        {
            var not = context.Notas.ToList();
            ViewBag.Etiquetas = context.Etiquetas.ToList();
            ViewBag.Etiquetitas = context.NotaEtiquetas.ToList();

            if (!String.IsNullOrEmpty(search))
            {
                not = not.Where(o => o.Titulo.Contains(search) || o.Contenido.Contains(search)).ToList();
                return View(not);
            }
            return View(not);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Etiquetas = context.Etiquetas.ToList();
            return View(new Nota());
        }


        [HttpPost]
        public IActionResult Create(Nota nota, List<int> etiqueta)
        {
            List<NotaEtiqueta> etic = new List<NotaEtiqueta>();

            if (etiqueta.Count() == 0)
                ModelState.AddModelError("etiqueta", "Seleccione uno por lo menos");

            nota.Fecha = DateTime.Now;
            if (ModelState.IsValid)
            {
                context.Notas.Add(nota);
                context.SaveChanges();
                foreach (var item in etiqueta)
                {
                    var etique = new NotaEtiqueta();
                    etique.EtiquetaId = item;
                    etique.NotaId = nota.Id;
                    etic.Add(etique);
                }
                context.NotaEtiquetas.AddRange(etic);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                Response.StatusCode = 400;
                ViewBag.Etiquetas = context.Etiquetas.ToList();
                return View(nota);
            }
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Etiquetas = context.Notas.ToList();
            var nota = context.Notas.Where(o => o.Id == id).FirstOrDefault();
            return View(nota);

        }


        [HttpPost]
        public IActionResult Edit(Nota nota)
        {
            nota.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {
                context.Notas.Update(nota);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                Response.StatusCode = 400;
                ViewBag.Etiquetas = context.Etiquetas.ToList();
                return View(nota);
            }

        }


        //eliminar
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var nota = context.Notas.Where(o => o.Id == id).FirstOrDefault();
            var etiqueta = context.NotaEtiquetas.Where(o => o.NotaId == id).ToList();
            context.Notas.Remove(nota);
            context.NotaEtiquetas.RemoveRange(etiqueta);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Det(int id)
        {
            var etiqueta = context.Etiquetas.ToList();
            ViewBag.Etiquetas = context.NotaEtiquetas.Include(o => o.Etiqueta).ToList();
            var nota = context.Notas.Where(o => o.Id == id).FirstOrDefault();
            return View(nota);
        }

    }
}
