using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace API.Dtos
{
    public class SweetsDto
    {
        [Required]
        [StringLength(255, ErrorMessage = "The Name value cannot exceed 255 characters. ")] 
        public string Name { get; set; }
        [Required] 
        [Range(0.1, Double.MaxValue, ErrorMessage = "Price value not allowed")]
        public double Price { get; set; }
        public string Description { get; set; }
        public IReadOnlyList<Ingredient> Ingredients { get; set; }
        public string PictureUrl { get; set; }
    }
}