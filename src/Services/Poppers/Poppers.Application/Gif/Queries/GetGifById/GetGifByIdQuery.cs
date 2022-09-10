using Poppers.Application.Common.Cqrs;
using Poppers.Application.Gif.Common;

namespace Poppers.Application.Gif.Queries.GetGifById;

public record GetGifByIdQuery(Guid GifId, Guid UserId) : IQuery<GifFile>;