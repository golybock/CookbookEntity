using System.Windows;
using System.Windows.Controls;
using Cookbook.Database;

namespace Cookbook.Pages.Profile;

public partial class ProfilePage : Page
{
    private Client _client;
    public ProfilePage()
    {
        _client = new Client();
        InitializeComponent();
    }

    public ProfilePage(Client client)
    {
        _client = client;
        InitializeComponent();
    }

    private void ProfilePage_OnLoaded(object sender, RoutedEventArgs e)
    {
        DataContext = _client;
        ContentFrame.NavigationService.Navigate(new RecipesPage.RecipesPage());
    }
}