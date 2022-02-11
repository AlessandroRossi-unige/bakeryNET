namespace Core.Entities
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public UnitsOfMeasure  UnitsOfMeasure { get; set; }

    }
}