using GifFiles.Application.Common;
using MediatR;

namespace GifFiles.Application.Commands;

public record CreateGifCommand(
    IEnumerable<byte[]> Images, int Delay) : IRequest<GifCreationResult>;