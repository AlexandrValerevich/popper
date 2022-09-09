using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;
using MediatR;

namespace GifFiles.Application.Commands.CreateGif;

public class CreateGifFileCommandHandler : IRequestHandler<CreateGifCommand, GifCreationResult>
{
    public readonly IGifFileWriter _gifFileWriter;
    public readonly IGifWriter _gifWriter;

    public CreateGifFileCommandHandler(IGifFileWriter gifFileWriter,
        IGifWriter gifWriter)
    {
        _gifFileWriter = gifFileWriter;
        _gifWriter = gifWriter;
    }

    public async Task<GifCreationResult> Handle(CreateGifCommand request, CancellationToken token)
    {
        var gif = new Gif(
            request.GifId,
            request.Name,
            DateTime.UtcNow,
            request.UserId
        );

        await _gifFileWriter.WriteAsync(
            gif.Id,
            request.UserId,
            request.Images,
            request.Delay,
            token
        );

        await _gifWriter.CreateAsync(gif, token);

        return new GifCreationResult(gif.Id);
    }
}