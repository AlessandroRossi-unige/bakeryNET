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

        public async Task<Sweet> CreateSweetAsync(string name, double price)
        {
            var sweet = new Sweet(name, price);
            _genericRepo.Add(sweet);
            var result = await _genericRepo.Complete();
            if (result <= 0) return null;

            return sweet;
        }
    }
}