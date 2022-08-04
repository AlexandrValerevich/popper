using MediatR;
using Screenshots.Application.Common;

namespace Screenshots.Application.Queries;

public record CreateScreenshotsQuery(
    Uri Uri,
    string Selector,
    int Duration) : IRequest<ScreenshotsList>;