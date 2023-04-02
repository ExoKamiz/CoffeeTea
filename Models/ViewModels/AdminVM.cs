using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoffeeTea.Models.ViewModels
{
    public class AdminVM : Controller
    {
        public IEnumerable<Product>? Products { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
    }
}
