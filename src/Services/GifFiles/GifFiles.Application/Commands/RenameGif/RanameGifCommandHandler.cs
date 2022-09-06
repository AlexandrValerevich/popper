using GifFiles.Application.Interfaces;
using MediatR;

namespace GifFiles.Application.Commands.RenameGif;

public class RenameGifCommandHandler : IRequestHandler<RenameGifCommand>
{
    private readonly IGifWriter _gifWriter;

    public RenameGifCommandHandler(IGifWriter gifWriter)
    {
        _gifWriter = gifWriter;
    }

    public async Task<Unit> Handle(RenameGifCommand request, CancellationToken cancellationToken)
    {
        await _gifWriter.RenameAsync(
            request.GifId, 
            request.UserId, 
            request.Name, 
            cancellationToken);
            
        return Unit.Value;
    }
}
