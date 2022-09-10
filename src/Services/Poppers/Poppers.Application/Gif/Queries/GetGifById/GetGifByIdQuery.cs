using MediatR;
using Poppers.Application.Gif.Common;

namespace Poppers.Application.Gif.Queries.GetGifById;

public record GetGifByIdQuery(Guid GifId, Guid UserId) : IRequest<GifFile>;
