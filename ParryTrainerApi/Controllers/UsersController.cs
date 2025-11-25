using Application.Auth;
using Core.Models;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ParryTrainerApi.Contracts.User;
using ParryTrainerApi.Contracts.User.Login;

namespace ParryTrainerApi.Controllers;

[ApiController]
[Route("[controller]")]

public class UsersController (IUserService userService, IProfilesService profilesService, IStatsService statsService, IPasswordHasher passwordHasher) : ControllerBase
{
    [HttpGet("AllUsers")]
    public async Task<ActionResult<UsersResponse>> GetAllUsers()
    {
        var user = await userService.GetAllUsers();

        var response = user.Select(x => new UsersResponse(x.UserId, x.UserName, x.LastOnlineDate, x.RegDate));
        
        return Ok(response);
    }

    [HttpPost("Login")]
    public async Task<ActionResult> Login([FromBody]LoginRequest request)
    {
        var token = await userService.Login(request.Login, request.Password);
        
        return Ok(token);
    }
    
    [HttpPost]
    public async Task<ActionResult<UsersResponse>> Register([FromBody] UsersRequest request)
    {
        var id = Guid.NewGuid();
        var (user,error) = Users.CreateUsers(
            id,
            request.Username,
            request.Login,
            passwordHasher.Generate(request.Password),
            DateTime.UtcNow, 
            DateTime.UtcNow
            );
        var profile = Profiles.CreateProfile(
            id,
            "Unknown",
            "Unknown",
            "Unknown",
            "Unknown",
            "Unknown",
            "Unknown",
            "Unknown"
        );
        var stat = Stats.CreateStats(id);
        if (string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var users = await userService.Register(user);
        await statsService.CreateUserStats(stat);
        await profilesService.CreateUserProfileAsync(profile);
        return Ok(users);
    }
    
    
    [HttpPut]
    public async Task<ActionResult> UpdateUser([FromBody] UsersRequest request, Guid userId)
    {
        var user = await userService.UpdateUser(userId, request.Login, request.Password, request.Username);
        
        return Ok(user);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteUser(Guid userId)
    {
        var user = await userService.DeleteUser(userId);
        
        return Ok(user);
    }
}