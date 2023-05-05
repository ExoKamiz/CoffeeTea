using CoffeeTea.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Image
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Url { get; set; }

    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public Product? Product { get; set; }
}
