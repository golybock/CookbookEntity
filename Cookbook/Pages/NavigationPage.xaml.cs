using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Cookbook.Database;
using Cookbook.Pages.LoginRegister;
using Cookbook.Pages.Profile;
using Cookbook.Pages.RecipesPage;

namespace Cookbook.Pages;

public partial class NavigationPage : Page
{
    private Client _client;
    private string _activePage;
    
    public NavigationPage()
    {
        InitializeComponent();
    }
    
    public NavigationPage(Client client)
    {
        _client = client;
        InitializeComponent();
    }

    private void HomeButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (_activePage != "Home")
        {
            _activePage = "Home";
            ClearNavigationService();
            BackButton.Visibility = Visibility.Collapsed;
            MainFrame.NavigationService.Navigate(new RecipesPage.RecipesPage());
        }
    }

    private void FavoriteButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (_activePage != "Fav")
        {
            _activePage = "Fav";
            BackButton.Visibility = Visibility.Visible;
            MainFrame.NavigationService.Navigate(new RecipesPage.RecipesPage());
        }
       
    }

    private void ProfilePage_OnClick(object sender, RoutedEventArgs e)
    {
        if (_activePage != "Profile")
        {
            _activePage = "Profile";
            BackButton.Visibility = Visibility.Visible;
            MainFrame.NavigationService.Navigate(new ProfilePage(_client));
        }
    }

    private void BackButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (MainFrame.NavigationService.CanGoBack)
        {
            _activePage = "Home";
            NavigationService.GoBack();
            if(!MainFrame.NavigationService.CanGoBack)
                BackButton.Visibility = Visibility.Collapsed;
        }

    }

    private void NavigationPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        NavigationService.RemoveBackEntry();
        MainFrame.NavigationService.Navigate(new RecipesPage.RecipesPage());
        _activePage = "Home";
    }

    private void ClearNavigationService()
    {
        while (MainFrame.NavigationService.CanGoBack) {
            try {
                MainFrame.NavigationService.RemoveBackEntry();
            } catch (Exception ex) {
                break;
            }
        }
    }

    private void AddRecipeButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (_activePage != "Add")
        {
            _activePage = "Add";
            BackButton.Visibility = Visibility.Visible;
            MainFrame.NavigationService.Navigate(new AddEditPage());
        }
    }
}