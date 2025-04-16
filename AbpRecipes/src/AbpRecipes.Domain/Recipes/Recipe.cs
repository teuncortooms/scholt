using System.Collections.Generic;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace AbpRecipes.Recipes;

public class Recipe : AuditedAggregateRoot<Guid>
{
    public required string Name { get; init; }
    public required List<Ingredient> Ingredients { get; init; }
    public required List<Instruction> Instructions { get; init; }
}