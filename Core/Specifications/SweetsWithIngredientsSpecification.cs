using Core.Entities;

namespace Core.Specifications
{
    
    
    public class SweetsWithIngredientsSpecification : BaseSpecification<Sweet>
    {
        public SweetsWithIngredientsSpecification(SweetSpecParam sweetParams) :base(x =>
            (string.IsNullOrEmpty(sweetParams.Search) || x.Name.ToLower().Contains(sweetParams.Search)) )
        {
            AddInclude(x => x.Ingredients);
            AddOrderBy(x => x.Name);
            ApplyPaging(sweetParams.PageSize * (sweetParams.PageIndex - 1), sweetParams.PageSize);

            if (!string.IsNullOrEmpty(sweetParams.Sort))
            {
                switch (sweetParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }
        
        public SweetsWithIngredientsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Ingredients);
        }
    }
}