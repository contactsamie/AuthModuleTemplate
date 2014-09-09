using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SystemIdentityModule;
using authModule.ActionFilterAttributes;
using authModule.EmailTemplates;
using IdentitySample.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace authModule.Controllers.AccountRegistrations
{
    [Authorize]
    public partial class AccountController : Controller
    {
        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return PartialView();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [ValidateAjax]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    var emailBody = EmailTemplateFactory.GetCommonTemplate("Confirm your account", "Please confirm your account by clicking  <a href=\"" + callbackUrl + "\">Here</a><br /><br />");
                    await UserManager.SendEmailAsync(user.Id, "Confirm your account", emailBody);
                    ViewBag.Link = callbackUrl;
                    return Json(true);
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var errors = new List<string> { "Invalid registration attempt" };
            return Json(errors);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        [ValidateAjax]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var errors = new List<string> { "ConfirmEmail error" };
                return Json(errors);
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);

            var emailBody = EmailTemplateFactory.GetCommonTemplate("Thank You", "Thank you for confirming your email. Your account is now active, and you may login");

            await UserManager.SendEmailAsync(userId, "Thank You", emailBody);

            if (result.Succeeded)
            {
                return Json(true);
            }
            // If we got this far, something failed
            Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var error = new List<string> { "ConfirmEmail error" };
            return Json(error);
        }
    }

}