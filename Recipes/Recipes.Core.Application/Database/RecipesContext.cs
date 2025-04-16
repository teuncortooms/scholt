using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Recipes.Core.Domain.Entities;

namespace Recipes.Core.Application.Database;

internal class RecipesContext : DbContext
{
    public DbSet<Recipe> Recipes { get; private set; } = null!;

    public RecipesContext(DbContextOptions<RecipesContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}