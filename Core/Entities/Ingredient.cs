using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public UnitsOfMeasure  UnitsOfMeasure { get; set; }
       

        public Ingredient()
        {
        }

        public Ingredient(string name, double quantity, UnitsOfMeasure unitsOfMeasure)
        {
            Name = name;
            Quantity = quantity;
            UnitsOfMeasure = unitsOfMeasure;
        }
    }
}