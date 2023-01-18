using System.Linq;

namespace Cookbook.Database;

public partial class Recipe
{
    private CookbookContext _context = new CookbookContext();
    
    public string ImagePath
    {
        get
        {
            var imagePath = _context.RecipeImages
                .FirstOrDefault(c => c.RecipeId == Id)
                ?.ImagePath;
            
            if (imagePath != null)
                return imagePath;

            return null;
        }
    }
}