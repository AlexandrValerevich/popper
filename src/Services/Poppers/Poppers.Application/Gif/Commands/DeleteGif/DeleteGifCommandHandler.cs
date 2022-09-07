using MediatR;
using Poppers.Application.Common.Interfaces.Persistence;

namespace Poppers.Application.Gif.Commands.DeleteGif;

public class DeleteGifCommandHandler : IRequestHandler<DeleteGifCommand>
{
    private readonly IGifWriter _gifWriter;

    public DeleteGifCommandHandler(IGifWriter gifWriter)
    {
        _gifWriter = gifWriter;
    }

    public async Task<Unit> Handle(DeleteGifCommand request,
        CancellationToken token)
    {
        await _gifWriter.DeleteAsync(request.Id, token);
        return Unit.Value;
    }
}