﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeTea.Models
{
    public class Product
    {
        [Key]

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ShortDescr { get; set; }

        public string Description { get; set; }

        [Range(1, int.MaxValue)]
        public double Price { get; set; }

        public string Image { get; set; }

        public string Country { get; set; }

        public int CategoryId { get; set; }
        public Category Categories { get; set; }


    }
}
