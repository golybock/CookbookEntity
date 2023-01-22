using System.Collections.Generic;
using Cookbook.Database;

namespace Cookbook.Services.RecipeService;

public interface IRecipeService
{
    public Recipe GetRecipeById(int id);
    public List<Recipe> FindRecipesWhere(string find);
    public bool AddRecipe(Recipe recipe);
    public bool UpdateRecipe(Recipe recipe);
    public bool DeleteRecipe(int id);
}