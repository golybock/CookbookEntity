using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cookbook.Database;

namespace Cookbook.Services.ClientService;

public class ClientImageService : IClientImageService
{
    private CookbookContext _context = new CookbookContext();
    
    public List<ClientImage> GetClientImages(int id, int offset = 10)
    {
        if (offset == 0)
            return null;

        if (id < 1)
            return null;

        return _context.ClientImages.Where(c => c.ClientId == id).Take(offset).ToList();

    }

    public bool AddClientImage(ClientImage clientImage)
    {
        try
        {
            _context.ClientImages.Add(clientImage);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteClientImage(int id)
    {
        try
        {
            _context.ClientImages.Remove(new ClientImage(){Id = id});
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UpdateClientImage(ClientImage clientImage)
    {
        try
        {
            string photoId = $"{clientImage.Client.Login}_{DateTime.Now.ToLongTimeString()}";
            CopyImageToDocuments(clientImage.ImagePath, photoId, "png");
            _context.ClientImages.Update(clientImage);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    private string CopyImageToDocuments(string source, string filename, string format)
    {
        string path = $"C:\\Users\\{Environment.UserName}\\Documents\\Images\\{filename}.{format}";

        try
        {
            File.Copy(source, path);
            return path;
        }
        catch (Exception e)
        {
            return null;
        }
    }
    

    private bool ImageExists(string path)
    {
        return File.Exists(path);
    }
}