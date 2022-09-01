using Poppers.Domain.Errors;

namespace Poppers.Domain.ValueObjects;

public record Email
{
    public string Value { get; }

    public Email(string email)
    {
        if (!IsValidEmail(email))
        {
            throw new InvalidEmailException();
        }
        Value = email;
    }

    private static bool IsValidEmail(string email)
    {
        var trimmedEmail = email.Trim();

        if (trimmedEmail.EndsWith("."))
        {
            return false;
        }
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == trimmedEmail;
        }
        catch
        {
            return false;
        }
    }
}