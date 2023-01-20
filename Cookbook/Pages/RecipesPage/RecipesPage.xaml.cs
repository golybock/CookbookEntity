﻿using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

    private void DeleteMenuItem_OnClick(object sender, RoutedEventArgs e)
    {
        var accept = 
            MessageBox.Show(
                "Удалить?",
                "Удаление",
                MessageBoxButton.YesNo);

        if (accept == MessageBoxResult.Yes)
        {
            // удалить
        }
        
    }

    private void EditMenuItem_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new AddEditPage(RecipesListBox.SelectedItem as Recipe));
    }

    private void RecipesListBox_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if(RecipesListBox.SelectedItem != null)
            NavigationService.Navigate(new RecipePage(RecipesListBox.SelectedItem as Recipe));
    }
}