using MediatR;
using Poppers.Application.Common.Interfaces.Persistence;
using Poppers.Application.Gif.Common;

namespace Poppers.Application.Gif.Queries;

public class GetGifByIdQueryHandler : IRequestHandler<GetGifByIdQuery, GifFile>
{
    private readonly IGifReader _gifFileReader;

    public GetGifByIdQueryHandler(IGifReader gifFileReader)
    {
        _gifFileReader = gifFileReader;
    }

    public async Task<GifFile> Handle(GetGifByIdQuery request,
        CancellationToken token)
    {
        return await _gifFileReader.ReadAsync(request.GifId, request.UserId, token);
    }
}