using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class SweetsDto
    {
        [Required]
        [StringLength(4, ErrorMessage = "The Name value cannot exceed 4 characters. ")] 
        public string Name { get; set; }
        [Required]
        [Range(0.1, Double.MaxValue, ErrorMessage = "Price value not allowed")]
        public double Price { get; set; }
    }
}