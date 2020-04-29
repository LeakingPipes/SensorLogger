using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SensorLogger.Data;
using SensorLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SensorLogger.Controllers
{
    public class AccountController : Controller
    {
        private readonly SensorLoggerContext _context;

        public AccountController(SensorLoggerContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult CreateNewAccount()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateNewAccount(CreateNewAccountModel model)
        {
            User user = new User { Name = model.Username, Password = model.Password, Role = "User" };

            _context.Add(user);
            await _context.SaveChangesAsync();

            //userRepository.AddNewUserAsync(model.Username, model.Password);
            return Redirect("/Account/AccountCreated");
        }

        [AllowAnonymous]
        public IActionResult AccountCreated()
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "/")
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            List<User> users = await _context.Users.AsNoTracking().ToListAsync();
            User user = users.SingleOrDefault(u => u.Name == model.Username && u.Password == model.Password);

            if (user == null)
                return Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties { IsPersistent = model.RememberLogin });

            return LocalRedirect(model.ReturnUrl);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}
