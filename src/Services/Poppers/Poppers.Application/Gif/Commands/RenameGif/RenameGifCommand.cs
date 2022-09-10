using MediatR;

namespace Poppers.Application.Gif.Commands.RenameGif;

public record RenameGifCommand(
    Guid GifId, 
    Guid UserId, 
    string Name) : IRequest;