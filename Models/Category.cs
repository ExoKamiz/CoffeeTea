using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeTea.Models
{
    public class Category
    {
        [Key]

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Product Product { get; set; }

    }
}
