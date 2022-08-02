using MediatR;
using Poppers.Application.Gif.Common;
using Poppers.Application.Gif.Interfaces;

namespace Poppers.Application.Gif.Queries;

public class GetGifByIdQueryHandler : IRequestHandler<GetGifByIdQuery, GifFile>
{
    private readonly IGifReader _gifFileReader;

    public GetGifByIdQueryHandler(IGifReader gifFileReader)
    {
        _gifFileReader = gifFileReader;
    }

    public async Task<GifFile> Handle(GetGifByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _gifFileReader.ReadAsync(request.Id);
    }
}