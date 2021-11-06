using Examen_T3_Calidad.Controllers;
using Examen_T3_Calidad.Models;
using Examen_T3_Calidad.Repository;
using Examen_T3_Calidad.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenT3Test.Controller
{
    class AuthControllerTest
    {
        [Test]
        public void TestLoginCase01()
        {

            var mock = new Mock<IAuthRepository>();
            mock.Setup(o => o.Login("angel", "12345678")).Returns((Usuario)null);
            var controller = new AuthController(mock.Object, null);

            var result = controller.Login("angel", "1234567") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void TestLoginCase02()
        {

            var mock = new Mock<IAuthRepository>();
            mock.Setup(o => o.Login("angel", "angel")).Returns(new Usuario());

            var authMock = new Mock<IAuthService>();
            var controller = new AuthController(mock.Object, authMock.Object);
            var result = controller.Login("angel", "angel") as RedirectToActionResult;

            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        [Test]
        public void TestLoginCase03()
        {

            var mock = new Mock<IAuthRepository>();
            mock.Setup(o => o.Login(null, "angel")).Returns((Usuario)null);
            var controller = new AuthController(mock.Object, null);

            var result = controller.Login(null, "angel") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void TestLoginCase04()
        {
            var mock = new Mock<IAuthRepository>();
            mock.Setup(o => o.Login("angel", null)).Returns((Usuario)null);
            var controller = new AuthController(mock.Object, null);

            var result = controller.Login("angel", null) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void TestLoginCase05()
        {
            var mock = new Mock<IAuthRepository>();
            mock.Setup(o => o.Login("", "")).Returns((Usuario)null);
            var controller = new AuthController(mock.Object, null);

            var result = controller.Login("", "") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void TestRegisterCase01()
        {
            var mock = new Mock<IAuthRepository>();
            mock.Setup(o => o.Register(null)).Returns((Usuario)null);
            var controller = new AuthController(mock.Object, null);

            var result = controller.Register(null) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void TestRegisterCaso02()
        {
            var mock = new Mock<IAuthRepository>();
            mock.Setup(o => o.Register(new Usuario())).Returns((Usuario)null);
            var controller = new AuthController(mock.Object, null);

            var result = controller.Register(new Usuario()) as RedirectToActionResult;

            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        [Test]
        public void TestRegisterCaso03()
        {
            var mock = new Mock<IAuthRepository>();
            mock.Setup(o => o.Register(new Usuario()));
            var controller = new AuthController(mock.Object, null);

            var result = controller.Register() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void TestRegisterCaso04()
        {
            var mock = new Mock<IAuthRepository>();
            mock.Setup(o => o.Register(null));
            var controller = new AuthController(mock.Object, null);

            var result = controller.Register(null) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void TestRegisterCaso05()
        {
            var mock = new Mock<IAuthRepository>();
            mock.Setup(o => o.Register(new Usuario())).Returns((Usuario)null);
            var controller = new AuthController(mock.Object, null);

            var result = controller.Register() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
