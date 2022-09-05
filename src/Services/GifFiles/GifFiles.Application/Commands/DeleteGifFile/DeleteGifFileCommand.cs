using MediatR;

namespace GifFiles.Application.Commands.DeleteGifFile;

public record DeleteGifFileCommand(Guid Id) : IRequest;