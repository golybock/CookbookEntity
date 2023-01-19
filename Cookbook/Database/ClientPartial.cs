using System.Linq;

namespace Cookbook.Database;

public partial class Client
{
    private CookbookContext _context = new CookbookContext();
    public string ImagePath
    {
        get
        {
            var imagePath = _context.ClientImages.FirstOrDefault(c => c.ClientId == Id)?.ImagePath;

            if (imagePath != null)
                return imagePath;
            
            return "../../Resources/profile_image.png";

        }
    }
}