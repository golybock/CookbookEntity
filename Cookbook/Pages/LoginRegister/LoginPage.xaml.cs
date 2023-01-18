using System.Windows;
using System.Windows.Controls;

namespace Cookbook.Pages.LoginRegister;

public partial class LoginPage : Page
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private void GuestButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new NavigationPage());
    }
}