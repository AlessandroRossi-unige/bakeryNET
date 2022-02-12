using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Sweet : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }

        public Sweet(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}