using System.Web.Mvc;
using FreeSource.Common.Application.Authorization;
using FreeSource.Common.Models.Authorization;
using Microsoft.AspNet.Identity;

namespace FreeSource.Portal.Controllers
{
    public abstract class AbstractController: Controller
    {        
        protected User LoggedUser => User.Identity.IsAuthenticated ? _authorizationApplication.FindById(User.Identity.GetUserId()) : null;

        private readonly IAuthorizationApplication _authorizationApplication;
        protected AbstractController(IAuthorizationApplication authorizationApplication)
        {
            _authorizationApplication = authorizationApplication;
            
        }
    }
}

