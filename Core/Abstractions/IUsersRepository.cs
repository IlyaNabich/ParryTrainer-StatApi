using Core.Models;


namespace Core.Abstractions;

public interface IUsersRepository
{
    public Task<List<Users>> GetAll();

    public Task<Guid> Create(Users users);

    public Task<Guid> Update(Guid userId, string login, string password, string userName);
    
    public Task<Guid> Delete(Guid userId);

    public Task<Users> GetByLogin(string login);
}