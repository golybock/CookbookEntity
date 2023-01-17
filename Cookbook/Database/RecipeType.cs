using System;
using System.Collections.Generic;

namespace Cookbook.Database;

public partial class RecipeType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Recipe> Recipes { get; } = new List<Recipe>();
}
