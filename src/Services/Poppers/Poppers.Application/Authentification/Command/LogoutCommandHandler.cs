using MediatR;

namespace Poppers.Application.Authentification.Command;

public class LogoutCommandHandler 
    : IRequestHandler<LogoutCommand>
{
    public Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}