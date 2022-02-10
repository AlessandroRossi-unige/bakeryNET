using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BakeryContext : DbContext
    {
        public BakeryContext(DbContextOptions<BakeryContext> options) : base(options)
        {
        }
        
        public DbSet<Sweet> Sweets { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}