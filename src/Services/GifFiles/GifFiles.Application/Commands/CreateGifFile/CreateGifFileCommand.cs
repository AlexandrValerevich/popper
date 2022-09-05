using GifFiles.Application.Common;
using MediatR;

namespace GifFiles.Application.Commands.CreateGifFile;

public record CreateGifFileCommand(
    Guid Id,
    IEnumerable<string> Images,
    int Delay) : IRequest<GifCreationResult>;