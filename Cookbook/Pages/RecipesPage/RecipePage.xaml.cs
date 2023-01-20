using System.Windows.Controls;
using Cookbook.Database;

namespace Cookbook.Pages.RecipesPage;

public partial class RecipePage : Page
{
    private Recipe _recipe;
    
    public RecipePage(Recipe recipe)
    {
        _recipe = recipe;
        InitializeComponent();
        DataContext = _recipe;
    }
}