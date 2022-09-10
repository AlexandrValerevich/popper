using MediatR;

namespace Poppers.Application.Gif.Commands.DeleteAllUserGifs;

public record DeleteAllUserGifsCommand(Guid UserId) : IRequest;
