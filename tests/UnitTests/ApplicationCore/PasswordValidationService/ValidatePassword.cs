using Library.ApplicationCore.Enums;
using Library.ApplicationCore.Services;

namespace Library.UnitTests.ApplicationCore.PasswordValidationServiceTests;

public class ValidatePasswordTest
{
    private readonly PasswordValidationService _passwordValidationService;

    public ValidatePasswordTest()
    {
        _passwordValidationService = new PasswordValidationService();
    }

    [Theory(DisplayName = "PasswordValidationService.ValidatePassword: Returns Valid for strong passwords")]
    [InlineData("MySecureP@ss123")]
    [InlineData("LongEnoughPassword")]
    [InlineData("Test!ng#P@ssword")]
    [InlineData("With Spaces 123!")]
    [InlineData("abcdefgh")]
    [InlineData("!@#$%^&*()")]
    [InlineData("UniqueP4ss!")]
    public void ValidatePassword_ReturnsValid(string password)
    {
        // Act
        PasswordValidationResult result = _passwordValidationService.ValidatePassword(password);

        // Assert
        Assert.Equal(PasswordValidationResult.Valid, result);
    }

    [Theory(DisplayName = "PasswordValidationService.ValidatePassword: Returns TooShort for passwords below minimum length")]
    [InlineData("")]
    [InlineData("a")]
    [InlineData("ab")]
    [InlineData("abc")]
    [InlineData("abcd")]
    [InlineData("abcde")]
    [InlineData("abcdef")]
    [InlineData("abcdefg")]
    public void ValidatePassword_ReturnsTooShort(string password)
    {
        // Act
        PasswordValidationResult result = _passwordValidationService.ValidatePassword(password);

        // Assert
        Assert.Equal(PasswordValidationResult.TooShort, result);
    }

    [Fact(DisplayName = "PasswordValidationService.ValidatePassword: Returns TooShort for null password")]
    public void ValidatePassword_ReturnsTooShortForNull()
    {
        // Act
        PasswordValidationResult result = _passwordValidationService.ValidatePassword(null!);

        // Assert
        Assert.Equal(PasswordValidationResult.TooShort, result);
    }

    [Fact(DisplayName = "PasswordValidationService.ValidatePassword: Returns TooLong for passwords exceeding maximum length")]
    public void ValidatePassword_ReturnsTooLong()
    {
        // Arrange
        string tooLongPassword = new string('a', PasswordValidationService.MaxPasswordLength + 1);

        // Act
        PasswordValidationResult result = _passwordValidationService.ValidatePassword(tooLongPassword);

        // Assert
        Assert.Equal(PasswordValidationResult.TooLong, result);
    }

    [Theory(DisplayName = "PasswordValidationService.ValidatePassword: Returns CommonPassword for commonly used passwords")]
    [InlineData("password")]
    [InlineData("PASSWORD")]
    [InlineData("Password")]
    [InlineData("12345678")]
    [InlineData("qwerty123")]
    [InlineData("iloveyou")]
    [InlineData("changeme")]
    [InlineData("trustno1")]
    public void ValidatePassword_ReturnsCommonPassword(string password)
    {
        // Act
        PasswordValidationResult result = _passwordValidationService.ValidatePassword(password);

        // Assert
        Assert.Equal(PasswordValidationResult.CommonPassword, result);
    }

    [Theory(DisplayName = "PasswordValidationService.ValidatePassword: Returns ContainsInvalidCharacters for non-printable characters")]
    [InlineData("password\t123")]
    [InlineData("password\n123")]
    [InlineData("password\r123")]
    [InlineData("password\0123")]
    public void ValidatePassword_ReturnsContainsInvalidCharacters(string password)
    {
        // Act
        PasswordValidationResult result = _passwordValidationService.ValidatePassword(password);

        // Assert
        Assert.Equal(PasswordValidationResult.ContainsInvalidCharacters, result);
    }

    [Fact(DisplayName = "PasswordValidationService.ValidatePassword: Returns Valid for password at minimum length")]
    public void ValidatePassword_ReturnsValidForMinimumLength()
    {
        // Arrange
        string password = new string('a', PasswordValidationService.MinPasswordLength);

        // Act
        PasswordValidationResult result = _passwordValidationService.ValidatePassword(password);

        // Assert
        Assert.Equal(PasswordValidationResult.Valid, result);
    }

    [Fact(DisplayName = "PasswordValidationService.ValidatePassword: Returns Valid for password at maximum length")]
    public void ValidatePassword_ReturnsValidForMaximumLength()
    {
        // Arrange
        string password = new string('a', PasswordValidationService.MaxPasswordLength);

        // Act
        PasswordValidationResult result = _passwordValidationService.ValidatePassword(password);

        // Assert
        Assert.Equal(PasswordValidationResult.Valid, result);
    }

    [Theory(DisplayName = "PasswordValidationService.ValidatePassword: Allows all printable ASCII characters")]
    [InlineData("abcdefghijklmnop")]
    [InlineData("ABCDEFGHIJKLMNOP")]
    [InlineData("0123456789abcdef")]
    [InlineData("!@#$%^&*()_+-=[]")]
    [InlineData("{}|;':\",./<>?")]
    [InlineData("Password With Spaces")]
    [InlineData("~`Tilde and Backtick")]
    public void ValidatePassword_AllowsAllPrintableAscii(string password)
    {
        // Act
        PasswordValidationResult result = _passwordValidationService.ValidatePassword(password);

        // Assert
        Assert.Equal(PasswordValidationResult.Valid, result);
    }

    [Fact(DisplayName = "PasswordValidationService constants: MinPasswordLength is at least 8")]
    public void MinPasswordLength_IsAtLeast8()
    {
        // Assert
        Assert.True(PasswordValidationService.MinPasswordLength >= 8);
    }

    [Fact(DisplayName = "PasswordValidationService constants: MaxPasswordLength is at least 64")]
    public void MaxPasswordLength_IsAtLeast64()
    {
        // Assert
        Assert.True(PasswordValidationService.MaxPasswordLength >= 64);
    }
}
