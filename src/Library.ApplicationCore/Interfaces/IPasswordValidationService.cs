using Library.ApplicationCore.Enums;

namespace Library.ApplicationCore.Interfaces;

public interface IPasswordValidationService
{
    PasswordValidationResult ValidatePassword(string password);
}
