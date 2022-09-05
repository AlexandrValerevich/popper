using GifFiles.Application.Common;
using MediatR;

namespace GifFiles.Application.Queries.GetGifFileById;

public record GetGifFileByIdQuery(Guid Id) : IRequest<GifFile>;
