using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class BakeryConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(s => s.UnitsOfMeasure)
                .HasConversion(
                    o => o.ToString(),
                    o => (UnitsOfMeasure) Enum.Parse(typeof(UnitsOfMeasure), o)
                );
        }
    }
}