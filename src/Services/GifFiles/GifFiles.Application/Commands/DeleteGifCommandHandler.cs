using GifFiles.Application.Interfaces;
using MediatR;

namespace GifFiles.Application.Commands;

public class DeleteGifCommandHandler : IRequestHandler<DeleteGifCommand>
{
    private readonly IGifRemover _gifRemover;

    public DeleteGifCommandHandler(IGifRemover gifRemover)
    {
        _gifRemover = gifRemover;
    }

    public async Task<Unit> Handle(DeleteGifCommand request, CancellationToken cancellationToken)
    {
        await _gifRemover.RemoveById(request.Id);
        return Unit.Value;
    }
}

