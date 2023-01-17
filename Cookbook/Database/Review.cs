using System;
using System.Collections.Generic;

namespace Cookbook.Database;

public partial class Review
{
    public int Id { get; set; }

    public int RecipeId { get; set; }

    public int ClientId { get; set; }

    public int Grade { get; set; }

    public string? Description { get; set; }

    public bool? IsAnonymous { get; set; }

    public DateTime DateOfAdding { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;

    public virtual ICollection<ReviewImage> ReviewImages { get; } = new List<ReviewImage>();
}
