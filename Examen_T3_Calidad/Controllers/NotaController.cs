using Examen_T3_Calidad.DB;
using Examen_T3_Calidad.Models;
using Examen_T3_Calidad.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T3_Calidad.Controllers
{
    [Authorize]
    public class NotaController : Controller
    {
        private readonly INotaRepository notaRepository;
        private readonly NotaContext context;
        public NotaController(NotaContext context, INotaRepository notaRepository)
        {
            this.context = context;
            this.notaRepository = notaRepository;
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

            if (etiqueta.Count() == 0)
                ModelState.AddModelError("etiqueta", "Seleccione uno por lo menos");

            nota.Fecha = DateTime.Now;
            if (nota != null && etiqueta != null)
            {
                notaRepository.Create(nota, etiqueta);
                return RedirectToAction("Index");
            }
            Response.StatusCode = 400;
            ViewBag.Etiquetas = context.Etiquetas.ToList();
            return View(nota);
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
            if (nota != null)
            {
                notaRepository.Edit(nota);
                return RedirectToAction("Index");
            }
            Response.StatusCode = 400;
            ViewBag.Etiquetas = context.Etiquetas.ToList();
            return View(nota);

        }


        //eliminar
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            if (id != 0)
            {
                notaRepository.Eliminar(id);
                return RedirectToAction("Index","Nota");
            }            
            return View("Index");
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
