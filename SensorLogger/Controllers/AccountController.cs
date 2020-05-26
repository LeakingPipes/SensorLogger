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
using System.Security.Cryptography;

namespace SensorLogger.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHashData hashData;

        private readonly SensorLoggerContext context;

        public AccountController(SensorLoggerContext context, IHashData hashData)
        {
            this.context = context;
            this.hashData = hashData;
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
            List<User> users = await context.Users.AsNoTracking().ToListAsync();
            User database_user = users.SingleOrDefault(u => u.Name == model.Username);

            if(database_user == null)
            {
                string _password = hashData.ComputeHashSha512(model.Password, model.Username);

                User user = new User { Name = model.Username, Password = _password, Role = Role.User };

                context.Add(user);
                await context.SaveChangesAsync();
                return View("AccountCreated");
            }
            else
            {
                model.ErrorMessage = "This username has already been taken!";

                return View(model);
            }
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
            model.Password = hashData.ComputeHashSha512(model.Password, model.Username);

            List<User> users = await context.Users.AsNoTracking().ToListAsync();
            User user = users.SingleOrDefault(u => u.Name == model.Username && u.Password == model.Password);

            if (user == null)
            {
                model.ErrorMessage = "Wrong name or password!";

                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.ToString())
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
