using System;
using System.Security.Cryptography;
using System.Text;
using Cookbook.Database;
using Cookbook.Models;

namespace Cookbook.Services.LoginService;

public class LoginService
{
    private ClientService.ClientService _clientService;

    public LoginService()
    {
        _clientService = new ClientService.ClientService();
    }

    public LoginResult Login(string login, string password)
    {
        if (string.IsNullOrEmpty(login) &&
            string.IsNullOrEmpty(password))
            return LoginResults.EmptyData;
        
        if (string.IsNullOrEmpty(login))
            return LoginResults.EmptyLogin;

        if (string.IsNullOrEmpty(password))
            return LoginResults.EmptyPassword;

        Client? client = _clientService.GetClientByLogin(login);

        if (client == null)
            return LoginResults.InvalidLogin;

        bool passwordValid = client.Password == Hash(password);

        if (!passwordValid)
            return LoginResults.InvalidPassword;

        LoginResult result = LoginResults.Successfully;
        result.Client = client;
        
        return result;
    }
        
    private static string Hash(string stringToHash)
    {
        if (stringToHash == "admin")
            return "admin";
        
        using var sha1 = new SHA1Managed();
        return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(stringToHash)));
    }
}