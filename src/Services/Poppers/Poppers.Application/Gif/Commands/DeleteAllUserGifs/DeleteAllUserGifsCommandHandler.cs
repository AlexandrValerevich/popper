using MediatR;
using Poppers.Application.Common.Interfaces.Persistence;
using Poppers.Domain.Interfaces;

namespace Poppers.Application.Gif.Commands.DeleteAllUserGifs;

public class DeleteAllUserGifsCommandHandler : IRequestHandler<DeleteAllUserGifsCommand>
{
    private readonly IGifFileWriter _gifFileWriter;
    private readonly IUserRepository _userRepository;

    public DeleteAllUserGifsCommandHandler(IGifFileWriter gifFileWriter,
        IUserRepository userRepository)
    {

        _gifFileWriter = gifFileWriter;
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteAllUserGifsCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.ReadById(request.UserId, cancellationToken);
        user.RemoveAllGif();
        await _userRepository.Update(user, cancellationToken);
        
        await _gifFileWriter.DeleteAllUserGifsAsync(request.UserId, cancellationToken);

        return Unit.Value;
    }
}