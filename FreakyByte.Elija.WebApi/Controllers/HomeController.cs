using System.Web.Mvc;

namespace FreakyByte.Elija.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}