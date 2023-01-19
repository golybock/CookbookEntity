using System.Collections.Generic;
using Cookbook.Database;

namespace Cookbook.Services.ClientService;

public interface IClientSubService
{
    public List<ClientSub> GetClientSubs(int id);
    public bool ClientSubOn(int subClientId, int clientId);
    public bool AddSubClient(ClientSub clientSub);
    public bool UpdateSubClient(ClientSub clientSub);
    public bool DeleteSubClient(int id);
}