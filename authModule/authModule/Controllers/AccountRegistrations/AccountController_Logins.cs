using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SystemIdentityModule;
using authModule.ActionFilterAttributes;
using IdentitySample.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace authModule.Controllers.AccountRegistrations
{
    [Authorize]
    public partial class AccountController : Controller
    {
        // GET: /Account/Login
        //[AllowAnonymous]
        //public ActionResult Login(string returnUrl)
        //{
        //    ViewBag.ReturnUrl = returnUrl;
            
        //    return PartialView();
        //}

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [ValidateAjax]
        //public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            // here the ValidateAjax will kick in
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var errors = new List<string> { "BadRequest" };
                return Json(errors);
            }

            // This doen't count login failures towards lockout only two factor authentication
            // To enable password failures to trigger lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: true);
            switch (result)
            {
                case SignInStatus.Success:
                    return Json(true);

                case SignInStatus.LockedOut:
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    var errors = new List<string> { "Lockout" };
                    return Json(errors);

                case SignInStatus.RequiresVerification:
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errors = new List<string> { "RequiresVerification" };
                    return Json(errors);
                //return RedirectToAction("SendCode", new { ReturnUrl = returnUrl });

                case SignInStatus.Failure:
                default:
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    errors = new List<string> { "Invalid login attempt" };
                    return Json(errors);
            }
        }
    }

}