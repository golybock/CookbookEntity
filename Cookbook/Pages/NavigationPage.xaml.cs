using System.Windows.Controls;
using Cookbook.Database;
using Cookbook.Pages.LoginRegister;

namespace Cookbook.Pages;

public partial class NavigationPage : Page
{
    private Client _client;
    
    public NavigationPage()
    {
        InitializeComponent();
        MainFrame.NavigationService.Navigate(new RecipesPage.RecipesPage());
    }
    
    public NavigationPage(Client client)
    {
        _client = client;
        InitializeComponent();
    }
    
}