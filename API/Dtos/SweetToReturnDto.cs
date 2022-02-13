using System.Collections.Generic;

namespace API.Dtos
{
    public class SweetToReturnDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public IReadOnlyList<string> Ingredients { get; set; }
    }
}