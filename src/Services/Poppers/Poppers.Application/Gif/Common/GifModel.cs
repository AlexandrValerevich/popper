namespace Poppers.Application.Gif.Common;

public record GifReadOnlyModel(
    Guid Id,
    string Name,
    DateTime Created,
    Guid UserId
);