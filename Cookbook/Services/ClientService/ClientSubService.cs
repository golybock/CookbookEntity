using System;
using System.Collections.Generic;
using System.Linq;
using Cookbook.Database;

namespace Cookbook.Services.ClientService;

public class ClientSubService : IClientSubService
{
    private CookbookContext _context = new CookbookContext();
    
    public List<ClientSub> GetClientSubs(int id)
    {
        if (id < 1)
            return null;
        
        return _context.ClientSubs.Where(c => c.ClientId == id).ToList();
    }

    public bool ClientSubOn(int subClientId, int clientId)
    {
        // в бд есть запись, где subclientId подписан на clientId
        return _context.ClientSubs
            .FirstOrDefault(
                c =>
                    c.Sub == subClientId &&
                    c.ClientId == clientId
            ) != null;
    }

    public bool AddSubClient(ClientSub clientSub)
    {
        try
        {
            _context.ClientSubs.Add(clientSub);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool UpdateSubClient(ClientSub clientSub)
    {
        try
        {
            _context.ClientSubs.Update(clientSub);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool DeleteSubClient(int id)
    {
        try
        {
            _context.ClientSubs.Remove(new ClientSub(){Id = id});
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}