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
                //iniciado na request
                if (_loggedUser != null) return _loggedUser;

                if (Session["LogedUser"] == null)
                {
                    if (_loggedUser != null) return _loggedUser;
                    if (!User.Identity.IsAuthenticated) return _loggedUser;

                    _loggedUser = _authorizationApplication.FindByToken(User.Identity.Name);
                    if (_loggedUser == null)
                    {
                        RedirectToAction("Login", "Account");
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

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (_loggedUser != null) return;
            if (Session["LogedUser"] == null)
            {
                _loggedUser = _authorizationApplication.FindByToken(User.Identity.Name);
                if (_loggedUser == null)
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.HttpContext.Response.StatusCode = 403;
                        filterContext.Result =
                            new JsonResult {Data = "LogOut", JsonRequestBehavior = JsonRequestBehavior.AllowGet};
                    }
                    else
                        filterContext.Result = RedirectToAction("Login", "Account");
                }               
            }
            else
            {
                _loggedUser = Session["LogedUser"] as User;
            }
        } 
    }
}

