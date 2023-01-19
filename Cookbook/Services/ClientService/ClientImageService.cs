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
            _context.ClientImages.Remove(new ClientImage(){ClientId = id});
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
            _context.ClientImages.Update(clientImage);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    private bool CopyImageToDocuments(byte[] image, string filename, string format)
    {
        string path = $"C:\\{Environment.UserName}\\Documents\\Images\\{filename}.{format}";

        try
        {
            using StreamWriter sw = new StreamWriter(path);
            sw.Write(image);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private bool ImageExists(string path)
    {
        return File.Exists(path);
    }
}