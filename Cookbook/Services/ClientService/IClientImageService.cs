using System.Collections.Generic;
using Cookbook.Database;

namespace Cookbook.Services.ClientService;

public interface IClientImageService
{
    public List<ClientImage> GetClientImages(int id, int offset = 10);
    public bool AddClientImage(ClientImage clientImage);
    public bool DeleteClientImage(int id);
    public bool UpdateClientImage(ClientImage clientImage);
}