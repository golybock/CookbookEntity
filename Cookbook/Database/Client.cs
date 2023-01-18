using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cookbook.Database;

public partial class Client
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime DateOfRegistration { get; set; }
    
    public virtual ICollection<ClientImage> ClientImages { get; } = new List<ClientImage>();

    public virtual ICollection<ClientSub> ClientSubClients { get; } = new List<ClientSub>();

    public virtual ICollection<ClientSub> ClientSubSubNavigations { get; } = new List<ClientSub>();

    public virtual ICollection<FavoriteRecipe> FavoriteRecipes { get; } = new List<FavoriteRecipe>();

    public virtual ICollection<Recipe> Recipes { get; } = new List<Recipe>();

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();
}
