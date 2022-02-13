using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class SweetsService : ISweetsService
    {
        private readonly IGenericRepository<Sweet> _genericRepo;
        public SweetsService(IGenericRepository<Sweet> genericRepo)
        {
            _genericRepo = genericRepo;
        }

        public async Task<Sweet> CreateSweetAsync(string name, double price, IReadOnlyList<Ingredient> ingredients)
        {
            var sweet = new Sweet(name, price, ingredients);
            _genericRepo.Add(sweet);
            var result = await _genericRepo.Complete();
            if (result <= 0) return null;

            return sweet;
        }

        public Task<IReadOnlyList<Sweet>> GetSweetsAsync()
        {
            var sweets = _genericRepo.ListAllAsync();
            return sweets;
        }
    }
}