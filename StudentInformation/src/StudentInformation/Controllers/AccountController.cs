using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity;
using StudentInformation.Models;
using Microsoft.AspNet.Authorization;

namespace StudentInformation.Controllers
{
    public class AccountController : BaseController
    {
        [FromServices]
        public SignInManager<User> signInManager { get; set; }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult>Login(string username,string password)
        {
            try
            {
                var result = await signInManager.PasswordSignInAsync(username, password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                    //return View();
                }
            }
            catch (Exception ex)
            {

               return Content("登陆失败,请检查用户名或密码");
            }
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Authorize]
        public IActionResult Modify()
        {
            return View(CurrentUser);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Modify(string currentpwd,string newpwd,string confirmpwd)
        {
            if (confirmpwd != newpwd)
                return Content("两次输入密码不一致，请检查后重新输入");
            var result = await UserManager.ChangePasswordAsync(await UserManager.FindByIdAsync(CurrentUser.Id), currentpwd, newpwd);

            if (!result.Succeeded)
                return Content(result.Errors.First().Description);

            await signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }
    }
}
