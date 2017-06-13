using System.Web.Mvc;
using FreeSource.Common.Application.Authorization;
using FreeSource.Common.Application.Person;


namespace FreeSource.Portal.Controllers
{
    [Authorize]
    public class CustomerController : AbstractController
    {
        private readonly IPersonApplication _personApplication;
        public CustomerController(IAuthorizationApplication authorizationApplication, IPersonApplication personApplication) : base(authorizationApplication)
        {
            _personApplication = personApplication;
        }
        // GET: Customer
        public ActionResult Index()
        {
            var model = new ViewModels.Customer.IndexViewModel
            {
                User = LoggedUser,
                Customers = _personApplication.GetCustomersByUser(LoggedUser)
            };
            
            return View(model);
        }        
    }
}