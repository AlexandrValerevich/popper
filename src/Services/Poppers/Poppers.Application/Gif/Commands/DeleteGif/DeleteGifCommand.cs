using MediatR;

namespace Poppers.Application.Gif.Commands.DeleteGif;

public record DeleteGifCommand(Guid Id) : IRequest;