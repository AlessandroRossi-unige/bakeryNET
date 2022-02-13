using Core.Entities;

namespace Core.Specifications
{
    public class SweetsWithIngredientsSpecification : BaseSpecification<Sweet>
    {
        public SweetsWithIngredientsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Ingredients);
        }
    }
}