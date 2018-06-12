using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPI.Controllers;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Tests.Controllers
{
    [TestClass]
    public class PacientesControllerTest
    {
        [TestMethod]
        public void ObtenerPacientePorId()
        {
            // Arrange
            var controller = new PacientesController();

            // Act
            var response = controller.GetPacientes(304540214);
            var contentResult = response as OkNegotiatedContentResult<PacientesVM>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(304540214, contentResult.Content.Id);
        }

        [TestMethod]
        public void AgregarPaciente()
        {
            // Arrange
            var controller = new PacientesController();

            Pacientes paciente = new Pacientes()
            {
                Id = 501870174,
                Nombre = "Sonia",
                Apellido1 = "Castrillo",
                Apellido2 = "Baltodano"
            };

            // Act
            IHttpActionResult actionResult = controller.PostPacientes(paciente);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Pacientes>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }
    }
}
