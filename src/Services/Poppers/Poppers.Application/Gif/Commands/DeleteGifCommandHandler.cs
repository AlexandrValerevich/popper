using MediatR;
using Poppers.Application.Common.Interfaces.Persistence;

namespace Poppers.Application.Gif.Commands;

public class DeleteGifCommandHandler : IRequestHandler<DeleteGifCommand>
{
    private readonly IGifRemover _gifRemover;

    public DeleteGifCommandHandler(IGifRemover gifRemover)
    {
        _gifRemover = gifRemover;
    }

    public async Task<Unit> Handle(DeleteGifCommand request,
        CancellationToken token)
    {
        await _gifRemover.RemoveAsync(request.Id, token);
        return Unit.Value;
    }
}