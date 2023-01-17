using System;
using System.Collections.Generic;

namespace Cookbook.Database;

public partial class RecipeStat
{
    public int RecipeId { get; set; }

    public decimal? Squirrels { get; set; }

    public decimal? Fats { get; set; }

    public decimal? Carbohydrates { get; set; }

    public decimal? Kilocalories { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;
}
