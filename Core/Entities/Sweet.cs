using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Sweet : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public IReadOnlyList<Ingredient> Ingredients {get; set; }

        public Sweet()
        {
        }

        public Sweet(string name, double price, IReadOnlyList<Ingredient> ingredients)
        {
            Name = name;
            Price = price;
            Ingredients = ingredients;
        }
    }
}