using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AusTest.Domain.Model.Identity;
using AusTest.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AusTest.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AusTestUser> _usrMgr;
        private readonly SignInManager<AusTestUser> _signInMgr;
        private readonly RoleManager<AusTestRole> _roleMgr;

        public AccountController(UserManager<AusTestUser> usrMgr, SignInManager<AusTestUser> signInMgr, RoleManager<AusTestRole> roleMgr)
        {
            _usrMgr = usrMgr;
            _signInMgr = signInMgr;
            _roleMgr = roleMgr;

        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = ReturnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInMgr.PasswordSignInAsync(model.Username,
                                    model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToLocal(model.ReturnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                   // return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    return View("Lockout");
                }
                else
                {
                    model.NotFound = true;
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInMgr.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "home");
        }

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("", "home");
        }
        #endregion
    }
}