using Examen_T3_Calidad.Controllers;
using Examen_T3_Calidad.Models;
using Examen_T3_Calidad.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenT3Test.Controller
{
    class NotaControllerTest
    {
        [Test]
        public void TestEditNotaCase01()
        {
            var mock = new Mock<INotaRepository>();
            mock.Setup(o => o.Edit(new Nota()));
            var controller = new NotaController(null, mock.Object);

            var result = controller.Edit(new Nota()) as RedirectToActionResult;

            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        [Test]
        public void TestCrearNotaCase02()
        {
            var mock = new Mock<INotaRepository>();
            mock.Setup(o => o.Create(new Nota(), new List<int> { 1 }));
            var controller = new NotaController(null, mock.Object);

            var result = controller.Create(new Nota(), new List<int> { 1 }) as RedirectToActionResult;

            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        [Test]
        public void TestEliminarNotaCase03()
        {
            var mock = new Mock<INotaRepository>();
            mock.Setup(o => o.Eliminar(1));
            var controller = new NotaController(null, mock.Object);

            var result = controller.Eliminar(1) as RedirectToActionResult;

            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        [Test]
        public void TestEliminarNotaCase04()
        {
            var mock = new Mock<INotaRepository>();
            mock.Setup(o => o.Eliminar(0));
            var controller = new NotaController(null, mock.Object);

            var result = controller.Eliminar(0) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void TestEliminarNotaCase05()
        {
            var mock = new Mock<INotaRepository>();
            mock.Setup(o => o.Eliminar(1));
            var controller = new NotaController(null, mock.Object);

            var result = controller.Eliminar(0) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void TestEditNotaCase06()
        {
            var mock = new Mock<INotaRepository>();
            mock.Setup(o => o.Edit(null));
            var controller = new NotaController(null, mock.Object);

            var result = controller.Edit(new Nota()) as RedirectToActionResult;

            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
    }
}
