using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Cookbook.Services.ClientService;

namespace Cookbook.Pages.LoginRegister;

public partial class LoginPage : Page
{
    private ClientService _clientService;
    private string _login;
    private string _password;
    
    public LoginPage()
    {
        _clientService = new ClientService();
        InitializeComponent();
    }

    private void GuestButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new NavigationPage());
    }

    private void LoginButton_OnClick(object sender, RoutedEventArgs e)
    {
        GetInfo();
        if (_clientService.Auth(_login, _password))
        {
            
        }
        else
        {
            ErrorTextBlock.Visibility = Visibility.Visible;
            LoginTextBox.BorderBrush = Brushes.Red;
            ErrorTextBlock.Text = "Неверный логин или пароль";
        }
    }

    private void GetInfo()
    {
        _login = LoginTextBox.Text;
        _password = PasswordBox.Password;
    }
}