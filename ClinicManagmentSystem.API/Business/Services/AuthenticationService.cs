namespace ClinicManagmentSystem.API.Business.Services;

public class AuthenticationService : IAuthenticationService
{
    public bool VerifyPassword(string sendedPassword, string hashedPassword)
    {
        if (!BCrypt.Net.BCrypt.Verify(sendedPassword, hashedPassword))
            return false;
        return true;
    }

    public string EncodePassword(string sendedPassword)
    {
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(sendedPassword);
        return hashedPassword;
    }
}
