using System.CodeDom.Compiler;
using System.Reflection.Metadata.Ecma335;
using Core.Validations;

namespace Core.Models;

public class Users
{
    private Users(Guid userId, string userName, string login, string password)
    {
        UserId = userId;
        UserName = userName;
        Login = login;
        Password = password;
        RegDate = DateTime.UtcNow;
        LastOnlineDate = DateTime.UtcNow;
    }
    
    public Guid UserId { get; }

    public string UserName { get; }

    public string Login { get; }
    
    public string Password { get; }
    
    public DateTime RegDate { get; }
    
    public DateTime LastOnlineDate { get; }

    public static (Users user, string Error) CreateUsers(Guid userId, string userName, string login, string password)
    {
        var error = UsersValidation.UserValidate(login, password, userName);
        var user = new Users(userId, userName, login, password);
        
        return (user,error);
    }
}