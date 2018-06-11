using System.Web.Mvc;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Administración Clínica Médica";
            ViewBag.Message = "Aplicación para la Administración de una Clínica Médica.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "Sobre nosotros";
            ViewBag.Message1 = "Aplicación para la Administración de una Clínica Médica.";
            ViewBag.Message2 = "Desarrollada por Gilbert Molina.";
            ViewBag.Message3 = "Contacto: gmolinac91@gmail.com.";

            return View();
        }
    }
}