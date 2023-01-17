using System;
using System.Collections.Generic;

namespace Cookbook.Database;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<RecipeCategory> RecipeCategories { get; } = new List<RecipeCategory>();
}
