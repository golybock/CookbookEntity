using System.Linq;
using System.Windows.Controls;
using Cookbook.Database;

namespace Cookbook.Pages.RecipesPage;

public partial class RecipesPage : Page
{
    private CookbookContext _context = new CookbookContext();
    
    public RecipesPage()
    {
        InitializeComponent();
        RecipesListBox.ItemsSource = _context.Recipes.ToList();
    }
}