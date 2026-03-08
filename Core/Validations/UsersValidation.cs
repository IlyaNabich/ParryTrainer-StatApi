using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

namespace Core.Validations;

public static class UsersValidation
{
    // ReSharper disable once InconsistentNaming
    private const int MAX_LOGIN_LENGTH = 30;
    // ReSharper disable once InconsistentNaming
    private const int MAX_PASSWORD_LENGTH = 50;
    // ReSharper disable once InconsistentNaming
    private const int MIN_LOGIN_LENGTH = 3;
    // ReSharper disable once InconsistentNaming
    private const int MIN_PASSWORD_LENGTH = 8;
    // ReSharper disable once InconsistentNaming
    private const int MAX_USERNAME_LENGTH = 20;
    // ReSharper disable once InconsistentNaming
    private const int MIN_USERNAME_LENGTH = 5;
    public static string UserValidate(string login, string password, string userName)
    {
        string error = string.Empty;
        if(string.IsNullOrWhiteSpace(login) || login.Length > MAX_LOGIN_LENGTH || !login.Any(x => x > 127) || login.Length < MIN_LOGIN_LENGTH){
            error = "invalid login";
        }

        if (string.IsNullOrWhiteSpace(password) || password.Length > MAX_PASSWORD_LENGTH ||
            !password.Any(x => x > 127) || password.Length < MIN_PASSWORD_LENGTH)
        {
            error = "invalid password";
        }

        if (string.IsNullOrWhiteSpace(userName) || userName.Length > MAX_USERNAME_LENGTH ||
            !userName.Any(x => x > 127) || userName.Length < MIN_USERNAME_LENGTH)
        {
            error = "invalid username";
        }
        return error;
    }
}