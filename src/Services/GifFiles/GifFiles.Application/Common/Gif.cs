namespace GifFiles.Application.Common;

public record Gif(
    Guid Id,
    string Name,
    DateTime Created,
    Guid UserId
);