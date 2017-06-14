using System.Web;
using FreeSource.Common.Models.Authorization;

namespace FreeSource.Portal.App_Helpers
{
    public static class SessionUserHelper
    {
        public static User CurrentUser()
        {
            return HttpContext.Current.Session["LogedUser"] as User;
        }
    }
}