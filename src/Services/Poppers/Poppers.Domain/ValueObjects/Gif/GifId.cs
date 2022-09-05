using ValueOf;

namespace Poppers.Domain.ValueObjects.Gif;

public class GifId : ValueOf<Guid, GifId>
{
    public static implicit operator Guid(GifId id) => id.Value;

    public static implicit operator GifId(Guid value) => From(value);
}
