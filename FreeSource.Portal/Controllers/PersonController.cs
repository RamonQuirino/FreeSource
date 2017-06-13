using System.Web.Mvc;
using FreeSource.Portal.ViewModels.Person;

namespace FreeSource.Portal.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            var model = new PersonViewModel();
            return View(model);
        }
    }
}