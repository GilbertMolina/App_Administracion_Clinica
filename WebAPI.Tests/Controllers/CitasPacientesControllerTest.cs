using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPI.Controllers;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Tests.Controllers
{
    [TestClass]
    public class CitasPacientesControllerTest
    {
        [TestMethod]
        public void ObtenerCitaPacientePorId()
        {
            // Arrange
            var controller = new CitasPacientesController();

            // Act
            var response = controller.GetCitasPacientes(1);
            var contentResult = response as OkNegotiatedContentResult<CitasPacientesVM>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);
        }

        [TestMethod]
        public void AgregarCitaPaciente()
        {
            // Arrange
            var controller = new CitasPacientesController();

            CitasPacientes citaPaciente = new CitasPacientes()
            {
                IdPaciente = 304540214,
                IdEstadoCita = 1,
                IdTipoCita = 2,
                FechaCita = Convert.ToDateTime("2018-06-22 15:00:00")
            };

            // Act
            IHttpActionResult actionResult = controller.PostCitasPacientes(citaPaciente);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<CitasPacientes>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }
    }
}
