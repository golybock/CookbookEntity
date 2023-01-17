using System;
using System.Collections.Generic;

namespace Cookbook.Database;

public partial class FavoriteRecipe
{
    public int Id { get; set; }

    public int RecipeId { get; set; }

    public int ClientId { get; set; }

    public DateTime DateOfAdding { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;
}
