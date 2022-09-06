using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;
using MediatR;

namespace GifFiles.Application.Queries.GetAllUserGifs;

public class GetAllUserGifsQueryHandler 
    : IRequestHandler<GetAllUserGifsQuery, IEnumerable<Gif>>
{
    private readonly IGifReader _gifReader;

    public GetAllUserGifsQueryHandler(IGifReader gifReader)
    {
        _gifReader = gifReader;
    }

    public async Task<IEnumerable<Gif>> Handle(GetAllUserGifsQuery request, CancellationToken cancellationToken)
    {
        return await _gifReader.ReadAllAsync(request.UserId, cancellationToken);
    }
}
