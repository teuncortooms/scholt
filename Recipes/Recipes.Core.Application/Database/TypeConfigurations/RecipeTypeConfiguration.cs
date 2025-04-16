using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Recipes.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Recipes.Core.Application.Database.TypeConfigurations;

internal class RecipeTypeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasIndex(s => s.Name).IsUnique();
        builder.Property(e => e.Name).HasMaxLength(100);

        builder.OwnsMany(e => e.Instructions, i => { i.ToJson(); });
        builder.OwnsMany(e => e.Ingredients, i => { i.ToJson(); });
    }
}

