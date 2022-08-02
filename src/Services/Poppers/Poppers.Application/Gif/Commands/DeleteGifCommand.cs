using MediatR;

namespace Poppers.Application.Gif.Commands;

public record DeleteGifCommand(Guid Id) : IRequest;