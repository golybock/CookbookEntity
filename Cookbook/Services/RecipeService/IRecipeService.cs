using System.Collections.Generic;
using Cookbook.Database;

namespace Cookbook.Services.RecipeService;

public interface IRecipeService
{
    public Recipe GetRecipeById(int id);
    public List<Recipe> FindRecipes(string find);
    public bool UpdateRecipe(Recipe recipe);
    public bool DeleteRecipe(int id);
}