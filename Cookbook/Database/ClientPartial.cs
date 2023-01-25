using System.IO;
using System.Linq;
using Cookbook.Models.Register.Password;

namespace Cookbook.Database;

public partial class Client
{
    private CookbookContext _context = new CookbookContext();

    private string _imagePath;

    private string GetImagePath()
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

    public string ImagePath => GetImagePath();

    public void SetImagePath(string? value)
    {
        _imagePath = value;
    }
    
}