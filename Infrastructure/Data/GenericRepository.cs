using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository <T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly BakeryContext _context;
        public GenericRepository(BakeryContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return (IReadOnlyList<T>) await _context.Sweets.Include(s => s.Ingredients).ToListAsync();
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
    }
}