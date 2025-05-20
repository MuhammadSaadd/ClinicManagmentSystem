namespace ClinicManagementSystem.Test;

public class AuthenticationServiceTests
{
    private readonly AuthenticationService authService;

    public AuthenticationServiceTests()
    {
        authService = new AuthenticationService();
    }

    [Fact]
    public void VerifyPassword_Should_ReturnTrue_When_PasswordsMatch()
    {
        // Arrange
        string password = "password123";
        string hashedPassword = authService.EncodePassword(password);

        // Act
        bool result = authService.VerifyPassword(password, hashedPassword);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void VerifyPassword_Should_ReturnFalse_When_PasswordsDoNotMatch()
    {
        // Arrange
        string password = "password123";
        string wrongPassword = "wrongpassword";
        string hashedPassword = authService.EncodePassword(password);

        // Act
        bool result = authService.VerifyPassword(wrongPassword, hashedPassword);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void EncodePassword_Should_ReturnHashedPassword()
    {
        // Arrange
        string password = "password123";

        // Act
        string hashedPassword = authService.EncodePassword(password);

        // Assert
        Assert.NotNull(hashedPassword);
        Assert.NotEmpty(hashedPassword);
    }
}
