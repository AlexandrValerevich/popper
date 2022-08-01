using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;
using MediatR;

namespace GifFiles.Application.Commands;

public class CreateGifCommandHandler : IRequestHandler<CreateGifCommand, GifCreationResult>
{
    public readonly IGifWriter _gifWriter;

    public CreateGifCommandHandler(IGifWriter gifWriter)
    {
        _gifWriter = gifWriter;
    }

    public async Task<GifCreationResult> Handle(CreateGifCommand request, CancellationToken cancellationToken)
    {
        GifCreationResult gifCreation = await _gifWriter.Write(
            request.Images,
            request.Delay
        );

        return gifCreation;
    }
}