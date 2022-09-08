using MediatR;

namespace Poppers.Application.Gif.Commands.DeleteGif;

public record DeleteGifCommand(Guid GifId, Guid UserId) : IRequest;