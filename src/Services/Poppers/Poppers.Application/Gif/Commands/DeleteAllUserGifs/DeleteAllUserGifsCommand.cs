using MediatR;
using Poppers.Application.Common.Cqrs;

namespace Poppers.Application.Gif.Commands.DeleteAllUserGifs;

public record DeleteAllUserGifsCommand(Guid UserId) :  ICommand;
