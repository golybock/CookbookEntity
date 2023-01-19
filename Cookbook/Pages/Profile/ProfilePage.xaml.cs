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
        DataContext = _client;
    }

    public ProfilePage(Client client)
    {
        _client = client;
        InitializeComponent();
        DataContext = _client;
    }
}