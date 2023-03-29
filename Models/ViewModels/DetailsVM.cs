using Microsoft.AspNetCore.Mvc;

namespace CoffeeTea.Models.ViewModels
{
    public class DetailsVM : Controller
    {
        public DetailsVM()
        {
            Product = new Product();      
        }
        public Product Product { get; set; }
    }
}
