using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPI.Controllers;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Tests.Controllers
{
    [TestClass]
    public class EstadosCitasControllerTest
    {
        [TestMethod]
        public void ObtenerEstadoCitaPorId()
        {
            // Arrange
            var controller = new EstadosCitasController();

            // Act
            var response = controller.GetEstadosCitas(1);
            var contentResult = response as OkNegotiatedContentResult<EstadosCitasVM>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);
        }

        [TestMethod]
        public void AgregarEstadoCita()
        {
            // Arrange
            var controller = new EstadosCitasController();

            EstadosCitas estadoCita = new EstadosCitas()
            {
                Nombre = "Estado Cita Prueba"
            };

            // Act
            IHttpActionResult actionResult = controller.PostEstadosCitas(estadoCita);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<EstadosCitas>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }
    }
}
