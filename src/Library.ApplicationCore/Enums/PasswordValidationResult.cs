namespace Library.ApplicationCore.Enums;

public enum PasswordValidationResult
{
    Valid,
    TooShort,
    TooLong,
    CommonPassword,
    ContainsInvalidCharacters
}
