using System.Web.Mvc;
using FreeSource.Common.Application.Authorization;
using FreeSource.Common.Models.Authorization;

namespace FreeSource.Portal.Controllers
{
    public abstract class AbstractController : Controller
    {

        private User _loggedUser;
        protected User LoggedUser
        {
            get
            {
                if (Session["LogedUser"] == null)
                {
                    if (_loggedUser != null) return _loggedUser;
                    if (!User.Identity.IsAuthenticated) return _loggedUser;

                    _loggedUser = _authorizationApplication.FindByToken(User.Identity.Name);
                    if (_loggedUser == null)
                    {
                        RedirectToAction("Login", "Account", null);
                    }

                    Session["LogedUser"] = _loggedUser;
                }
                else
                {
                    _loggedUser = Session["LogedUser"] as User;
                }
                return _loggedUser;

            }
        }

        private readonly IAuthorizationApplication _authorizationApplication;
        protected AbstractController(IAuthorizationApplication authorizationApplication)
        {
            _authorizationApplication = authorizationApplication;

        }
    }
}

