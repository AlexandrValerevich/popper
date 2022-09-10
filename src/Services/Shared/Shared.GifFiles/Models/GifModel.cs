namespace Shared.GifFiles.Models;

public record GifModel(
    Guid Id,
    string Name,
    DateTime Created,
    Guid UserId
);