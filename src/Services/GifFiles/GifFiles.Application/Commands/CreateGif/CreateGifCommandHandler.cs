using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;
using MediatR;

namespace GifFiles.Application.Commands.CreateGif;

public class CreateGifFileCommandHandler : IRequestHandler<CreateGifCommand, GifCreationResult>
{
    public readonly IGifFileWriter _gifFileWriter;

    public CreateGifFileCommandHandler(IGifFileWriter gifFileWriter)
    {
        _gifFileWriter = gifFileWriter;
    }

    public async Task<GifCreationResult> Handle(CreateGifCommand request, CancellationToken token)
    {
        await _gifFileWriter.WriteAsync(
            request.GifId,
            request.UserId,
            request.Images,
            request.Delay,
            token
        );

        return new GifCreationResult(request.GifId);
    }
}