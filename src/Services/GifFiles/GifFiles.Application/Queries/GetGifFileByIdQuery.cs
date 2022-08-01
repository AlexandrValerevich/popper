using GifFiles.Application.Common;
using MediatR;

namespace GifFiles.Application.Queries;

public record GetGifFileByIdQuery(Guid Id) : IRequest<GifFile>;
