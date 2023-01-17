using System;
using System.Collections.Generic;

namespace Cookbook.Database;

public partial class RecipeImage
{
    public int Id { get; set; }

    public int RecipeId { get; set; }

    public string ImagePath { get; set; } = null!;

    public int ImageNumber { get; set; }
}
