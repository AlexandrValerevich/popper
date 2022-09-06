using GifFiles.Application.Interfaces;
using MediatR;

namespace GifFiles.Application.Commands.DeleteAllUserGifs;

public class DeleteAllUserGifsCommandHandler : IRequestHandler<DeleteAllUserGifsCommand>
{
    private readonly IGifFileWriter _gifFileWriter;
    private readonly IGifWriter _gifWriter;

    public DeleteAllUserGifsCommandHandler(
        IGifFileWriter gifFileWriter,
        IGifWriter gifWriter)
    {
        _gifFileWriter = gifFileWriter;
        _gifWriter = gifWriter;
    }

    public async Task<Unit> Handle(DeleteAllUserGifsCommand request, CancellationToken cancellationToken)
    {
        await _gifWriter.DeleteAllByUserIdAsync(request.UsesId, cancellationToken);
        await _gifFileWriter.DeleteAllUserGifsAsync(request.UsesId, cancellationToken);
        return Unit.Value;
    }
}
