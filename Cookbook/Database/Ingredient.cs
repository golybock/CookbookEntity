using System;
using System.Collections.Generic;

namespace Cookbook.Database;

public partial class Ingredient
{
    public int Id { get; set; }

    public int MeasureId { get; set; }

    public string Name { get; set; } = null!;

    public string? ImagePath { get; set; }

    public virtual Measure Measure { get; set; } = null!;

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; } = new List<RecipeIngredient>();
}
