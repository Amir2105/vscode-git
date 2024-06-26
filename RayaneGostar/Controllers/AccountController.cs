using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RayaneGostar.Application.Interfaces;
using RayaneGostar.Domain.Models.ViewModels.Account;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RayaneGostar.Controllers
{
    public class AccountController : SiteBaseController
    {
        #region Constructor
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region register
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel register)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUser(register);
                switch (result)
                {
                    case RegisterUserResult.MobileExists:

                        TempData[ErrorMessage] = "شماره تلفن وارد شده قبلا داخل سیستم ثبت شده است";
                        break;
                    case RegisterUserResult.Success:
                        TempData[SuccessMessage] = "ثبت نام شما با موفقیت انجام شد";
                        break;
                }
            }
            return View(register);
        }
        #endregion

        #region login
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel login)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUser(login);
                switch (result)
                {
                    case LoginUserResult.NotActive:
                        break;
                    case LoginUserResult.NotFound:
                        break;
                    case LoginUserResult.IsBlocked:
                        break;
                    case LoginUserResult.Success:
                        var user = await _userService.GetUserByPhoneNumber(login.PhoneNumber);
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.PhoneNumber),
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                        };
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principle = new ClaimsPrincipal(identity);
                        var properties = new AuthenticationProperties
                        {
                            IsPersistent = login.RememberMe
                        };
                        await HttpContext.SignInAsync(principle, properties);
                        return Redirect("/");
                }
            }
            return View(login);
        }
        #endregion
    }
}