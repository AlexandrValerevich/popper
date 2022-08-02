using GifFiles.Application.Common;
using MediatR;

namespace GifFiles.Application.Commands;

public record CreateGifFileCommand(
    Guid Id,
    IEnumerable<byte[]> Images, 
    int Delay) : IRequest<GifCreationResult>;