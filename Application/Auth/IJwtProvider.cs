using Core.Models;

namespace Application.Auth;

public interface IJwtProvider
{
    public string GenerateToken(Users users);
}