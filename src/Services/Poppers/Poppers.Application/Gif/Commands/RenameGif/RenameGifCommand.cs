using MediatR;
using Poppers.Application.Common.Cqrs;

namespace Poppers.Application.Gif.Commands.RenameGif;

public record RenameGifCommand(
    Guid GifId,
    Guid UserId,
    string Name) : ICommand;