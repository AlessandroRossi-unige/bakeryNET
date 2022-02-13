using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public UnitsOfMeasure  UnitsOfMeasure { get; set; }
        public Sweet Sweet { get; set; }
        public int SweetId { get; set; }

        public Ingredient()
        {
        }

        public Ingredient(string name, double quantity, UnitsOfMeasure unitsOfMeasure, int sweetId)
        {
            Name = name;
            Quantity = quantity;
            UnitsOfMeasure = unitsOfMeasure;
            SweetId = sweetId;
        }
    }
}