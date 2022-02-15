using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ISweetsService
    {
        Task<Sweet> CreateSweetAsync(string name, double price, string description, IReadOnlyList<Ingredient> ingredients, string pictureUrl);
        Task<Sweet> DeleteSweetAsync(int id);
        Task<IReadOnlyList<Sweet>> GetSweetsAsync();
    }
}