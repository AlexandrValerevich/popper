using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;
using MediatR;

namespace GifFiles.Application.Queries.GetGifFileById;

public class GetGifFileByIdQueryHandler : IRequestHandler<GetGifFileByIdQuery, GifFile>
{
    private readonly IGifReader _gifReader;

    public GetGifFileByIdQueryHandler(IGifReader gifReader)
    {
        _gifReader = gifReader;
    }

    public async Task<GifFile> Handle(GetGifFileByIdQuery request, CancellationToken token)
    {
        GifFile gif = await _gifReader.ReadByIdAsync(request.Id, token);
        return gif;
    }
}