namespace ClinicManagmentSystem.API.Validations;

public static class PasswordValidator
{
    /// <summary>
    /// return true if the password meet the conditions, otherwise return false
    /// </summary>
    public static bool Validate(string password)
    {
        bool hasLowerCase = false;
        bool hasUpperCase = false;
        bool hasDigit = false;
        bool hasSpecialChar = false;

        foreach (char c in password)
        {
            if (char.IsLower(c))
            {
                hasLowerCase = true;
            }
            else if (char.IsUpper(c))
            {
                hasUpperCase = true;
            }
            else if (char.IsDigit(c))
            {
                hasDigit = true;
            }
            else if (!char.IsLetterOrDigit(c))
            {
                hasSpecialChar = true;
            }
        }

        return hasLowerCase && hasUpperCase && hasDigit && hasSpecialChar;
    }
}
