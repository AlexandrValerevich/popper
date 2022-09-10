using GifFiles.Application.Interfaces;
using MediatR;

namespace GifFiles.Application.Commands.DeleteAllUserGifs;

public class DeleteAllUserGifsCommandHandler : IRequestHandler<DeleteAllUserGifsCommand>
{
    private readonly IGifFileWriter _gifFileWriter;
  

    public DeleteAllUserGifsCommandHandler(IGifFileWriter gifFileWriter)
    {
        _gifFileWriter = gifFileWriter;
    }

    public async Task<Unit> Handle(DeleteAllUserGifsCommand request, CancellationToken cancellationToken)
    {
        await _gifFileWriter.DeleteAllUserGifsAsync(request.UsesId, cancellationToken);
        return Unit.Value;
    }
}
