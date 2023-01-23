using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Cookbook.Database;
using Microsoft.Win32;

namespace Cookbook.Pages.LoginRegister;

public partial class RegisterPage : Page
{
    private Client _client;
    
    public RegisterPage()
    {
        _client = new Client();
        InitializeComponent();
    }
    
    public RegisterPage(string login)
    {
        _client = new Client() { Login = login };
        InitializeComponent();
    }

    private void RegisterPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        DataContext = _client;
    }

    private void EditImageButton_OnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void PersonPicture_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        ChooseImage();
    }

    private void PersonPicture_OnDrop(object sender, DragEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void ChooseImage()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = "c:\\";
        openFileDialog.Filter = "Image files (*.png)|*.png|All files (*.*)|*.*";

        if (openFileDialog.ShowDialog() == true)
        {
            if (openFileDialog.FileName != String.Empty)
            {
                _client.ImagePath = openFileDialog.FileName;
                PersonPicture.ProfilePicture = new BitmapImage(new Uri(_client.ImagePath));
            }
        }
    }

    private void SetPhoto(string path)
    {
        _client.ImagePath = path;
    }
}