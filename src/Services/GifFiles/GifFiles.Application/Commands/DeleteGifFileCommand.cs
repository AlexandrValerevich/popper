using MediatR;

namespace GifFiles.Application.Commands;

public record DeleteGifFileCommand(Guid Id) : IRequest;