using System.IO;
using System.Linq;

namespace Cookbook.Database;

public partial class Client
{
    private CookbookContext _context = new CookbookContext();
    private string _imagePath;
    public string ImagePath
    {
        get
        {
            if (this.Id == 0)
            {
                return _imagePath;
            }
            
            var imagePath = _context.ClientImages
                .FirstOrDefault(c => c.ClientId == Id)?
                .ImagePath;

            if (!File.Exists(imagePath))
                return null;
            
            return imagePath;
        }
        set => _imagePath = value;
    }
}