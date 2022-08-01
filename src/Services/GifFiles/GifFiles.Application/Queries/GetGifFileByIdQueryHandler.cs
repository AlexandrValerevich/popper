using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;
using MediatR;

namespace GifFiles.Application.Queries;

public class GetGifFileByIdQueryHandler : IRequestHandler<GetGifFileByIdQuery, GifFile>
{
    private readonly IGifReader _gifReader;

    public GetGifFileByIdQueryHandler(IGifReader gifReader)
    {
        _gifReader = gifReader;
    }

    public async Task<GifFile> Handle(GetGifFileByIdQuery request, CancellationToken cancellationToken)
    {
        GifFile gif = await _gifReader.ReadByIdAsync(request.Id);
        return gif;
    }
}