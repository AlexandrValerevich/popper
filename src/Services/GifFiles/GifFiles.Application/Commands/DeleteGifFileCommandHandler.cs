using GifFiles.Application.Interfaces;
using MediatR;

namespace GifFiles.Application.Commands;

public class DeleteGifFileCommandHandler : IRequestHandler<DeleteGifFileCommand>
{
    private readonly IGifRemover _gifRemover;

    public DeleteGifFileCommandHandler(IGifRemover gifRemover)
    {
        _gifRemover = gifRemover;
    }

    public async Task<Unit> Handle(DeleteGifFileCommand request, CancellationToken cancellationToken)
    {
        await _gifRemover.RemoveById(request.Id);
        return Unit.Value;
    }
}

