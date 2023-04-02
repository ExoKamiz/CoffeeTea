using CoffeeTea.Data;
using CoffeeTea.Models;
using CoffeeTea.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CoffeeTea.Controllers
{
    public class AdminController : Controller
    {
        private readonly DataContext _db;

        public AdminController(DataContext db)
        {
            _db = db;
        }


  
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string email, string password)
        {
            if (email == "a@gmail.com" && password == "123")
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, email)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View();
            }
        }

        [Authorize]
        public ActionResult Index()
        {
            AdminVM adminVM = new AdminVM()
            {
                Products = _db.Products.Include(u => u.Categories),
                Categories = _db.Categories
            };
            return View("Index", adminVM);
        }
    }
}
