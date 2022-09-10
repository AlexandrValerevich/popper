using MediatR;

namespace GifFiles.Application.Commands.DeleteAllUserGifs;

public record DeleteAllUserGifsCommand(Guid UsesId) : IRequest;