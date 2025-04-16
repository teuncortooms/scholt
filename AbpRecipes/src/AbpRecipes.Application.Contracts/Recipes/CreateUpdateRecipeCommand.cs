using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AbpRecipes.Recipes;

public class CreateUpdateRecipeCommand
{
    [Required] 
    [StringLength(3)] 
    public string Name { get; set; } = string.Empty;
    [MinLength(2)]
    public IList<string> Ingredients { get; set; } = [];
    [MinLength(2)]
    public IList<string> Instructions { get; set; } = [];
}