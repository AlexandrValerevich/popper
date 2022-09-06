using GifFiles.Application.Common;
using MediatR;

namespace GifFiles.Application.Commands.CreateGif;

public record CreateGifCommand(
    Guid UserId,
    string Name,
    int Delay,
    IEnumerable<string> Images) : IRequest<GifCreationResult>;