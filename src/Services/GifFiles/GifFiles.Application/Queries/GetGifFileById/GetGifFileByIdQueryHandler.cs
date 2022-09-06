using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;
using MediatR;

namespace GifFiles.Application.Queries.GetGifFileById;

public class GetGifFileByIdQueryHandler : IRequestHandler<GetGifFileByIdQuery, GifFile>
{
    private readonly IGifFileReader _gifReader;

    public GetGifFileByIdQueryHandler(IGifFileReader gifReader)
    {
        _gifReader = gifReader;
    }

    public async Task<GifFile> Handle(GetGifFileByIdQuery request, CancellationToken token)
    {
        GifFile gifFile = await _gifReader.ReadByIdAsync(request.GifId, request.UserId, token);
        return gifFile;
    }
}