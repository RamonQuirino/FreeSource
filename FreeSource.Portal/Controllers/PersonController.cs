using System.Web.Mvc;
using FreeSource.Common.Application.Authorization;
using FreeSource.Portal.ViewModels.Person;

namespace FreeSource.Portal.Controllers
{
    [Authorize]
    public class PersonController : AbstractController
    {     
        public PersonController(IAuthorizationApplication authorizationApplication) : base(authorizationApplication)
        {
        }

        // GET: Person
        public ActionResult Index()
        {
            var model = new PersonViewModel();
            return View(model);
        }

        public ActionResult New()
        {
            var model = new PersonViewModel();
            return View(model);
        }
    }
}