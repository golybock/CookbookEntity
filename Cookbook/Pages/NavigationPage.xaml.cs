using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
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
    }
    
    public NavigationPage(Client client)
    {
        _client = client;
        InitializeComponent();
    }

    private void HomeButton_OnClick(object sender, RoutedEventArgs e)
    {
        ClearNavigationService();
        BackButton.Visibility = Visibility.Collapsed;
        MainFrame.NavigationService.Navigate(new RecipesPage.RecipesPage());
    }

    private void FavoriteButton_OnClick(object sender, RoutedEventArgs e)
    {
        BackButton.Visibility = Visibility.Visible;
        MainFrame.NavigationService.Navigate(new RecipesPage.RecipesPage());
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

    private void NavigationPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        NavigationService.RemoveBackEntry();
        MainFrame.NavigationService.Navigate(new RecipesPage.RecipesPage());
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
}