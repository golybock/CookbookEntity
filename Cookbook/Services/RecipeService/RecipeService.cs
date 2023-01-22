using System;
using System.Collections.Generic;
using System.Linq;
using Cookbook.Database;

namespace Cookbook.Services.RecipeService;

public class RecipeService : IRecipeService
{
    private CookbookContext _context = new CookbookContext();
    
    public Recipe GetRecipeById(int id)
    {
        if (id < 1)
            return null;

        return _context.Recipes.FirstOrDefault(c => c.Id == id)!;
    }

    public List<Recipe> FindRecipesWhere(string find)
    {
        if (string.IsNullOrEmpty(find))
            return null;

        return _context.Recipes
            .Where(
                c =>
                    c.Id.ToString() == find ||
                    c.Name.Contains(find) ||
                    c.RecipeType.Name.Contains(find) ||
                    c.Description!.Contains(find) ||
                    c.Client.Name!.Contains(find))
            .ToList();
    }

    public bool AddRecipe(Recipe recipe)
    {
        try
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool UpdateRecipe(Recipe recipe)
    {
        try
        {
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool DeleteRecipe(int id)
    {
        try
        {
            _context.Recipes.Remove(new Recipe(){Id = id});
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}