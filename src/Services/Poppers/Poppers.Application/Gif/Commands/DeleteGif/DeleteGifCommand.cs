using MediatR;
using Poppers.Application.Common.Cqrs;

namespace Poppers.Application.Gif.Commands.DeleteGif;

public record DeleteGifCommand(Guid GifId, Guid UserId) : ICommand;