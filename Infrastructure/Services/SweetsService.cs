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

        public async Task<Sweet> CreateSweetAsync(string name, double price, string description, IReadOnlyList<Ingredient> ingredients, string pictureUrl)
        {
            var sweet = new Sweet(name, price, description, ingredients, pictureUrl);
            _genericRepo.Add(sweet);
            var result = await _genericRepo.Complete();
            if (result <= 0) return null;

            return sweet;
        }
        
        public async Task<Sweet> UpdateSweetAsync(string name, double price, string description, IReadOnlyList<Ingredient> ingredients, string pictureUrl)
        {
            var sweet = new Sweet(name, price, description, ingredients, pictureUrl);
            _genericRepo.Add(sweet);
            var result = await _genericRepo.Complete();
            if (result <= 0) return null;

            return sweet;
        }
        
        public async Task<Sweet> DeleteSweetAsync(int id)
        {
            var sweet = await _genericRepo.GetByIdAsync(id);
            if (sweet == null) return null;
            _genericRepo.Delete(sweet);
            var result = await _genericRepo.Complete();
            if (result <= 0) return null;

            return sweet;
        }

        public Task<IReadOnlyList<Sweet>> GetSweetsAsync()
        {
            throw new System.NotImplementedException();
        }


        // public Task<IReadOnlyList<Sweet>> GetSweetsAsync()
        // {
        //     var sweets = _genericRepo.ListAllAsync();
        //     return sweets;
        // }

        public Task<Sweet> GetSweetByIdAsync(int id)
        {
            return _genericRepo.GetByIdAsync(id);
        }
    }
}