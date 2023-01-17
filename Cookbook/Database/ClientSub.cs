using System;
using System.Collections.Generic;

namespace Cookbook.Database;

public partial class ClientSub
{
    public int Id { get; set; }

    public int Sub { get; set; }

    public int ClientId { get; set; }

    public DateTime DateOfSub { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Client SubNavigation { get; set; } = null!;
}
