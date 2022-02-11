using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ISweetsService
    {
        Task<Sweet> CreateSweetAsync(string name, double price);
    }
}