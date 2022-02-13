using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Infrastructure.Data
{
    public class BakeryContext : DbContext
    {
        public BakeryContext(DbContextOptions<BakeryContext> options) : base(options)
        {
            
        }
        
        public DbSet<Sweet> Sweets { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Ingredient>().HasIndex(p => new {p.Name, p.Quantity, p.UnitsOfMeasure}).IsUnique();
        }
    }
}