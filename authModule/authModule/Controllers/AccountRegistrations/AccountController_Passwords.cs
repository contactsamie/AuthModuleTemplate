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
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [ValidateAjax]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    // return PartialView("ForgotPasswordConfirmation");
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    var error = new List<string> { "ForgotPassword error" };
                    return Json(error);
                }

                var code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);

                var emailBody = EmailTemplateFactory.GetCommonTemplate("Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">Here</a>");

                await UserManager.SendEmailAsync(user.Id, "Reset Password", emailBody);
                ViewBag.Link = callbackUrl;
                return Json(true);
            }

            // If we got this far, something failed, redisplay form
            Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var errors = new List<string> { "ForgotPassword error" };
            return Json(errors);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return PartialView();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? PartialView("Error") : PartialView();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return PartialView();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return PartialView();
        }
    }

}