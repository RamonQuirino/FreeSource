using System.Web.Mvc;
using FreeSource.Common.Application.Authorization;
using FreeSource.Common.Application.Person;
using FreeSource.Common.Models.Person;
using FreeSource.Portal.ViewModels.Person;

namespace FreeSource.Portal.Controllers
{
    [Authorize]
    public class PersonController : AbstractController
    {
        private readonly IPersonApplication _personApplication;
        public PersonController(IAuthorizationApplication authorizationApplication, IPersonApplication personApplication) : base(authorizationApplication)
        {
            _personApplication = personApplication;
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
        public ActionResult Edit(int id)
        {
            var model = new PersonViewModel
            {
                Person = _personApplication.GetPerson(id)
            };
            return PartialView("New", model);
        }

        [HttpPost]
        public ActionResult Search(PersonSearchViewModel filterModel)
        {
            filterModel.Persons = _personApplication.Filter(filterModel.FilterText, true, false, false, false);
            return View(filterModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult Save(Person person)
        {
            _personApplication.Save(person);
            return Json(new Person
            {
                Id = person.Id
            });
        }
    }
}