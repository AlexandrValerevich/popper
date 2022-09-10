using MediatR;
using Poppers.Application.Common.Interfaces.Gif;
using Poppers.Application.Common.Interfaces.Persistence;
using Poppers.Application.Gif.Common;
using Poppers.Domain.Entities;
using Poppers.Domain.Factory;
using Poppers.Domain.Interfaces;
using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Application.Gif.Commands.CreateGif;

public class CreateGifCommandHandler : IRequestHandler<CreateGifCommand, GifCreationResult>
{
    private readonly IGifFactory _gifFactory;
    private readonly IScreenshotCreator _screenshotCreator;
    private readonly IGifFileWriter _gifFileWriter;
    private readonly IUserRepository _userRepository;

    public CreateGifCommandHandler(IScreenshotCreator screenshotCreator,
        IGifFactory gifFactory,
        IGifFileWriter gifFileWriter,
        IUserRepository userRepository)
    {
        _screenshotCreator = screenshotCreator;
        _gifFactory = gifFactory;
        _gifFileWriter = gifFileWriter;
        _userRepository = userRepository;
    }

    public async Task<GifCreationResult> Handle(CreateGifCommand request,
        CancellationToken token)
    {
        GifDomain gif = _gifFactory.Create(
            Guid.NewGuid(),
            request.Duration,
            request.Uri,
            request.ElementSelector,
            request.Name,
            DateTime.UtcNow
        );

        User user = await _userRepository.ReadById(request.UserId, token);
        user.AddGif(gif);
        await _userRepository.Update(user, token);

        ScreenshotList screenshots = await _screenshotCreator.TakeScreenshotsAsync(gif, token);
        await _gifFileWriter.CreateAsync(
            gif,
            request.UserId,
            screenshots,
            token);

        return new GifCreationResult(gif.Id);
    }
}