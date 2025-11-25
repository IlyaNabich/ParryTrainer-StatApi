using Application.Auth;
using Core.Abstractions;
using Core.Interfaces;
using Core.Models;

namespace Application.Services;

public class UsersService (IUsersRepository usersRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider) : IUserService
{

    public async Task<List<Users>> GetAllUsers() =>
        await usersRepository.GetAll();
    

    public async Task<Guid> Register(Users users) =>
        await usersRepository.Create(users);

    

    public async Task<Guid> UpdateUser(Guid userId, string login, string password, string userName) =>
        await usersRepository.Update(userId, login, password, userName);
    

    public async Task<Guid> DeleteUser(Guid userId) =>
        await usersRepository.Delete(userId);
    
    public async Task<string> Login(string login, string password)
    {
        var user = await usersRepository.GetByLogin(login);

        var result = passwordHasher.Verify(password, user.Password);

        if (result == false)
        {
            throw new Exception("Invalid password");
        }

        return jwtProvider.GenerateToken(user);
    }
}