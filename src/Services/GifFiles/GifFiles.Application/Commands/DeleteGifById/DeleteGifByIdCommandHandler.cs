using GifFiles.Application.Interfaces;
using MediatR;

namespace GifFiles.Application.Commands.DeleteGifFile;

public class DeleteGifByIdCommandHandler : IRequestHandler<DeleteGifByIdCommand>
{
    private readonly IGifFileWriter _gifFileWriter;
    private readonly IGifWriter _gifWriter;

    public DeleteGifByIdCommandHandler(
        IGifFileWriter gifFileWriter,
        IGifWriter gifWriter)
    {
        _gifFileWriter = gifFileWriter;
        _gifWriter = gifWriter;
    }

    public async Task<Unit> Handle(DeleteGifByIdCommand request, CancellationToken token)
    {
        await _gifWriter.DeleteByIdAsync(request.GifId, request.UserId, token);
        await _gifFileWriter.DeleteByIdAsync(request.GifId, request.UserId, token);
        return Unit.Value;
    }
}

