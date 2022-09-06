using GifFiles.Application.Common;
using MediatR;

namespace GifFiles.Application.Queries.GetAllUserGifs;

public record GetAllUserGifsQuery(Guid UserId): IRequest<IEnumerable<Gif>>;