using System.Windows;
using System.Windows.Controls;
using Cookbook.Database;
using Cookbook.Pages.LoginRegister;
using Cookbook.Pages.Profile;

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

    private void HomeButton_OnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void FavoriteButton_OnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void ProfilePage_OnClick(object sender, RoutedEventArgs e)
    {
        BackButton.Visibility = Visibility.Visible;
        MainFrame.NavigationService.Navigate(new ProfilePage());
    }

    private void BackButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (MainFrame.NavigationService.CanGoBack)
        {
            NavigationService.GoBack();
            if(!MainFrame.NavigationService.CanGoBack)
                BackButton.Visibility = Visibility.Collapsed;
        }

        
    }
}