namespace ClinicManagmentSystem.API.Business.IServices;

public interface IAuthenticationService
{
    bool VerifyPassword(string sendedPassword, string hashedPassword);
    string EncodePassword(string sendedPassword);
}
