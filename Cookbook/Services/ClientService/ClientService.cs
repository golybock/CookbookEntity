using System.Linq;
using Cookbook.Database;
using Cookbook.Models;

namespace Cookbook.Services.ClientService;

public class ClientService : IClientService
{
    private CookbookContext _context = new CookbookContext();
    
    public Client? GetClientById(int id)
    {
        if (id < 1)
            return null;

        return _context.Clients.FirstOrDefault(c => c.Id == id);
    }

    public Client? GetClientByLogin(string login)
    {
        if (string.IsNullOrEmpty(login))
            return null;

        return _context.Clients.FirstOrDefault(c => c.Login == login);
    }

    public bool AddClient(Client client)
    {
        try
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UpdateClient(Client client)
    {
        try
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteClient(int id)
    {
        try
        {
            _context.Clients.Remove(new Client(){Id = id});
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}