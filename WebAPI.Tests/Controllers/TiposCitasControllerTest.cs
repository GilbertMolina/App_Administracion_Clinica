using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPI.Controllers;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Tests.Controllers
{
    [TestClass]
    public class TiposCitasControllerTest
    {
        [TestMethod]
        public void ObtenerTipoCitaPorId()
        {
            // Arrange
            var controller = new TiposCitasController();

            // Act
            var response = controller.GetTiposCitas(1);
            var contentResult = response as OkNegotiatedContentResult<TiposCitasVM>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);
        }

        [TestMethod]
        public void AgregarTipoCita()
        {
            // Arrange
            var controller = new TiposCitasController();

            TiposCitas tipoCita = new TiposCitas()
            {
                Nombre = "Tipo Cita Prueba"
            };

            // Act
            IHttpActionResult actionResult = controller.PostTiposCitas(tipoCita);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<TiposCitas>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }
    }
}
