using System;
using System.Collections.Generic;
using Core.Entities;

namespace API.Dtos
{
    public class SweetToReturnDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public IReadOnlyList<Ingredient> Ingredients { get; set; }
        public DateTime CreationDate { get; set; }
        public string PictureUrl { get; set; }
    }
}