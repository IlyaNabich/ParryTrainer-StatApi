

using Core.Abstractions;
using Core.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class UsersRepository (ParryTrainerDbContext context) : IUsersRepository
{
    public async Task<List<Users>> GetAll()
    {
        var userEntities = await context.Users
            .AsNoTracking()
            .ToListAsync();
        var user = userEntities
            .Select(x => Users.CreateUsers(x.UserId, x.UserName, x.Login, x.Password, x.RegDate, x.LastOnlineDate).user)
            .ToList();
        return user;
    }

    public async Task<Users> GetByLogin(string login)
    {
        var userEntity = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Login == login);
        
        var users = Users.CreateUsers(userEntity.UserId, userEntity.UserName, userEntity.Login, userEntity.Password, userEntity.RegDate, userEntity.LastOnlineDate).user;

        return users;
    }
    
    public async Task<Guid> Create(Users users)
    {
        var userEntity = new UsersEntity
        {
            UserId = users.UserId,
            UserName = users.UserName,
            Login = users.Login,
            Password = users.Password,
            RegDate = users.RegDate,
            LastOnlineDate = users.LastOnlineDate
        };
        await context.Users.AddAsync(userEntity);
        await context.SaveChangesAsync();
        
        return users.UserId;
    }

    public async Task<Guid> Update(Guid userId, string login, string password, string userName)
    {
        await context.Users.Where(x => x.UserId == userId).ExecuteUpdateAsync(s => s
            .SetProperty(x => x.Login, login)
            .SetProperty(x => x.Password, password)
            .SetProperty(x => x.UserName, userName));
        
        return userId;
    }

    public async Task<Guid> Delete(Guid userId)
    {
        await context.Users
            .Where(x => x.UserId == userId)
            .ExecuteDeleteAsync();
        
        return userId;
    }
}
