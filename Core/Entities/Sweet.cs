using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Sweet : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public IReadOnlyList<Ingredient> Ingredients {get; set; }
        public string PictureUrl { get; set; }
        public DateTime CreationDate { get;  } = DateTime.Today; 

        public Sweet()
        {
        }

        public Sweet(string name, double price, string description, IReadOnlyList<Ingredient> ingredients, string pictureUrl)
        {
            Name = name;
            Price = price;
            Ingredients = ingredients;
            Description = description;
            PictureUrl = pictureUrl;
        }
    }
}