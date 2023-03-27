using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoffeeTea.Models.ViewModels
{
    public class ProductVM : Controller
    { 
            public Product Product { get; set; }
            public IEnumerable<SelectListItem> CategorySelectList { get; set; }
    }
}
