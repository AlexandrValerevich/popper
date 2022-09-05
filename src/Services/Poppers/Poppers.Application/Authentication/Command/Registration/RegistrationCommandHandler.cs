using System.Net;
using MediatR;
using Poppers.Application.Authentication.Common;
using Poppers.Application.Common.Exceptions.Authentication;
using Poppers.Application.Common.Interfaces.Authentication;
using Poppers.Application.Common.Models;
using Poppers.Domain.Factory;
using Poppers.Domain.Interfaces;

namespace Poppers.Application.Authentication.Command.Registration;

public class RegistrationCommandHandler
    : IRequestHandler<RegistrationCommand, AuthenticationResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtGenerator;
    private readonly IUserFactory _userFactory;
    private readonly IRefreshTokenService _refreshTokenService;

    public RegistrationCommandHandler(IPasswordHasher passwordHasher,
        IUserRepository userRepository,
        IJwtTokenGenerator jwtGenerator,
        IUserFactory userFactory,
        IRefreshTokenService refreshTokenService,
        IUserService userService)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _jwtGenerator = jwtGenerator;
        _userFactory = userFactory;
        _refreshTokenService = refreshTokenService;
        _userService = userService;
    }

    public async Task<AuthenticationResult> Handle(RegistrationCommand request,
        CancellationToken cancellationToken)
    {
        await CheckEmailDuplicating(request.Email, cancellationToken);

        var passwordHash = _passwordHasher.HashPassword(request.Password);
        var user = _userFactory.Create(Guid.NewGuid(),
            request.FirstName,
            request.SecondName,
            request.Email,
            passwordHash);

        await _userRepository.Add(user, cancellationToken);

        var accessToken = _jwtGenerator.Generate(user.Id, user.FirstName, user.SecondName);
        RefreshToken refreshToken = await _refreshTokenService.CreateAsync(user.Id,
            request.IpAddress,
            request.DeviceId,
            cancellationToken);

        return new AuthenticationResult(accessToken, refreshToken.Id.ToString());
    }

    private async Task CheckEmailDuplicating(string email, CancellationToken cancellationToken)
    {
        bool isExistedUser = await _userService.IsExistedUser(email, cancellationToken);

        if (isExistedUser)
        {
            throw new DuplicateEmailException(email);
        }
    }
}