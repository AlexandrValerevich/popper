using MediatR;
using Poppers.Application.Gif.Common;

namespace Poppers.Application.Gif.Commands;

public class CreateGifCommand : IRequest<GifCreationResult>
{
    public int Duration { get; set; }
    public string ElementSelector { get; set; }
    public string Uri { get; set; }
}