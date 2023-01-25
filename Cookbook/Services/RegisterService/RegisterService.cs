using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Cookbook.Database;
using Cookbook.Models;
using Cookbook.Models.Register;
using Cookbook.Models.Register.Password;
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
        PasswordResult passwordResult = PasswordValidate(client.Password);
        
        if (!passwordResult.Result)
        {
            return new RegisterResult()
            {
                Code = 102, Result = false,
                PasswordResult = passwordResult,
                Description = "Неверный пароль"
            };
        }
            

        if (!LoginValid(client.Login))
            return RegisterResults.InvalidLogin;

        if (client.Login == String.Empty &&
            client.Password == string.Empty)
            return RegisterResults.InvalidData;

        client.Password = Hash(client.Password);

        client.Id = _clientService.AddClient(client);

        clientImage.ClientId = client.Id;
        clientImage.Client = client;
        
        _clientImageService.AddClientImage(clientImage);

        return RegisterResults.Successfully;
    }
    
    private static string Hash(string stringToHash)
    {
        if (stringToHash == "admin")
            return "admin";
        
        using var sha1 = new SHA1Managed();
        return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(stringToHash)));
    }

    public PasswordResult PasswordValidate(string password)
    {
        if (!PasswordNotNull(password))
            return PasswordResults.EmptyPassword;
        
        if(!PasswordHasDigit(password))
            return PasswordResults.NeedDigit;

        if (!PasswordHasSymbol(password))
            return PasswordResults.NeedSymbol;

        if (!PasswordHasUpper(password))
            return PasswordResults.NeedUpper;

        if (!PasswordLengthValid(password))
            return PasswordResults.NeedLength;
        
        
        return PasswordResults.Successfully;

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
        return !string.IsNullOrEmpty(password);
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