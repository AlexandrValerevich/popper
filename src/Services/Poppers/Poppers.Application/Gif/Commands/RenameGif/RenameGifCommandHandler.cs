using MediatR;
using Poppers.Application.Common.Interfaces.Persistence;
using Poppers.Domain.Factory;
using Poppers.Domain.Interfaces;

namespace Poppers.Application.Gif.Commands.RenameGif;

public class RenameGifCommandHandler : IRequestHandler<RenameGifCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IGifFactory _gifFactory;

    public RenameGifCommandHandler(
        IUserRepository userRepository,
        IGifFactory gifFactory)
    {
        _userRepository = userRepository;
        _gifFactory = gifFactory;
    }

    public async Task<Unit> Handle(RenameGifCommand request,
        CancellationToken token)
    {
        var user = await _userRepository.ReadById(request.UserId, token);
        var oldGif = user.GetGif(request.GifId);

        var updatedGif = _gifFactory.Create(
            oldGif.Id,
            oldGif.Duration,
            oldGif.Uri,
            oldGif.Selector,
            request.Name,
            oldGif.Created
        );

        user.RemoveGif(oldGif.Id);
        user.AddGif(updatedGif);

        await _userRepository.Update(user, token);

        return Unit.Value;
    }
}