using MediatR;

namespace Poppers.Application.Authentication.Command.Logout;

public class LogoutCommandHandler
    : IRequestHandler<LogoutCommand>
{
    public Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}