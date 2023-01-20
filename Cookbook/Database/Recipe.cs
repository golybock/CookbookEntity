using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cookbook.Database;

public partial class Recipe
{
    private string _name;
    
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int RecipeTypeId { get; set; }
    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Наименование не может быть пустым");
            }

            _name = value;
        } } 

    public DateTime DateOfCreation { get; set; }

    public string? Description { get; set; }

    public string? PathToTextFile { get; set; }

    public int PortionCount { get; set; }

    public int CookingTime { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<FavoriteRecipe> FavoriteRecipes { get; } = new List<FavoriteRecipe>();

    public virtual ICollection<RecipeCategory> RecipeCategories { get; } = new List<RecipeCategory>();

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; } = new List<RecipeIngredient>();

    public virtual RecipeStat? RecipeStat { get; set; }

    public virtual RecipeType RecipeType { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();
}
