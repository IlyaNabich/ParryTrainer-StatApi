using Core.Models;

namespace Core.Interfaces;

public interface IUserService
{
    public Task<List<Users>> GetAllUsers();

    public Task<Guid> Register(Users users);

    public Task<Guid> UpdateUser(Guid userId, string login, string password, string userName);
    
    public Task<Guid> DeleteUser(Guid userId);
    
    public Task<string> Login(string login, string password);
}