using MediatR;
using Poppers.Application.Authentication.Common;
using Poppers.Application.Common.Interfaces.Authentication;
using Poppers.Application.Common.Models;
using Poppers.Domain.Factory;
using Poppers.Domain.Interfaces;

namespace Poppers.Application.Authentication.Command.Registration;

public class RegistrationCommandHandler
    : IRequestHandler<RegistrationCommand, AuthenticationResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtGenerator;
    private readonly IUserFactory _userFactory;
    private readonly IRefreshTokenService _refreshTokenService;

    public RegistrationCommandHandler(IPasswordHasher passwordHasher,
        IUserRepository userRepository,
        IJwtTokenGenerator jwtGenerator,
        IUserFactory userFactory,
        IRefreshTokenService refreshTokenService)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _jwtGenerator = jwtGenerator;
        _userFactory = userFactory;
        _refreshTokenService = refreshTokenService;
    }

    public async Task<AuthenticationResult> Handle(RegistrationCommand request,
        CancellationToken cancellationToken)
    {
        var passwordHash = _passwordHasher.HashPassword(request.Password);
        var user = _userFactory.Create(Guid.NewGuid(),
            request.FirstName,
            request.SecondName,
            request.Email,
            passwordHash);

        await _userRepository.Add(user);

        var accessToken = _jwtGenerator.Generate(user.Id, user.FirstName, user.SecondName);
        RefreshToken refreshToken = await _refreshTokenService.CreateAsync(user.Id, 
            request.IpAddress, 
            request.DeviceId);
            
        return new AuthenticationResult(accessToken, refreshToken.Id.ToString());
    }
}