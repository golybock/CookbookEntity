using Cookbook.Database;

namespace Cookbook.Models;

public class LoginResult
{
    public int Code { get; set; }
    public bool Result { get; set; }
    public string Description { get; set; }
    public Client Client { get; set; }
}