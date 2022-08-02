using MediatR;
using Poppers.Application.Gif.Interfaces;

namespace Poppers.Application.Gif.Commands;

public class DeleteGifCommandHandler : IRequestHandler<DeleteGifCommand>
{
    private readonly IGifRemover _gifRemover;

    public DeleteGifCommandHandler(IGifRemover gifRemover)
    {
        _gifRemover = gifRemover;
    }

    public async Task<Unit> Handle(DeleteGifCommand request, CancellationToken cancellationToken)
    {
        await _gifRemover.RemoveAsync(request.Id);
        return Unit.Value;
    }
}