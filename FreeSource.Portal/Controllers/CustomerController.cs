using System.Web.Mvc;
using FreeSource.Common.Application.Authorization;


namespace FreeSource.Portal.Controllers
{
    [Authorize]
    public class CustomerController : AbstractController
    {
        public CustomerController(IAuthorizationApplication authorizationApplication) : base(authorizationApplication)
        {

        }
        // GET: Customer
        public ActionResult Index()
        {
            var model = new ViewModels.Customer.IndexViewModel
            {
                User = LoggedUser
            };
            return View(model);
        }        
    }
}