﻿using System.Windows;
using System.Windows.Controls;
using Cookbook.Database;

namespace Cookbook.Pages.Profile;

public partial class ProfilePage : Page
{
    private Client _client;
    
    public ProfilePage()
    {
        _client = new Client();
        DataContext = _client;
        InitializeComponent();
        ContentFrame.NavigationService.Navigate(new RecipesPage.RecipesPage());
    }

    public ProfilePage(Client client)
    {
        _client = client;
        DataContext = _client;
        InitializeComponent();
        ContentFrame.NavigationService.Navigate(new RecipesPage.RecipesPage());
    }
    
}