using CoffeeTea.Data;
using CoffeeTea.Models;
using CoffeeTea.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CoffeeTea.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _db;

        public ProductController(DataContext db)
        {
            _db = db;
        }

        // GET: ProductController
        public IActionResult Index()
        {
            ProductVM productVM = new ProductVM()
            {
                Products = _db.Products.Include(u => u.Categories),
                Categories = _db.Categories
            };
            return View(productVM);
        }

        public IActionResult Details(int id)
        {
            DetailsVM detailsVM = new DetailsVM
            {
                Product = _db.Products.Include(u => u.Categories)      
                .Where(u => u.Id == id).FirstOrDefault()     
                       
            };

            return View(detailsVM);
        }
    }
}
