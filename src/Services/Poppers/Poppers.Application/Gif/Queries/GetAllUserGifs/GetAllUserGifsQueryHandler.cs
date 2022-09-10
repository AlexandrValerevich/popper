using MediatR;
using Poppers.Application.Common.Cqrs;
using Poppers.Application.Common.Interfaces.Persistence;
using Poppers.Application.Gif.Common;

namespace Poppers.Application.Gif.Queries.GetGifById;

public class GetAllUserGifsQueryHandler : 
    IRequestHandler<GetAllUserGifsQuery, IEnumerable<GifReadOnlyModel>>
{
    private readonly IGifReader _gifReader;

    public GetAllUserGifsQueryHandler(IGifReader gifReader)
    {
        _gifReader = gifReader;
    }

    public async Task<IEnumerable<GifReadOnlyModel>> Handle(GetAllUserGifsQuery request, CancellationToken cancellationToken)
    {
        return await _gifReader.ReadAllUserGifsAsync(request.UserId, cancellationToken);
    }
}