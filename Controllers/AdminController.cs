//using CoffeeTea.Data;
//using CoffeeTea.Models;
//using CoffeeTea.Models.ViewModels;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Claims;

//namespace CoffeeTea.Controllers
//{
//    public class AdminController : Controller
//    {
//        private readonly DataContext _db;

//        public AdminController(DataContext db)
//        {
//            _db = db;
//        }


  
//        [HttpGet]
//        public ActionResult Login()
//        {
//            return View();
//        }

       
//        [HttpPost]
//        public async Task<ActionResult> Login(string email, string password)
//        {
//            if (email == "a@gmail.com" && password == "123")
//            {
//                //var claims = new List<Claim>
//                //{
//                //    new Claim(ClaimTypes.Email, email),
//                //    new Claim(ClaimTypes.Name, "Admin")
//                //};

//                //// Create a new ClaimsIdentity using the claims
//                //var claimsIdentity = new ClaimsIdentity(
//                //    claims, CookieAuthenticationDefaults.AuthenticationScheme);

//                //// Create a new AuthenticationProperties object
//                //var authProperties = new AuthenticationProperties
//                //{
//                //    AllowRefresh = true,
//                //    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
//                //    IsPersistent = true
//                //};

//                //// Sign in the user with the claims identity and authentication properties
//                //await HttpContext.SignInAsync(
//                //    CookieAuthenticationDefaults.AuthenticationScheme,
//                //    new ClaimsPrincipal(claimsIdentity),
//                //    authProperties);
//                return RedirectToAction("Index", "Admin");
//            }
//            else
//            {
//                ModelState.AddModelError("", "Invalid email or password");
//                return View();
//            }
//        }

//        //[Authorize]
//        public ActionResult Index()
//        {
//            AdminVM adminVM = new AdminVM()
//            {
//                Products = _db.Products.Include(u => u.Categories),
//                Categories = _db.Categories
//            };
//            return View("Index", adminVM);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Logout()
//        {
//            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//            return RedirectToAction("Login", "Admin");
//        }

//        public IActionResult Details(int id)
//        {
//            DetailsVM detailsVM = new DetailsVM
//            {
//                Product = _db.Products.Include(u => u.Categories)
//                .Where(u => u.Id == id).FirstOrDefault()

//            };

//            return View(detailsVM);
//        }

//        public IActionResult Upsert(int? id)      
//        {
//            ProductVM productVM = new ProductVM()   //загружаем ViewModel типа ProductVM
//            {
//                Product = new Product(),            //с добавлением пустого обьекта Product
//                CategorySelectList = _db.Category.Select(i => new SelectListItem      //для передачи списка всех Category из контролера в представление(SelectListItem для раскрывающегося списка)
//                {                                                                                               //и выбираем имя и id категории и конвертируем в элементы специального типа для выбора
//                    Text = i.Name,
//                    Value = i.Id.ToString()
//                })
//            };


//            if (id == null)                        //и проверяем что, если id которое мы получили не имеет значения, то поступил запрос на создание новой сущности
//            {
//                return View(productVM);             //переход на представление со ссылкой на модель
//            }
//            else                                  //если id имеет значение 
//            {
//                productVM.Product = _db.Product.Find(id);   //получаем productVM из базы данных используя Find     
//                if (productVM.Product == null)
//                {
//                    return NotFound();
//                }
//                return View(productVM);
//            }                                      //теперь наше представление строго типизированно с помощью productVM
//        }
//    }
//}
