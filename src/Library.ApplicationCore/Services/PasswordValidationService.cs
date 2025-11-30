using Library.ApplicationCore.Enums;
using Library.ApplicationCore.Interfaces;

namespace Library.ApplicationCore.Services;

public class PasswordValidationService : IPasswordValidationService
{
    public const int MinPasswordLength = 8;
    public const int MaxPasswordLength = 64;

    // Common passwords list based on OWASP recommendations
    // This is a sample list - in production, you might want to load this from a file
    // or use a more comprehensive database of compromised passwords
    private static readonly HashSet<string> CommonPasswords = new(StringComparer.OrdinalIgnoreCase)
    {
        "password",
        "password1",
        "password123",
        "123456",
        "12345678",
        "123456789",
        "1234567890",
        "qwerty",
        "qwerty123",
        "abc123",
        "letmein",
        "welcome",
        "admin",
        "administrator",
        "login",
        "passw0rd",
        "master",
        "hello",
        "charlie",
        "donald",
        "iloveyou",
        "sunshine",
        "princess",
        "football",
        "baseball",
        "dragon",
        "monkey",
        "shadow",
        "michael",
        "jennifer",
        "111111",
        "000000",
        "1234",
        "12345",
        "654321",
        "7777777",
        "1q2w3e4r",
        "qwertyuiop",
        "zaq12wsx",
        "trustno1",
        "changeme",
        "secret",
        "pass",
        "test",
        "guest",
        "starwars",
        "whatever"
    };

    public PasswordValidationResult ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            return PasswordValidationResult.TooShort;
        }

        if (password.Length < MinPasswordLength)
        {
            return PasswordValidationResult.TooShort;
        }

        if (password.Length > MaxPasswordLength)
        {
            return PasswordValidationResult.TooLong;
        }

        // Check for invalid characters (only printable ASCII characters are allowed)
        // Printable ASCII characters are in the range 0x20 (space) to 0x7E (~)
        foreach (char c in password)
        {
            if (c < 0x20 || c > 0x7E)
            {
                return PasswordValidationResult.ContainsInvalidCharacters;
            }
        }

        // Check if password is in the common passwords list
        if (CommonPasswords.Contains(password))
        {
            return PasswordValidationResult.CommonPassword;
        }

        return PasswordValidationResult.Valid;
    }
}
