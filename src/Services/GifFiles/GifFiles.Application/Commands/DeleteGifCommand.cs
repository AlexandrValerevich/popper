using MediatR;

namespace GifFiles.Application.Commands;

public record DeleteGifCommand(Guid Id) : IRequest;