using System.Net.Mail;
using Poppers.Domain.Exceptions.User;

namespace Poppers.Domain.ValueObjects.User;

public record Email
{
    public string Value { get; }

    public Email(string email)
    {
        if (!IsValidEmail(email))
        {
            throw new InvalidEmailException(email);
        }
        Value = email.ToLower();
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
            var addr = new MailAddress(email);
            return addr.Address == trimmedEmail;
        }
        catch
        {
            return false;
        }
    }

    public static implicit operator string(Email email) => email.Value;

    public static implicit operator Email(string value) => new(value);
}