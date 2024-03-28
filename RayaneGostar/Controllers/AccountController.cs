using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RayaneGostar.Application.Interfaces;
using RayaneGostar.Domain.Models.ViewModels;

namespace RayaneGostar.Controllers
{
    public class AccountController : SiteBaseController
    {
        #region Constarctor
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
        public async Task<IActionResult> Register(RegisterUserViewModel regiter)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUser(regiter);
                switch (result)
                {
                    case RegisterUserResult.MobileExists:
                        break;
                    case RegisterUserResult.Success:
                        break;
                }

            }
            return View(regiter);
        }
        #endregion

        #region login

        [HttpGet("login")]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost("login"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel login)
        {
            if (ModelState.IsValid)
            {
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
                        var Claims = new List<Claim>
                        {

                            new Claim(ClaimTypes.Name,user.PhoneNumber),
                            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
                        };
                        var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principle = new ClaimsPrincipal(identity);
                        var properties = new AuthenticationProperties
                        {
                            IsPersistent = login.RememberMe
                        };
                        await HttpContext.SignInAsync(principle, properties);
                        return Redirect("/");

                }
                return View(login);

            }
        }


        #endregion
    }
}