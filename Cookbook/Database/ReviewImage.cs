using System;
using System.Collections.Generic;

namespace Cookbook.Database;

public partial class ReviewImage
{
    public int Id { get; set; }

    public int ReviewId { get; set; }

    public string ImagePath { get; set; } = null!;

    public virtual Review Review { get; set; } = null!;
}
