using MediatR;
using Poppers.Application.Common.Interfaces.Persistence;
using Poppers.Domain.Interfaces;

namespace Poppers.Application.Gif.Commands.DeleteGif;

public class DeleteGifCommandHandler : IRequestHandler<DeleteGifCommand>
{
    private readonly IGifFileWriter _gifFileWriter;
    private readonly IUserRepository _userRepository;

    public DeleteGifCommandHandler(IGifFileWriter gifFileWriter,
        IUserRepository userRepository)
    {
        _gifFileWriter = gifFileWriter;
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteGifCommand request,
        CancellationToken token)
    {
        var user = await _userRepository.ReadById(request.UserId, token);
        user.RemoveGif(request.GifId);
        await _userRepository.Update(user, token);

        await _gifFileWriter.DeleteAsync(request.GifId, request.UserId, token);
        return Unit.Value;
    }
}