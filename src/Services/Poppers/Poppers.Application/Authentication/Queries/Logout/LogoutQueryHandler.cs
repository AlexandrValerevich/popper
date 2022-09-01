using MediatR;

namespace Poppers.Application.Authentication.Command.Logout;

public class LogoutQueryHandler
    : IRequestHandler<LogoutQuery>
{
    public Task<Unit> Handle(LogoutQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}