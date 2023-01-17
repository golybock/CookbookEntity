using System;
using System.Collections.Generic;

namespace Cookbook.Database;

public partial class Measure
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Ingredient> Ingredients { get; } = new List<Ingredient>();
}
