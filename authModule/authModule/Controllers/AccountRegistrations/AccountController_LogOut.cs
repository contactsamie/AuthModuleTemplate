using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemIdentityModule;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace authModule.Controllers.AccountRegistrations
{
    [Authorize]
    public partial class AccountController : Controller
    {
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }

}