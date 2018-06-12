using System.Web.Mvc;

namespace App.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}