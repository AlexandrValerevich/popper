using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;
using MediatR;

namespace GifFiles.Application.Commands.CreateGifFile;

public class CreateGifFileCommandHandler : IRequestHandler<CreateGifFileCommand, GifCreationResult>
{
    public readonly IGifWriter _gifWriter;

    public CreateGifFileCommandHandler(IGifWriter gifWriter)
    {
        _gifWriter = gifWriter;
    }

    public async Task<GifCreationResult> Handle(CreateGifFileCommand request, CancellationToken token)
    {
        GifCreationResult gifCreation = await _gifWriter.WriteAsync(
            request.Id,
            request.Images,
            request.Delay,
            token
        );

        return gifCreation;
    }
}