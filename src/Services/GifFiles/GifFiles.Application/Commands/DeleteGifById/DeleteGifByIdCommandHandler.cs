using GifFiles.Application.Interfaces;
using MediatR;

namespace GifFiles.Application.Commands.DeleteGifFile;

public class DeleteGifByIdCommandHandler : IRequestHandler<DeleteGifByIdCommand>
{
    private readonly IGifFileWriter _gifFileWriter;

    public DeleteGifByIdCommandHandler(
        IGifFileWriter gifFileWriter)
    {
        _gifFileWriter = gifFileWriter;
    }

    public async Task<Unit> Handle(DeleteGifByIdCommand request, CancellationToken token)
    {
        await _gifFileWriter.DeleteByIdAsync(request.GifId, request.UserId, token);
        return Unit.Value;
    }
}

