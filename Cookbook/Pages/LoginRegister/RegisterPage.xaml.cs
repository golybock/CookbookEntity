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
        ChooseImage();
    }

    private void PersonPicture_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        ChooseImage();
    }

    private void PersonPicture_OnDrop(object sender, DragEventArgs e)
    {
        string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop);
        string file = files[0];
        // если файл картинка
        if (file.EndsWith(".png") || file.EndsWith(".jpg"))
        {
            SetImage(file);
        }
    }

    private void ChooseImage()
    {
        // открываем диалог выбора файла
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = "c:\\";
        openFileDialog.Filter = "Image files (*.png)|*.png|All files (*.*)|*.*";
        // если показан
        if (openFileDialog.ShowDialog() == true)
        {
            // если есть выбранный файл
            if (openFileDialog.FileName != String.Empty)
            {
                SetImage(openFileDialog.FileName);
            }
        }
    }

    private void SetImage(string path)
    {
        // сохраняем путь в объекте
        _client.ImagePath = path;
        // отображаем изображение
        PersonPicture.ProfilePicture = new BitmapImage(new Uri(_client.ImagePath));
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (NavigationService != null) 
            NavigationService.GoBack();
    }

    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}