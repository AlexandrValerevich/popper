using MediatR;
using Poppers.Application.Gif.Common;

namespace Poppers.Application.Gif.Commands.CreateGif;

public record CreateGifCommand(Guid UserId, int Duration, string ElementSelector, string Uri, string Name) : IRequest<GifCreationResult>;
