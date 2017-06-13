using System;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using FreeSource.Common.Application.Authorization;
using FreeSource.Common.Models.Authorization;
using FreeSource.Common.Models.Person;
using Microsoft.Ajax.Utilities;

namespace FreeSource.Portal.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {        
        private readonly IAuthorizationApplication _authorizationApplication;        

        public AccountController(IAuthorizationApplication authorizationApplication)
        {
            _authorizationApplication = authorizationApplication;            
        }


        // GET: /account/forgotpassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            return View();
        }

        // GET: /account/login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            // Store the originating URL so we can attach it to a form field
            var viewModel = new AccountLoginModel { ReturnUrl = returnUrl };

            return View(viewModel);
        }

        // POST: /account/login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(AccountLoginModel viewModel)
        {
            // Ensure we have a valid viewModel to work with
            if (!ModelState.IsValid)
                return View(viewModel);
            
            // Verify if a user exists with the provided identity information
            var user = await _authorizationApplication.FindByEmailAsync(viewModel.Email);

            // If a user was found
            if (user != null)
            {
                // Then create an identity for it and sign it in
                await SignInAsync(user, viewModel.RememberMe);

                // If the user came from a specific page, redirect back to it
                return RedirectToLocal(viewModel.ReturnUrl);
            }

            // No existing user was found that matched the given criteria
            ModelState.AddModelError("", "Usuário ou senha invalida.");

            // If we got this far, something failed, redisplay form
            return View(viewModel);
        }



        // GET: /account/error
        [AllowAnonymous]
        public ActionResult Error()
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            return View();
        }

        // GET: /account/register
        [AllowAnonymous]
        public ActionResult Register()
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            return View(new AccountRegistrationModel());
        }

        // POST: /account/register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(AccountRegistrationModel viewModel)
        {
            // Ensure we have a valid viewModel to work with
            if (!ModelState.IsValid)
                return View(viewModel);

            // Prepare the identity with the provided information
            var user = new User
            {
                PasswordHash = viewModel.Password.GetHashCode().ToString(),
                UserName = viewModel.Username ?? viewModel.Email,
                Email = viewModel.Email,                
                Person = new Person
                {
                    Birthdate = DateTime.Now,
                    Email = viewModel.Email,
                    Name = viewModel.Username
                }                
            };

            // Try to create a user with the given identity
            try
            {
                var result =  _authorizationApplication.CreateAsync(user);

                //// If the user could not be created
                //if (result.Id == null)
                //{
                //    // Add all errors to the page so they can be used to display what went wrong
                //    AddErrors(result);

                //    return View(viewModel);
                //}

                // If the user was able to be created we can sign it in immediately
                // Note: Consider using the email verification proces
                await SignInAsync(user, false);

                return RedirectToLocal();
            }
            catch (Exception ex)
            {
                // Add all errors to the page so they can be used to display what went wrong
                AddErrors(ex);

                return View(viewModel);
            }
        }

        // POST: /account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            // First we clean the authentication ticket like always
            FormsAuthentication.SignOut();

            // Second we clear the principal to ensure the user does not retain any authentication
            HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

            // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place
            // this clears the Request.IsAuthenticated flag since this triggers a new request
            return RedirectToLocal();
        }

        private ActionResult RedirectToLocal(string returnUrl = "")
        {
            // If the return url starts with a slash "/" we assume it belongs to our site
            // so we will redirect to this "action"
            if (!returnUrl.IsNullOrWhiteSpace() && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            // If we cannot verify if the url is local to our host we redirect to a default location
            return RedirectToAction("index", "home");
        }

        private void AddErrors(Exception exc)
        {
            //foreach (var error in exc.EntityValidationErrors.SelectMany(validationErrors => validationErrors.ValidationErrors.Select(validationError => validationError.ErrorMessage)))
            //{
            ModelState.AddModelError("", exc);
            //}
        }

        private void AddErrors(User result)
        {
            // Add all errors that were returned to the page error collection
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action
            if (Request.IsAuthenticated)
                Logout();
        }

        private async Task SignInAsync(User user, bool isPersistent)
        {
            // Clear any lingering authencation data
            FormsAuthentication.SignOut();
            
            // Create a claims based identity for the current user
            var identity = _authorizationApplication.CreateIdentityAsync(user); // DefaultAuthenticationTypes.ApplicationCookie

            // Write the authentication cookie
            FormsAuthentication.SetAuthCookie(user.Id, isPersistent);
        }

        // GET: /account/lock
        [AllowAnonymous]
        public ActionResult Lock()
        {
            return View();
        }
    }
}