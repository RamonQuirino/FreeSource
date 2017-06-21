using System.Web;
using FreeSource.Common.Models.Authorization;

namespace FreeSource.Portal.App_Helpers
{
    public static class SessionUserHelper
    {
        public static User CurrentUser()
        {
            var usuario = HttpContext.Current.Session["LogedUser"] as User;
            if (usuario == null)
            {
                
            }

            return usuario;

        }

        public static string LoggedUserName()
        {
            var user = CurrentUser();
            return user == null ? "" : user.Person?.Name;
        }
    }
}