using Poppers.Domain.ValueObjects.Gif;
using Poppers.Domain.ValueObjects.User;

namespace Poppers.Domain.Entities;

public class User
{
    public UserId Id;
    private readonly string _firstName;
    private readonly string _secondName;
    private readonly Email _email;
    private readonly string _passwordHash;
    private readonly List<Gif> _gifs = new();

    internal User(UserId userId,
        string firstName,
        string secondName,
        Email email,
        string passwordHash)
    {
        Id = userId;
        _firstName = firstName;
        _secondName = secondName;
        _passwordHash = passwordHash;
        _email = email;
    }

    private User() { }

    public string FirstName => _firstName;

    public string SecondName => _secondName;

    public string PasswordHash => _passwordHash;

    public string Email => _email.Value;

    public IReadOnlyCollection<Gif> Gifs => _gifs.AsReadOnly();

    public void AddGif(Gif gif)
    {
        _gifs.Add(gif);
    }

    public void RemoveGif(GifId gifId)
    {
        var gif = GetGif(gifId);
        _gifs.Remove(gif);
    }

    public void RemoveAllGif()
    {
        _gifs.Clear();
    }

    public Gif GetGif(GifId id)
    {
        var gif = _gifs.SingleOrDefault(g => g.Id.Equals(id));
        if (gif is null)
        {
            throw new Exception("Gif Not Found");
        }
        return gif;
    }
}