using GifFiles.Application.Common;
using MediatR;

namespace GifFiles.Application.Queries.GetGifFileById;

public record GetGifFileByIdQuery(Guid GifId, Guid UserId) : IRequest<GifFile>;
