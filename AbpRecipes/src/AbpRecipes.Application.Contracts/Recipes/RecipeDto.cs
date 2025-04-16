using System;
using Volo.Abp.Application.Dtos;

namespace AbpRecipes.Recipes;

public class RecipeDto : AuditedEntityDto<Guid>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}