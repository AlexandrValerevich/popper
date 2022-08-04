using MediatR;
using Screenshots.Application.DTO;

namespace Screenshots.Application.Queries;

public record CreateScreenshotsQuery(
    Uri Uri,
    string Selector,
    int Duration) : IRequest<ScreenshotsListDTO>;