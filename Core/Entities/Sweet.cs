namespace Core.Entities
{
    public class Sweet : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Sweet(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}