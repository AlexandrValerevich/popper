using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;
using MediatR;

namespace GifFiles.Application.Queries.GetGifFileById;

public class GetGifFileByIdQueryHandler : IRequestHandler<GetGifFileByIdQuery, GifFile>
{
    private readonly IGifFileReader _gifFileReader;

    public GetGifFileByIdQueryHandler(IGifFileReader gifReader)
    {
        _gifFileReader = gifReader;
    }

    public async Task<GifFile> Handle(GetGifFileByIdQuery request, CancellationToken token)
    {
        GifFile gifFile = await _gifFileReader.ReadByIdAsync(request.GifId, request.UserId, token);
        return gifFile;
    }
}