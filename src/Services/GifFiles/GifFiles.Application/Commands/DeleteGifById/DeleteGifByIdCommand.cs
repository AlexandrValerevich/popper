using MediatR;

namespace GifFiles.Application.Commands.DeleteGifFile;

public record DeleteGifByIdCommand(Guid GifId, Guid UserId) : IRequest;