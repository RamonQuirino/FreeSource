#region Using

using System.Web.Mvc;
using FreeSource.Common.Application.Authorization;

#endregion

namespace FreeSource.Portal.Controllers
{
    [Authorize]
    public class HomeController : AbstractController
    {
        public HomeController(IAuthorizationApplication authorizationApplication) : base(authorizationApplication)
        {
        }

        // GET: home/index
        public ActionResult Index()
        {
            var xx = LoggedUser;
            return View();
        }

        public ActionResult Social()
        {
            return View();
        }

        // GET: home/inbox
        public ActionResult Inbox()
        {
            return View();
        }

        // GET: home/widgets
        public ActionResult Widgets()
        {
            return View();
        }

        // GET: home/chat
        public ActionResult Chat()
        {
            return View();
        }        
    }
}