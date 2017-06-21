#region Using

using System.Web.Mvc;
using FreeSource.Common.Application.Authorization;

#endregion

namespace FreeSource.Portal.Controllers
{
    [Authorize]
    public class TablesController : AbstractController
    {
        public TablesController(IAuthorizationApplication authorizationApplication) : base(authorizationApplication)
        {
        }
        // GET: tables/normal
        public ActionResult Normal()
        {
            return View();
        }

        // GET: tables/data-tables
        public ActionResult DataTables()
        {
            return View();
        }

        // GET: tables/jq-grid
        public ActionResult JQGrid()
        {
            return View();
        }
    }
}