using GifFiles.Application.Interfaces;
using MediatR;

namespace GifFiles.Application.Commands.DeleteGifFile;

public class DeleteGifFileCommandHandler : IRequestHandler<DeleteGifFileCommand>
{
    private readonly IGifRemover _gifRemover;

    public DeleteGifFileCommandHandler(IGifRemover gifRemover)
    {
        _gifRemover = gifRemover;
    }

    public async Task<Unit> Handle(DeleteGifFileCommand request, CancellationToken token)
    {
        await _gifRemover.RemoveByIdAsync(request.Id, token);
        return Unit.Value;
    }
}

