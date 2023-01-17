using System;
using System.Collections.Generic;

namespace Cookbook.Database;

public partial class ClientImage
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public string ImagePath { get; set; } = null!;

    public DateTime DateOfAdded { get; set; }

    public virtual Client Client { get; set; } = null!;
}
