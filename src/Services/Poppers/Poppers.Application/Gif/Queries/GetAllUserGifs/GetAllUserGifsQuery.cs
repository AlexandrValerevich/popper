using MediatR;
using Poppers.Application.Gif.Common;

namespace Poppers.Application.Gif.Queries.GetGifById;

public record GetAllUserGifsQuery(Guid UserId) : IRequest<IEnumerable<GifReadOnlyModel>>;
