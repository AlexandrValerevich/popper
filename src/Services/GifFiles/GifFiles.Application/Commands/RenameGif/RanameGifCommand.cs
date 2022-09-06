using MediatR;

namespace GifFiles.Application.Commands.RenameGif;

public record RenameGifCommand(Guid GifId, Guid UserId, string Name) : IRequest;