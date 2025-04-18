﻿using System.Text.Json.Serialization;
using Recipes.Core.Domain.Entities;

namespace Recipes.Core.Application.Recipes.Models;

public record RecipeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    [JsonConstructor] private RecipeDto() { }

    public RecipeDto(Recipe recipe)
    {
        Id = recipe.Id;
        Name = recipe.Name;
    }
}