using CoffeeTea.Data;
using CoffeeTea.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CoffeeTea.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly DataContext _db;

        public AdminController(DataContext db)
        {
            _db = db;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Admin");
            
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (email == "123" && password == "123")
            {
                // Authentication succeeded, redirect to the home page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Authentication failed, return an error message
                ModelState.AddModelError("", "Invalid email or password");
                return View();
            }
        }
    }
}
