using System;
using System.Linq;
using Cookbook.Database;
using Cookbook.Models;
using Cookbook.Services.ClientService;

namespace Cookbook.Services.RegisterService;

public class RegisterService
{
    private ClientService.ClientService _clientService;
    private ClientService.ClientImageService _clientImageService;

    public RegisterService()
    {
        _clientService = new ClientService.ClientService();
        _clientImageService = new ClientImageService();
    }

    public RegisterResult Register(Client client, ClientImage clientImage)
    {
        if(!PasswordValid(client.Password))
            return RegisterResults.InvalidPassword;

        if (!LoginValid(client.Login))
            return RegisterResults.InvalidLogin;

        if (client.Login == String.Empty &&
            client.Password == string.Empty)
            return RegisterResults.InvalidData;


        client.Id = _clientService.AddClient(client);

        clientImage.ClientId = client.Id;
        
        _clientImageService.AddClientImage(clientImage);

        return RegisterResults.Successfully;
    }

    public bool PasswordValid(string password)
    {
        return PasswordNotNull(password) &&
               PasswordHasDigit(password) &&
               PasswordHasSymbol(password) &&
               PasswordHasUpper(password) &&
               PasswordLengthValid(password);
    }

    public bool PasswordNotNull(string password)
    {
        return string.IsNullOrEmpty(password);
    }
    
    public bool PasswordHasDigit(string password)
    {
        return password.Any(char.IsDigit);
    }

    public bool PasswordHasUpper(string password)
    {
        return password.Any(char.IsUpper);
    }

    public bool PasswordLengthValid(string password)
    {
        return password.Length >= 8;
    }

    public bool PasswordHasSymbol(string password)
    {
        return password.Any(char.IsPunctuation);
    }

    public bool LoginValid(string login)
    {
        return _clientService.GetClientByLogin(login) == null;
    }
    
}