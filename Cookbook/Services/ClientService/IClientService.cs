using System.Collections.Generic;
using System.Windows.Documents;
using Cookbook.Database;

namespace Cookbook.Services.ClientService;

public interface IClientService
{
    public Client? GetClientById(int id);
    public Client GetClientByLogin(string login);
    public int AddClient(Client client);
    public bool UpdateClient(Client client);
    public bool DeleteClient(int id);

}